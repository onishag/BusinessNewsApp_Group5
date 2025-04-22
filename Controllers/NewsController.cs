using Microsoft.AspNetCore.Mvc;
using BusinessNewsApp.Helpers;
using System.Threading.Tasks;

namespace BusinessNewsApp.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsApiHelper _newsApiHelper;

        public NewsController(NewsApiHelper newsApiHelper)
        {
            _newsApiHelper = newsApiHelper;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _newsApiHelper.GetTopBusinessNewsAsync();
            return View(articles);
        }
    }
}
