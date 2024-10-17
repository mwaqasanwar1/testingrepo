using ASP_.net_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;  // Add this
using System.Diagnostics;

namespace ASP_.net_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;  // Inject the configuration

        // Modify the constructor to accept IConfiguration
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            // Get the dynamic message from appsettings.json
            string dynamicMessage = _configuration["AppSettings:DynamicMessage"];
            
            // Pass the dynamic message to the view using ViewData
            ViewData["DynamicMessage"] = dynamicMessage ?? "Default Message"; 
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
