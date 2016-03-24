using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManagement.Models
{
    public class CourseStudent
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        public int Mark { get; set; }

        public virtual ApplicationUser Student { get; set; }
        public virtual Course Course { get; set; }
    }
}