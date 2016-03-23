using CourseManagement.Models;
using CourseManagement;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Controllers
{
    public class BaseController : Controller
    {    
        protected ApplicationDbContext db = new ApplicationDbContext();
        protected RoleManager<IdentityRole> roleManager;
        private ApplicationUserManager _userManager;

        public BaseController()
        {          
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        }

        protected ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        protected ApplicationUser GetUserInfo()
        {           
            return db.Users.Find(User.Identity.GetUserId());

        }

      
        //public UserRole GetRole()
        //{
        //    string roleId = UserManager.FindById(GetUserInfo().Id).Roles.First().RoleId;           
        //    return (UserRole)Enum.Parse(typeof(UserRole), roleManager.FindById(roleId).Name);
        //}


        //public UserRole? GetRole(string userId)
        //{
        //    if (userId == null)
        //        return null;

        //    string roleId = UserManager.FindById(userId).Roles.First().RoleId;
        //    return (UserRole)Enum.Parse(typeof(UserRole), roleManager.FindById(roleId).Name);
        //}

        //public string GetRoleString(string userId)
        //{
        //    string roleId = UserManager.FindById(userId).Roles.First().RoleId;
        //    return roleManager.FindById(roleId).Name;
        //}

        //public IEnumerable<ApplicationUser> GetDevelopers()
        //{           
        //    return db.Database.SqlQuery<ApplicationUser>("EXEC GetDevelopers");
        //}

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();

            base.Dispose(disposing);
        }
    }
}