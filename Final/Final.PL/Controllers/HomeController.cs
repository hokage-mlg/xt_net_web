using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final.Ioc;
using Final.Entities;
namespace Final.PL.Controllers
{
    public class HomeController:Controller
    {
        public ActionResult ShowAllBooks()
        {
            var allbooks = Ioc.DependencyResolver.BookLogic.GetAll();
            ViewBag.books = allbooks;
            return View();
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            Ioc.DependencyResolver.PurchaseLogic.Add(purchase);
            Ioc.DependencyResolver.PurchaseLogic.Update(purchase);
            return "Спасибо," + User.Identity.Name + ", за покупку!";
        }             
    }
}