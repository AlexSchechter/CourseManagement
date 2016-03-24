using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagement.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public ApplicationUser()
        {
            CourseStudents = new HashSet<CourseStudent>();
            TaughtCourses = new HashSet<Course>();
            TakenCourses = new HashSet<Course>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Graduated { get; set; }
        public int TeacherProfileId { get; set; }

        [InverseProperty("Teacher")]
        public virtual TeacherProfile TeacherProfile { get; set; }
        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
        [InverseProperty("Teacher")]
        public virtual ICollection<Course> TaughtCourses{ get; set; }
        [InverseProperty("Students")]
        public virtual ICollection<Course> TakenCourses { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<IndividualLecture> IndividualLectures { get; set; }
        public DbSet<TeacherProfile> TeacherProfiles { get; set; }
    }
}