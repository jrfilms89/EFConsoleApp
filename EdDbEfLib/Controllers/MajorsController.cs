using EdDbEfLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdDbEfLib.Controllers {
    public class MajorsController {

        private readonly EdDbContext _context = null;

        public async Task<IEnumerable<Major>> GetAll() {
           return await _context.Major.ToListAsync();
        }

        public async Task<Major> GetByPk(int id) {
            return await _context.Major.FindAsync(id);
        }

        public async Task<bool> Insert(Major major) {
            if (major == null) {
                throw new Exception("Major input can not be null.");
            } else
                await _context.Major.AddAsync(major);
                await _context.SaveChangesAsync();
                return true;
        }

        public async Task<bool> Update(int id, Major major) {
            if (major == null)
                throw new Exception("Major input cannot be null.");
            else if (id != major.Id)
                throw new Exception("Id does not match Major.Id");
            else
                _context.Update(major);
                await _context.SaveChangesAsync();
                return true;
        }

        public async Task<bool> Delete(Major major) {
            if (major == null)
                throw new Exception("Major input cannot be null.");
            else 
                _context.Remove(major);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id) {
            var major = GetByPk(id);
            if (major == null)
                throw new Exception("Major input cannot be null.");
            else
                await Delete(major.Result);
            return true;

        }

        public MajorsController() {
            _context = new EdDbContext();
        }

    }
}
