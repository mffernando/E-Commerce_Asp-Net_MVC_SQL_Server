using ECommerce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ECommerce.Class
{
    public class UserHelper
    {
        public class UsersHelper : IDisposable
        {
            private static ApplicationDbContext userContext = new ApplicationDbContext();
            private static ECommerceContext db = new ECommerceContext();

            //delete user
            public static Boolean DeleteUser(string userName)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
                var userASP = userManager.FindByEmail(userName);

                if(userASP == null)
                {
                    return false; //if null
                }
                //delete user

                var response = userManager.Delete(userASP);
                return response.Succeeded; //return if ok

            }

            //update user
            public static Boolean UpdateUserName(string currentUserName, string newUserName)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
                var userASP = userManager.FindByEmail(currentUserName);

                if (userASP == null)
                {
                    return false; // if null
                }
                //update user name

                userASP.UserName = newUserName;
                userASP.Email = newUserName;
                var response = userManager.Update(userASP);
                return response.Succeeded; //return if ok

            }

            public static void CheckRole(string roleName)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(userContext));

                //check to see if Role exists, if not create it
                if (!roleManager.RoleExists(roleName))
                {
                    roleManager.Create(new IdentityRole(roleName));
                }
            }

            public static void CheckSuperUser()
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
                var email = WebConfigurationManager.AppSettings["AdminUser"];
                var password = WebConfigurationManager.AppSettings["AdminPassword"];
                var userASP = userManager.FindByName(email);

                if(userASP == null)
                {
                    CreateUserASP(email, "admin", password);
                    return;
                }

                userManager.AddToRole(userASP.Id, "Admin");

            }

            public static void CreaterUserASP(string email, string roleName)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));

                var userASP = new ApplicationUser
                {
                    Email = email,
                    UserName = email,
                };

                userManager.Create(userASP, email);
                userManager.AddToRole(userASP.Id, roleName);

            }

            public static void CreateUserASP(string email, string roleName, )
            {

            }

            public static async Task PasswordRecovery(string email)
            {

            }


        }
    }
}