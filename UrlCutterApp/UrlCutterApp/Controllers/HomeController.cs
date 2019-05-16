using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UrlCutterApp.Interfaces;
using UrlCutterApp.Models;

namespace UrlCutterApp.Controllers
{
    public class HomeController : Controller
    {
        
        IRandomGenerator generator;
        IUrlService db;
        public HomeController(IUrlService service,IRandomGenerator randomGenerator)
        {
            db = service;
            generator = randomGenerator;
        }
        public IActionResult Index()
        {
            IEnumerable<URLAdress> addresses = new List<URLAdress>();
            addresses = db.GetAll().ToList();
            return View(addresses);
        }

        [HttpPost]
        public IActionResult UrlCut(string longUrl)
        {
            
            URLAdress address = new URLAdress();
            address.LongUrl = longUrl;
            address.ShortUrl ="http://"+ generator.GetRandomURL();
            address.CountOfTransitions = 0;
            address.CreationDate = DateTimeOffset.Now;
            var result=db.Create(address);
            if (result)
            {
                IEnumerable<URLAdress> addresses = new List<URLAdress>();
                addresses = db.GetAll().ToList();
                return View("Index", addresses);
            }
            return View("Index");
        }

        
        public IActionResult UpdateUrl(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            URLAdress uRLAdress = new URLAdress();
            uRLAdress = db.GetOne(id);
            uRLAdress.CountOfTransitions++;
            db.Update(uRLAdress);
            return Redirect(uRLAdress.LongUrl);
        }

        [HttpPost]
        public IActionResult DeleteUrl(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            db.Delete(id);
            IEnumerable<URLAdress> addresses = new List<URLAdress>();
            addresses = db.GetAll();
            return View("Index", addresses);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
