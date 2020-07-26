using eCommerce_Core_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce_MVC.Controllers
{
    public class ProductController : ECControllerBase
    {
        // GET: Product

        [Route("Urun/{title}/{id}")]
        public ActionResult Detail(string title,int id)
        {
            var db = new EcDB();
            var product = db.Products.Where(x => x.ID == id).FirstOrDefault();
            return View(product);
        }
    }
}