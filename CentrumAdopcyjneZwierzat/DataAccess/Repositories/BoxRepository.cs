using CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts;
using CentrumAdopcyjneZwierzat.Models.AdoptionCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.DataAccess.Repositories
{
    public class BoxRepository : IBoxRepository
    {
        private ApplicationDbContext _context;
        public BoxRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Box box)
        {
            _context.Boxes.Add(box);
            return Save();
        }

        public bool Delete(string id)
        {
            _context.Boxes.Remove(FindById(id));
            return Save();
        }

        public ICollection<Box> FindAll()
        {
            var boxes = _context.Boxes.ToList();
            return boxes;
        }

        public Box FindById(string id)
        {
            var box = _context.Boxes.Find(id);
            return box;
        }

        public bool IsExists(string id)
        {
            var exists = _context.Boxes.Any(q => q.BoxId == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _context.SaveChanges();
            return changes > 0;
        }

        public bool Update(Box box)
        {
            _context.Boxes.Update(box);
            return Save();
        }
    }
}
