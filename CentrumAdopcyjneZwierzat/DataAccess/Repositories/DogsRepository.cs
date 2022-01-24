using CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts;
using CentrumAdopcyjneZwierzat.Models.AdoptionCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.DataAccess.Repositories
{
    public class DogsRepository : IDogsRepository
    {
        private ApplicationDbContext _context;
        public DogsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Dog dog)
        {
            _context.Dogs.Add(dog);
            return Save();
        }

        public bool Delete(string id)
        {
            _context.Dogs.Remove(FindById(id));
            return Save();
        }

        public ICollection<Dog> FindAll()
        {
            var dogs = _context.Dogs.ToList();
            return dogs;
        }

        public Dog FindById(string id)
        {
            var dog = _context.Dogs.Find(id);
            return dog;
        }

        public bool IsExists(string id)
        {
            var exists = _context.Dogs.Any(q => q.DogId == id); // q - any object in ApplicationUsers collection 
            return exists;
        }

        public bool Save()
        {
            var changes = _context.SaveChanges();
            return changes > 0; // If changes > 0 = GOOD, else = NOT GOOD
        }

        public bool Update(Dog dog)
        {
            _context.Dogs.Update(dog);
            return Save();
        }
    }
}
