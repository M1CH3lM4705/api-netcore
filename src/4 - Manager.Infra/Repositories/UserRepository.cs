using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Infra.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository{

        private readonly ManagerContext _context;

        public UserRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email){
            var user = await _context.Users
                                     .AsNoTracking()
                                     .Where(
                                         x =>
                                            x.Email.ToLower() == email.ToLower()
                                     )                                     
                                     .ToListAsync();
            return user.FirstOrDefault();
        }

        public async Task<List<User>> SearchByEmail(string email){
            var allUsers = await _context.Users
                                         .AsNoTracking()
                                         .Where(
                                             x =>
                                                x.Email.ToLower().Contains(email.ToLower())
                                         )                                         
                                         .ToListAsync();
            return allUsers;
        }

        public async Task<List<User>> SearchByName(string name){
            var allUsers = await _context.Users
                                         .AsNoTracking()
                                         .Where(
                                             x =>
                                                x.Nome.ToLower().Contains(name.ToLower())
                                         )
                                         .ToListAsync();
            return allUsers;
        }
    }  
}