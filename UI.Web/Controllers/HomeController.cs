using Core.Abstracts.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Web.Models;

namespace UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostService service;
        public HomeController(ILogger<HomeController> logger, IPostService service)
        {
            this.service = service;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View(await service.GetAllAsync());
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
