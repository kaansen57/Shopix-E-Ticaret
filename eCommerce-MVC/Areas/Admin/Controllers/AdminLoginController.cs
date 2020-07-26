using eCommerce_Core_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce_MVC.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Admin/AdminLogin

        EcDB db = new EcDB();


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Email, string Password)
                {
            var data = db.Users.Where(x => x.Email == Email 
            && x.Password == Password
            && x.IsActive == true 
            && x.IsAdmin == true).ToList(); // admin kontrolü
        
            if (data.Count == 1)
            {
                //doğru giriş
                Session["AdminLoginUser"] = data.FirstOrDefault();
                return Redirect("/admin");
            }
            else
            {
                //hatalı giriş
                return View();
            }

        }
    }
}