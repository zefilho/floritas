using FloritasStore.Data.Repositories;
using FloritasStore.Models;
using FloritasStore.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloritasStore.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        private Repository<Company> _companyRepository;
        private Repository<ApplicationUser> _usersRepository;
        private Repository<ApplicationRole> _rolesRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public Repository<Company> CompanyRepository => _companyRepository ??= new Repository<Company>(_context);

        public Repository<ApplicationUser> UsersRepository => _usersRepository ??= new Repository<ApplicationUser>(_context);

        public Repository<ApplicationRole> RolesRepository => _rolesRepository ??= new Repository<ApplicationRole>(_context);

        public async Task<int> Commit() => await _context.SaveChangesAsync();

        public void RollBack() => _context.Dispose();    
        
    }
}
