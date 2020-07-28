using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FloritasStore.Data;
using FloritasStore.Data.UnitOfWork;
using FloritasStore.Models;
using FloritasStore.Models.Users;
using FloritasStore.Services;
using FloritasStore.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace FloritasStore.Controllers
{
    [Route("usuarios")]
    [Authorize(Roles = "Admin, Owner")]
    public class UsersController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<UsersController> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;

        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, ILogger<UsersController> logger, IAuthorizationService authorizationService,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
            _authorizationService = authorizationService;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: Users
        [Route("")]
        public async Task<ActionResult> Index()
        {            
            return View(User.IsInRole("Admin") ? await _unitOfWork.UsersRepository.GetAllAsync() :
                                await _unitOfWork.UsersRepository.
                                    GetAllAsync(predicate: op => op.CompanyId == Utilities.ConvertCompany(User)));
        }
        
        // GET: Users/Details/5
        [Route("detalhar/{id}")]
        public async Task<ActionResult> Details(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            
            var user = await _unitOfWork.UsersRepository.GetFirstOrDefaultAsync(predicate: u => u.Id.Equals(id));

            if(user == null)
            {
                return NotFound();
            }
            
            if (! (await UserAuthorize(user)))
            {
                return Redirect("/identity/account/accessdenied");
            }

            var userDetails = _mapper.Map<UserDetailsViewModel>(user);
            userDetails.Role = TransformRole((await _userManager.GetRolesAsync(user)).First());
            
            userDetails.Company = user.CompanyId == null ? "Nenhuma Empresa" :
                (await _unitOfWork.CompanyRepository.GetFirstOrDefaultAsync(predicate: c => c.Id == user.CompanyId)).Name;

            return View(userDetails);
        }

        // GET: Users/Create
        [Route("cadastrar")]
        public async Task<ActionResult> Create()
        {
                       
            ViewData["Roles"] = new SelectList(
                User.IsInRole("Admin") ? TransformRoles(await _unitOfWork.RolesRepository.GetAllAsync(orderBy: r => r.OrderBy(p => p.Name))) :
                                         TransformAndRemoveRoles(await _unitOfWork.RolesRepository.GetAllAsync(orderBy: r => r.OrderBy(p => p.Name)))
                , "Id", "Name");

            ViewData["Company"] = new SelectList(await _unitOfWork.CompanyRepository.GetAllAsync(), "Id", "Name");

            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [Route("cadastrar")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel form)
        {
            
            if (ModelState.IsValid)
            {
                                               
                var user = _mapper.Map<ApplicationUser>(form);
                user.UserName = form.Email;

                //Adicionando Company ao Usuario que nao é Admin
                if (!User.IsInRole("Admin"))
                    user.CompanyId = Utilities.ConvertCompany(User);

                if (user.CompanyId == 0)
                    user.CompanyId = null;                         

                var result = await _userManager.CreateAsync(user, form.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var role = await _roleManager.FindByIdAsync(form.roleID);

                    //Adding role to user
                    await _userManager.AddToRoleAsync(user, role.Name);
                    _logger.LogInformation("Role added.");

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmEmail = await _userManager.ConfirmEmailAsync(user, token);

                    //adicinando o número da companhia como uma Claim
                    await _userManager.AddClaimAsync(user, new Claim("Company", user.CompanyId.ToString()));
                                                            
                    if (confirmEmail.Succeeded)
                    {
                        _logger.LogInformation("User\'s Email confirmed.");
                        return RedirectToAction(nameof(Index));
                    }

                    ModelState.AddModelError(string.Empty, "Erro ao confirmar E-mail.");

                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }            

            ViewData["Roles"] = new SelectList(
                User.IsInRole("Admin") ? TransformRoles(await _unitOfWork.RolesRepository.GetAllAsync(orderBy: r => r.OrderBy(p => p.Name))) :
                                         TransformAndRemoveRoles(await _unitOfWork.RolesRepository.GetAllAsync(orderBy: r => r.OrderBy(p => p.Name)))
                , "Id", "Name", form.roleID);

            ViewData["Company"] = new SelectList(await _unitOfWork.CompanyRepository.GetAllAsync(), "Id", "Name", form.CompanyId);

            return View(form);
        }

        // GET: Users/Edit/5
        [Route("editar/{id}")]
        public async Task<ActionResult> Edit(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            
            var user = await _context.Users.Include(np => np.UserRoles).FirstOrDefaultAsync(u => u.Id.Equals(id));
            //await _context.Entry(user).Collection(np => np.UserRoles).LoadAsync();

            if(user == null)
            {
                return NotFound();
            }

            if (!(await UserAuthorize(user)))
            {
                return Redirect("/identity/account/accessdenied");
            }
                   
            var userEdit = _mapper.Map<EditUserViewModel>(user);
                        
            //Role
            var roleUser = user.UserRoles.FirstOrDefault();
            
            ViewData["Roles"] = new SelectList(
                User.IsInRole("Admin") ? TransformRoles(await _unitOfWork.RolesRepository.GetAllAsync(orderBy: r => r.OrderBy(p => p.Name))) :
                                         TransformAndRemoveRoles(await _unitOfWork.RolesRepository.GetAllAsync(orderBy: r => r.OrderBy(p => p.Name)))
                , "Id", "Name", roleUser?.RoleId);

            ViewData["Company"] = new SelectList(await _unitOfWork.CompanyRepository.GetAllAsync(), "Id", "Name", userEdit.CompanyId);

            return View(userEdit);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar/{id}")]
        public async Task<ActionResult> Edit(string id, EditUserViewModel form)
        {
            if (id != form.Id)
                return NotFound();

            var user = await _userManager.FindByIdAsync(form.Id);

            if (user == null)
                return NotFound();

            if (!(await UserAuthorize(user)))
            {
                return Redirect("/identity/account/accessdenied");
            }

            if (ModelState.IsValid)
            {

                user.UserName = form.Email;
                user.Name = form.Name;
                user.Email = form.Email;
                user.Cpf = form.Cpf;
                user.PhoneNumber = form.PhoneNumber;

                //Add Photo to User
                if(form.formFile != null)
                {
                    var stream = new MemoryStream();
                    await form.formFile.CopyToAsync(stream);

                    user.Photo = stream.ToArray();
                    user.PhotoMimeType = form.formFile.ContentType;
                    user.PhotoPoints = form.PhotoPoints;
                }

                if (!User.IsInRole("Admin"))
                    form.CompanyId = Utilities.ConvertCompany(User);

                var testCompanyChange = (user.CompanyId != form.CompanyId);
                user.CompanyId = form.CompanyId != 0 ? (int?)form.CompanyId : null;

                await _userManager.UpdateAsync(user);

                string userRoles = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

                var role = await _roleManager.FindByIdAsync(form.roleID);

                if (userRoles == null || !userRoles.Equals(role.Name))
                {

                    //Adding Role
                    await _userManager.AddToRoleAsync(user, role.Name);

                    if (!string.IsNullOrEmpty(userRoles))
                        await _userManager.RemoveFromRoleAsync(user, userRoles); //Remove role
                }

                if (testCompanyChange)
                {
                    var claimUser = await _userManager.GetClaimsAsync(user);

                    //Editing Claims
                    if (!user.CompanyId.HasValue)
                    {
                        await _userManager.RemoveClaimsAsync(user, claimUser);
                    }
                    else if (claimUser.Count > 0)
                    {
                        await _userManager.ReplaceClaimAsync(user, claimUser.First(), new Claim("Company", user.CompanyId.ToString()));
                    }
                    else
                    {
                        await _userManager.AddClaimAsync(user, new Claim("Company", user.CompanyId.ToString()));
                    }
                }


                return RedirectToAction(nameof(Index));
            }

            ViewData["Roles"] = new SelectList(
                User.IsInRole("Admin") ? TransformRoles(await _unitOfWork.RolesRepository.GetAllAsync(orderBy: r => r.OrderBy(p => p.Name))) :
                                         TransformAndRemoveRoles(await _unitOfWork.RolesRepository.GetAllAsync(orderBy: r => r.OrderBy(p => p.Name)))
                , "Id", "Name", form.Id);

            ViewData["Company"] = new SelectList(await _unitOfWork.CompanyRepository.GetAllAsync(), "Id", "Name", form.CompanyId);

            return View(form);
            
        }

        // GET: Users/Delete/5
        [Route("apagar/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
                                    
            var user = await _unitOfWork.UsersRepository.GetFirstOrDefaultAsync(predicate: u => u.Id.Equals(id));

            if (user == null)
            {
                return NotFound();
            }

            if (!(await UserAuthorize(user)))
            {
                return Redirect("/identity/account/accessdenied");
            }

            var userDetails = _mapper.Map<UserDetailsViewModel>(user);
            
            userDetails.Role = TransformRole((await _userManager.GetRolesAsync(user)).First());
                        
            userDetails.Company = user.CompanyId == null ? "Nenhuma Empresa" :
                (await _unitOfWork.CompanyRepository.GetFirstOrDefaultAsync(predicate: c => c.Id == user.CompanyId)).Name;

            return View(userDetails);
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("apagar/{id}")]
        public async Task<ActionResult> Delete(string id, bool notUsed)
        {            
            var user = await _userManager.FindByIdAsync(id);

            if(user == null)
            {
                return NotFound();
            }

            if (!(await UserAuthorize(user)))
            {
                return Redirect("/identity/account/accessdenied");
            }

            var result = await _userManager.DeleteAsync(user);
            
            //Remove Claims
            await _userManager.RemoveClaimsAsync(user,
                        await _userManager.GetClaimsAsync(user));

            if (result.Succeeded){
                return RedirectToAction(nameof(Index));
            }

            ViewData["Error"] = "Não foi possível excluir usuário devido ao um erro ocorrido. Por favor, informe ao administrador do sistema.";

            var userDetails = _mapper.Map<UserDetailsViewModel>(user);

            userDetails.Role = TransformRole((await _userManager.GetRolesAsync(user)).First());
            
            userDetails.Company = user.CompanyId == null ? "Nenhuma Empresa" :
                (await _unitOfWork.CompanyRepository.GetFirstOrDefaultAsync(predicate: c => c.Id == user.CompanyId)).Name;

            return View(userDetails);
        }


        [HttpGet]
        [Route("resetar-senha/{id}")]
        public ActionResult ResetPassword(string id)
        {
            return View(new ResetPasswordUserViewModel { Id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("resetar-senha/{id}")]
        public async Task<ActionResult> ResetPassword(string id, ResetPasswordUserViewModel form)
        {

            if (id != form.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByIdAsync(form.Id);

                if(user == null)
                {
                    return NotFound();
                }

                if (!(await UserAuthorize(user)))
                {
                    return Redirect("/identity/account/accessdenied");
                }

                string code = await _userManager.GeneratePasswordResetTokenAsync(user);

                var result = await _userManager.ResetPasswordAsync(user, code, form.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                foreach(var erro in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, erro.Description);
                }

            }
            
            return View(form);
        }


        private static Dictionary<string, string> convertRoles = new Dictionary<string, string>()
            {
                {"Admin", "Administrador" },
                {"Owner", "Proprietário" },
                {"Manager", "Gerente" },
                {"Employed", "Empregado" }
            };

        private List<ApplicationRole> TransformRoles (IList<ApplicationRole> roles)
        {
            return roles.Select(x => new ApplicationRole { Id = x.Id, Name = convertRoles[x.Name] }).ToList();  
        }

        private string TransformRole(string role)
        {
            return convertRoles[role];
        }

        private List<ApplicationRole> TransformAndRemoveRoles(IList<ApplicationRole> roles)
        {
            return roles.Where(r => !r.Name.Equals("Admin") && !r.Name.Equals("Owner"))
                .Select(x => new ApplicationRole { Id = x.Id, Name = convertRoles[x.Name] }).ToList();
        }

        private async Task<bool> UserAuthorize(ApplicationUser user) => (await _authorizationService
                .AuthorizeAsync(User, new Company { Id = user.CompanyId ?? 0 }, "SameCompany")).Succeeded;

        [Route("get-photo-user/{id}")]
        public async Task<FileContentResult> GetPhotoUser(string id)
        {
            var user = await _unitOfWork.UsersRepository.GetFirstOrDefaultAsync(predicate: u => u.Id.Equals(id));

            if(user != null)
            {
                return File(user.Photo, user.PhotoMimeType);
            }

            return null;
        }

    }
}