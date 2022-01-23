using CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts;
using CentrumAdopcyjneZwierzat.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.DataAccess.Repositories
{
    public class UsersListRepository : IUsersListRepository
    {
        private ApplicationDbContext _context;
        public UsersListRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(ApplicationUser item)
        {
            _context.ApplicationUsers.Add(item);
            return Save();
        }

        public void AddVolunteerAsUser(string firstId, string secondId)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ApplicationUser item)
        {
            _context.ApplicationUsers.Remove(item);
            return Save();
        }

        public ICollection<ApplicationUser> FindAll()
        {
            var applicationUsers = _context.ApplicationUsers.ToList();
            return applicationUsers;
        }

        public ApplicationUser FindById(string id)
        {
            var applicationUser = _context.ApplicationUsers.Find(id);
            return applicationUser;
        }

        public bool Save()
        {
            var changes = _context.SaveChanges();
            return changes > 0; // If changes > 0 = GOOD, else = NOT GOOD
        }

        public bool Update(ApplicationUser item)
        {
            _context.ApplicationUsers.Update(item);
            return Save();
        }
    }
}
