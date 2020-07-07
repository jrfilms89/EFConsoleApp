using System;
using System.Collections.Generic;

namespace EdDbEfLib.Models
{
    public partial class Class
    {
        public Class()
        {
            Assignment = new HashSet<Assignment>();
            MajorClass = new HashSet<MajorClass>();
            StudentClass = new HashSet<StudentClass>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Subject { get; set; }
        public int Section { get; set; }
        public int? InstructorId { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual ICollection<Assignment> Assignment { get; set; }
        public virtual ICollection<MajorClass> MajorClass { get; set; }
        public virtual ICollection<StudentClass> StudentClass { get; set; }
    }
}
