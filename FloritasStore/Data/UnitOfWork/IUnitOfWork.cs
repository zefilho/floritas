using FloritasStore.Data.Repositories;
using FloritasStore.Models;
using FloritasStore.Models.Users;
using System.Threading.Tasks;

namespace FloritasStore.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        Repository<Company> CompanyRepository { get; }

        Repository<ApplicationUser> UsersRepository { get; }

        Repository<ApplicationRole> RolesRepository { get; }

        public Task<int> Commit();

        public void RollBack();

    }
}
