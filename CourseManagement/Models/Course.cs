using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CourseManagement.Models
{
    public enum Days { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

    public class Course
    {
        public Course()
        {
            Students = new HashSet<ApplicationUser>();
            CourseStudents = new HashSet<CourseStudent>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public HashSet<Days> LectureDays { get; set; }
        public string TeacherId { get; set; }
        public DateTimeOffset? ExamDate { get; set; }
        public string ExamRoom { get; set; }

        [InverseProperty("TaughtCourses")]
        public virtual ApplicationUser Teacher { get; set; }
        [InverseProperty("TakenCourses")]
        public virtual ICollection<ApplicationUser> Students { get; set; }
        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
    }
}