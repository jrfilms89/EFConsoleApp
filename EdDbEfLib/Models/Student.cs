using System;
using System.Collections.Generic;

namespace EdDbEfLib.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentClass = new HashSet<StudentClass>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string StateCode { get; set; }
        public int? Sat { get; set; }
        public decimal Gpa { get; set; }
        public int? MajorId { get; set; }

        public virtual Major Major { get; set; }
        public virtual ICollection<StudentClass> StudentClass { get; set; }
    }
}
