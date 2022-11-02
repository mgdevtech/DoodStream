using DoodStream.Code;
using DoodStream.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoodStream.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var upload = new UploadAPI("7284y4hyippga99ga745");
            var serverUrlData = upload.GetServerUrlUpload().Result;
            ViewBag.Url = serverUrlData.Result;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var upload = new UploadAPI("7284y4hyippga99ga745");
            var fileUpload = await upload.UploadFile(file);
            if (fileUpload == null)
                return NotFound();
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