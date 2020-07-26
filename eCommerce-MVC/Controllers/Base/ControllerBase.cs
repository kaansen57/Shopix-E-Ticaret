using eCommerce_Core_Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eCommerce_MVC.Controllers
{
    public class ECControllerBase : Controller
    {
        //Kullanıcı Login Kontrolü
        public bool IsLogin { get; private set; }
        //****
        //Giriş yapanın ID'si
        public int LoginUserID { get; private set; }
        //****
        public User LoginUserEntity { get; private set; }

        protected override void Initialize(RequestContext requestContext)
        {
            
          
            if (requestContext.HttpContext.Session["LoginUserID"] != null)//giriş yapmışsa
            {
                IsLogin = true;
                LoginUserID = (int)requestContext.HttpContext.Session["LoginUserID"];
                LoginUserEntity = (eCommerce_Core_Model.Entity.User)requestContext.HttpContext.Session["LoginUser"];
            }

            base.Initialize(requestContext);
        }
    }
}