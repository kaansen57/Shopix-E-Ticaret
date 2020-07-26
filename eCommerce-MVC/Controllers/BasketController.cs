using eCommerce_Core_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce_MVC.Controllers
{
    public class BasketController :ECControllerBase 
    {
        // GET: Basket
        EcDB db = new EcDB();
        [HttpPost]
        public JsonResult AddProduct(int productID,int quantity)
        {
            
            db.Baskets.Add(new eCommerce_Core_Model.Entity.Basket
            {
                CreateDate = DateTime.Now,
                CreateUserID = LoginUserID,
                UserID = LoginUserID,
                ProductID = productID,
                Quantity = quantity
            });
            var rt  = db.SaveChanges();
            return Json(rt, JsonRequestBehavior.AllowGet);
        }

        [Route("Sepetim")]
        public ActionResult Index()
        {
            var data = db.Baskets.Include("Product").Where(x => x.UserID == LoginUserID).ToList();
            return View(data);
        }
        public ActionResult Delete(int ID)
        {
            var deleteData = db.Baskets.Where(x => x.ID == ID).FirstOrDefault();
            db.Baskets.Remove(deleteData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
            
            }
}