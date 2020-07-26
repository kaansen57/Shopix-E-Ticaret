using eCommerce_Core_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce_MVC.Controllers
{
    public class CategoryController : ECControllerBase
    {
        // GET: Category
        [Route("Kategori/{isim}/{id}")]
        public ActionResult Index(string isim , int id)//kategori ID
        {
            var db = new EcDB();
            var data = db.Products.Where(x => x.IsActive == true &&
                                   x.CategoryID == id).ToList();
            ViewBag.category = db.Categories.Where(x => x.ID == id).FirstOrDefault();

            return View(data);
        }
    }
}