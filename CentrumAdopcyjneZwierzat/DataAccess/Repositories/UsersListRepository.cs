using CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts;
using CentrumAdopcyjneZwierzat.Models.User;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IList<ApplicationUser>> List()
        {
            return await _context.ApplicationUsers
                                     .OrderBy(c => c.UserName)
                                     .Select(c => new ApplicationUser
                                     {
                                          FirstName =c.FirstName,
                                          LastName = c.LastName,
                                          Phone =c.Phone,
                                          StreetAddress = c.StreetAddress,
                                          PostalCode = c.PostalCode,
                                          City = c.City
                                        })
                                     .ToListAsync();
        }

        public void AddVolunteerAsUser(string firstId, string secondId)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            _context.ApplicationUsers.Remove(FindById(id));
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

        public bool IsExists(string id)
        {
            var exists = _context.ApplicationUsers.Any(q => q.Id == id); // q - any object in ApplicationUsers collection 
            return exists;
        }

        public bool Save()
        {
            var changes = _context.SaveChanges();
            return changes > 0; // If changes > 0 = GOOD, else = NOT GOOD
        }

        public ApplicationUser SaveUser(ApplicationUser user)
        {
            var entryEntity = _context.ApplicationUsers.Add(user);
            _context.SaveChanges();
            return entryEntity.Entity;
        }

        public bool Update(ApplicationUser item)
        {
            _context.ApplicationUsers.Update(item);
            return Save();
        }

    }
}
