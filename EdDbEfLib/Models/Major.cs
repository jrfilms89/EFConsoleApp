using System;
using System.Collections.Generic;

namespace EdDbEfLib.Models
{
    public partial class Major
    {
        public Major()
        {
            MajorClass = new HashSet<MajorClass>();
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int MinSat { get; set; }

        public virtual ICollection<MajorClass> MajorClass { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
