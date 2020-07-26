using eCommerce_Core_Model;
using eCommerce_Core_Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce_MVC.Controllers
{
    public class HomeController : ECControllerBase
    {
        EcDB db = new EcDB();
        // GET: Home

        public ActionResult Index()
        {
            ViewBag.IsLogin = this.IsLogin;
            //var data = db.Products.OrderByDescending(x => x.CreateDate).Take(5).ToList();
            var data = db.Products.OrderByDescending(x => x.CreateDate).ToList();
            return View(data);
        }
        public PartialViewResult GetMenu()
        {
           
            var menus = db.Categories.Where(x => x.ParentID == 0);
            return PartialView(menus);
        }
        [Route("Uye-Giris")]
        public ActionResult Login()
        {
          
            return View();
        }

        [HttpPost]
        [Route("Uye-Giris")]

        public ActionResult Login(string Email , string Password)
        {
           
            var users = db.Users.Where(x => x.Email == Email
            && x.Password == Password
            && x.IsActive == true
            && x.IsAdmin == false).ToList();

            if (users.Count == 1)
            {
                Session["LoginUserID"] = users.FirstOrDefault().ID;
                Session["LoginUser"] = users.FirstOrDefault();
                return Redirect("/");
            }
            else
            {
                ViewBag.Error = "Hatalı Kullanıcı veya Şifre!"; //controller ve sayfa arası veri taşımak için kullanılır
                return View();
            }
        }
        [Route("Uye-Kayit")]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [Route("Uye-Kayit")]
        public ActionResult CreateUser(User entity)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.CreateUserID = 1;
                entity.IsActive = true;
                entity.IsAdmin = false;

                db.Users.Add(entity);
                db.SaveChanges();
                return Redirect("/Uye-Kayit");
            }
            catch (Exception)
            {
                return View();
            }
            
        }
   
        public ActionResult Cikis()
        {
            Session.Clear();//session temizlendi , çıkış yapıldı.

            return Redirect("/");//anasayfaya yönlendir
        }

    }
}