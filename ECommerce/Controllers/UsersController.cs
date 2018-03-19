using ECommerce.Class;
using ECommerce.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class UsersController : Controller
    {
        private ECommerceContext db = new ECommerceContext();

        //list view cascade
        //select a department and list cities specific from that department
        public JsonResult GetCities(int DepId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var cities = db.Cities.Where(c => c.DepartmentsId == DepId);
            return Json(cities);
        }

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Cities).Include(u => u.Companies).Include(u => u.Departments);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(ComboHelper.GetCities(), "CityId", "Name");
            ViewBag.CompanyId = new SelectList(ComboHelper.GetCompanies(), "CompanyId", "Name");
            ViewBag.DepartmentsId = new SelectList(ComboHelper.GetDepartments(), "DepartmentsId", "Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {

                db.Users.Add(user);
                db.SaveChanges();

                if (user.PhotoFile != null)
                {
                    //configuring the logo path
                    var pic = string.Empty;
                    var folder = "~/Content/Users/";
                    //configuring the logo path
                    var file = string.Format("{0}.jpg", user.UserId);

                    var response = FileHelper.PhotoUpload(user.PhotoFile, folder, file);
                    if (response == true)
                    {
                        pic = string.Format("{0}{1}", folder, file);
                        user.Photo = pic;
                    }
                    //{0} = path (~/Content/Users/)
                    //{1} = archive name
                }
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(ComboHelper.GetCities(), "CityId", "Name", user.CityId);
            ViewBag.CompanyId = new SelectList(ComboHelper.GetCompanies(), "CompanyId", "Name", user.CompanyId);
            ViewBag.DepartmentsId = new SelectList(ComboHelper.GetDepartments(), "DepartmentsId", "Name", user.DepartmentsId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(ComboHelper.GetCities(), "CityId", "Name", user.CityId);
            ViewBag.CompanyId = new SelectList(ComboHelper.GetCompanies(), "CompanyId", "Name", user.CompanyId);
            ViewBag.DepartmentsId = new SelectList(ComboHelper.GetDepartments(), "DepartmentsId", "Name", user.DepartmentsId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {

                if (user.PhotoFile != null)
                {
                    //configuring the logo path
                    var pic = string.Empty;
                    var folder = "~/Content/Users/";
                    //configuring the logo path
                    var file = string.Format("{0}.jpg", user.UserId);

                    var response = FileHelper.PhotoUpload(user.PhotoFile, folder, file);
                    if (response == true)
                    {
                        pic = string.Format("{0}{1}", folder, file);
                        user.Photo = pic;
                    }
                    //{0} = path (~/Content/Users/)
                    //{1} = archive name
                }
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(ComboHelper.GetCities(), "CityId", "Name", user.CityId);
            ViewBag.CompanyId = new SelectList(ComboHelper.GetCompanies(), "CompanyId", "Name", user.CompanyId);
            ViewBag.DepartmentsId = new SelectList(ComboHelper.GetDepartments(), "DepartmentsId", "Name", user.DepartmentsId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
