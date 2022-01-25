using CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts;
using CentrumAdopcyjneZwierzat.Models.AdoptionCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.DataAccess.Repositories
{
    public class VolunteerRepository : IVolunteerRepository
    {
        private ApplicationDbContext _context;
        public VolunteerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Volunteer volunteer)
        {
            _context.Volunteers.Add(volunteer);
            return Save();
        }

        public bool Delete(string id)
        {
            _context.Volunteers.Remove(FindById(id));
            return Save();
        }

        public ICollection<Volunteer> FindAll()
        {
            var volunteers = _context.Volunteers.ToList();
            return volunteers;
        }

        public Volunteer FindById(string id)
        {
            var volunteer = _context.Volunteers.Find(id);
            return volunteer;
        }

        public bool IsExists(string id)
        {
            var exists = _context.Volunteers.Any(q => q.VolunteerId == id); 
            return exists;
        }

        public bool Save()
        {
            var changes = _context.SaveChanges();
            return changes > 0; 
        }

        public bool Update(Volunteer volunteer)
        {
            _context.Volunteers.Update(volunteer);
            return Save();
        }
    }
}
