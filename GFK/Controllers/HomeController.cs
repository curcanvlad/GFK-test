using Microsoft.AspNetCore.Mvc;
using GFK.Services;


namespace GFK.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TwitterApi _twitterApi;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _twitterApi = new TwitterApi("uXsW4M7Q4M2zoDddLxRHoAt04", "h104iVd1Y0xnrdaj2B4oYpEpDFrK1iPiNaAqJekbhEOmQxTKIR", "1643370976070057986-LmCYF4ipYyTvhViWY41UwewUvo4QRZ", "5HtXMVhnUFxzQDeIZejHcfcFZXbo7BR8qq0QRwF8XEOpp");
        }

        public async Task<IActionResult> Index(string query, bool onlyWithImages = false)
        {
            if (!string.IsNullOrEmpty(query))
            {
                ViewBag.Tweets = await _twitterApi.SearchTweetsAsync(query, onlyWithImages);
            }

            return View();
        }
    }
}
