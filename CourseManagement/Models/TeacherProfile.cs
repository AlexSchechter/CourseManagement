using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CourseManagement.Models
{
    public class TeacherProfile
    {
        public int Id { get; set; }
        public string TeacherId { get; set; }
        public string PictureUrl { get; set; }
        public string Room { get; set; }
        public string Description { get; set; }

        [InverseProperty("TeacherProfile")]
        public virtual ApplicationUser Teacher { get; set; }
    }
}