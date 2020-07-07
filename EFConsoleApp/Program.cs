using System;
using System.Linq;
using System.Threading.Tasks;
using EdDbEfLib;
using EdDbEfLib.Controllers;
using EdDbEfLib.Models;
using Microsoft.EntityFrameworkCore;

namespace EFConsoleApp {
    class Program {

        

        static async Task Main(string[] args) {

            var newStud = new Student {
                Firstname = "Sebastian",
                Lastname = "Dodd",
                Sat = 1300,
                StateCode = "AK",
                Gpa = 3,
                MajorId = 2
            };

            //get all classes that a student ISNT enrolled in but is required by major
            
            var studentctrl = new StudentsController();
            var student = await studentctrl.GetByMajorDescription("mat");
        }
    }
}
