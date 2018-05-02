using Newtonsoft.Json;
using STO.Domain.Concrete;
using STO.Domain.Entities;
using STO.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using STO.WebUI.Filters;


namespace STO.WebUI.Controllers
{
    [Culture]
    public class NavigationController : Controller
    {
        EFDbContext db = new EFDbContext("EFDbContext");

        [HttpGet]
        [ChildActionOnly]
        public ActionResult PViewTotalPrice()
        {
            int count = Convert.ToInt32(WebConfigurationManager.AppSettings["ListLastCars"]);
            List<TotalPrice> totalPrices = db.TotalPrices.OrderByDescending(o => o.Date)
                .Include(c => c.Car).Take(count)
                .ToList();
            ViewData["ListLastCars"] = count;
            return PartialView("PViewTotalPrice", totalPrices);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            TotalPrice totalPrice = db.TotalPrices
                .Include(c => c.Car.TypeCar)
                .Include(l => l.CalculateCost.Select(cc => cc.TypeService.Service))
                //.OrderBy(s => s.CalculateCost.OrderBy(t => t.TypeService.Service.IsAddService))
                .FirstOrDefault(p => p.Id == id);
            ViewBag.IsContainAddService =
                totalPrice?.CalculateCost.FirstOrDefault(s => s.TypeService.Service.IsAddService) != null;
            totalPrice?.CalculateCost.OrderBy(s => s.TypeService.Service.IsAddService);
            return View(totalPrice);
        }

        public ActionResult Language()
        {
            return PartialView("ChangeLanguage");
        }

        public ActionResult ChangeLanguage(string lang)
        {
            // Список культур
            List<string> cultures = new List<string>() { "ru", "en" };
            if (!cultures.Contains(lang))
            {
                lang = "ru";
            }
            // Сохраняем выбранную культуру в куки
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;   // если куки уже установлено, то обновляем значение
            else
            {
                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(Request.UrlReferrer?.AbsolutePath);  /*PartialView(); *///Redirect(Request.UrlReferrer.AbsolutePath);
        }
    }
}