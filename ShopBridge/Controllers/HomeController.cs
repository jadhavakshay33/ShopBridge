using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBridge.Models;

namespace ShopBridge.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult CoponentHomePage()
        {
            ShopBridgeEntities db = new ShopBridgeEntities();
            var item = db.components.Select(u => u).ToList();

            return View(item);
        }


        [HttpGet]
        [Route("AddComponent")]
        public ActionResult AddComponent()
        {
            return View();
        }
        [HttpPost]
        [Route("AddComponent")]
        public ActionResult AddComponent(component model, HttpPostedFileBase Image1)
        {
            var db = new ShopBridgeEntities();

            if (model.Discription != null && model.Name != null && model.Price != 0 && Image1 != null)
            {
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(Image1.InputStream))
                {
                    bytes = br.ReadBytes(Image1.ContentLength);

                }


                db.components.Add(new component
                {
                    Name = model.Name,
                    Price = model.Price,
                    Image = bytes,
                    Discription = model.Discription
                });
                db.SaveChanges();
                return RedirectToAction("CoponentHomePage");

            }
            return View();
        }


    }
}
