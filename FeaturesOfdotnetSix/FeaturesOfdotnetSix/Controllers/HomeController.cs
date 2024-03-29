﻿using FeaturesOfdotnetSix.Models;
using FeaturesOfdotnetSix.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FeaturesOfdotnetSix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService emailService;

        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            this.emailService = emailService;
        }

        public IActionResult Index()
        {
            _logger.LogInformation($"Home.Index çalıştı.");
            ViewBag.Title = "Burası anasayfa";
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