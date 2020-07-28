using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FloritasStore.Data;
using FloritasStore.Models;
using FloritasStore.Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;

namespace FloritasStore.Controllers
{
    [Route("empresas")]
    [Authorize(Roles = "Admin")]
    public class CompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CompaniesController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        [Route("")]
        // GET: Companies
        public async Task<IActionResult> Index()
        {            
            return View(await _unitOfWork.CompanyRepository.GetAllAsync());
        }

        // GET: Companies/Details/5
        [Route("detalhar/{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var company = await _unitOfWork.CompanyRepository
                .GetFirstOrDefaultAsync(predicate: m => m.Id == id);

            if (company == null)
            {
                return NotFound();
            }

            return View(company);
            
        }

        // GET: Companies/Create
        [Route("cadastrar")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("cadastrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CorporateName,PhoneNumber,Cnpj")] Company company)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CompanyRepository.Add(company);
                await _unitOfWork.Commit();

                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        [Route("editar/{id?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var company = await _unitOfWork.CompanyRepository.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("editar/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CorporateName,PhoneNumber,Cnpj")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {                    
                    _unitOfWork.CompanyRepository.Update(company);
                    await _unitOfWork.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        [Route("apagar/{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var company = await _unitOfWork.CompanyRepository
                .GetFirstOrDefaultAsync(predicate: m => m.Id == id);

            if (company == null)
            {
                return NotFound();
            }

            return View(company);            
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("apagar/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var company = await _unitOfWork.CompanyRepository.FindAsync(id);
            _unitOfWork.CompanyRepository.Remove(company);

            await _unitOfWork.Commit();

            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _unitOfWork.CompanyRepository.Exists(e => e.Id == id);
        }
    }
}
