using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VC.Services.Interfaces;
using VC.Services.Models;
using VideoCave.Models;

namespace VideoCave.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchService _searchService;

        public HomeController(ISearchService searchService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _searchService = searchService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Home/Details/{id}")]
        public IActionResult Details(string id)
        {
            var video = _searchService.ObterVideo(id);

            return View(video);
        }

        [HttpPost]
        public IActionResult Search(SearchParametersViewModel model)
        {
            var videos = _searchService.Procurar(model);
            ViewData["searchText"] = model.SearchType.ToString();
            return View(videos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}