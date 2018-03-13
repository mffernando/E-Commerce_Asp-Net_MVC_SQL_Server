using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Class
{
    public class ComboHelper : IDisposable
    {
        //DB
        private static ECommerceContext db = new ECommerceContext();

        //Ordening the Departments
        public static List<Departments> GetDepartments() { //start list

        //list Departments from DB
        var dep = db.Departments.ToList();
        dep.Add(new Departments{
                DepartmentsId = 0,
                Name = "[ Department Select ] " //[ ] first in the list
            });

            return dep = dep.OrderBy(d => d.Name).ToList();
} //end list

        //Ordening the Cities
        public static List<City> GetCities()
        { //start list

            //list Departments from DB
            var dep = db.Cities.ToList();
            dep.Add(new City
            {
                CityId = 0,
                Name = "[ City Select ] " //[ ] first in the list
            });

            return dep = dep.OrderBy(d => d.Name).ToList();
} //end list

        public void Dispose()
            {
                db.Dispose();
            }
        }
    }