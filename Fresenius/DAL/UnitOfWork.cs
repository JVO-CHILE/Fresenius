using System;
using Fresenius.Models;
using System.Threading.Tasks;

namespace Fresenius.DAL
{
    public class UnitOfWork
    {
        public UnitOfWork()
        {
            this.context = new MyDbContext();
        }
        private readonly MyDbContext context;

        private GenericRepository<User> usersRepository;
        public GenericRepository<User> UsersRepository
        {
            get
            {
                if (this.usersRepository == null)
                {
                    this.usersRepository = new GenericRepository<User>(this.context);
                }
                return this.usersRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }

}
