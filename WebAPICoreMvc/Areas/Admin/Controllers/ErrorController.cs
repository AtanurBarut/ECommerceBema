using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAPICoreMvc.Models;

namespace WebAPICoreMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ErrorController : Controller
    {
        public IActionResult MyStatusCode(int code)
        {
            if (code == 404)
            {
                ViewBag.ErrorMessage = "Sayfa Bulunamadı!";
                return RedirectToAction("Error404", "Error", new { area = "Admin" });
            }
            if (code == 500)
            {
                ViewBag.ErrorMessage = "Sunucu Hatası!";
                return RedirectToAction("InternalServerError500", "Error", new { area = "Admin" });
            }
            if (code == 401)
            {
                ViewBag.ErrorMessage = "Yetkisiz Erişim!";
                return RedirectToAction("Unauthorize401", "Error", new { area = "Admin" });
            }
            if (code == 400)
            {
                ViewBag.ErrorMessage = "Geçersiz İstek!";
                return RedirectToAction("BadRequest400", "Error", new { area = "Admin" });
            }
            else
            {
                ViewBag.ErrorMessage = "İşleminiz Gerçekleştirilirken bir hata oluştu!";
            }
            ViewBag.ErrorStatusCode = code;
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }
        public IActionResult InternalServerError500()
        {
            return View();
        }
        public IActionResult Unauthorize401()
        {
            return View();
        }
        public IActionResult BadRequest400()
        {
            return View();
        }
    }
}
