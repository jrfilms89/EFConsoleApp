using EdDbEfLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace EdDbEfLib.Controllers {
    public class StudentsController {

        private readonly EdDbContext _context = null;

        public async Task<IEnumerable<Student>> GetAll() {
            return await _context.Student.ToListAsync();
        }

        public async Task<Student> GetByPK(int id) {
            return await _context.Student.FindAsync(id);
        }

        public async Task<bool> Insert(Student student) {
            IfStudentNull(student);
            _context.Student.Add(student);
            await SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int Id, Student student) {
            IfStudentNull(student);
            if (Id != student.Id)
                throw new Exception("Student does not match Student.Id.");
            _context.Student.Update(student);
            await SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id) {
            var student = GetByPK(id);
            _context.Remove(student.Result);
            await SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Student student) {
            IfStudentNull(student);
            _context.Student.Remove(student);
            await SaveChangesAsync();
            return true;
        }

        private void IfStudentNull(Student student) {
            if (student == null)
                throw new Exception("Student can not be null.");
            
        }

        public async Task<IEnumerable<Student>> GetByMajorDescription(string description) {
            var students = _context.Student.Where(s => s.Major.Description.Contains(description)).ToArrayAsync();
            return await students;
        }

        private async Task SaveChangesAsync() {
            await _context.SaveChangesAsync();
        }

        public StudentsController() {
            _context = new EdDbContext();
        }
    }
}
