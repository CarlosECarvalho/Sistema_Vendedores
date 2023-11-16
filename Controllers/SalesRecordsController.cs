using Humanizer;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRedcordService;

        public SalesRecordsController (SalesRecordService salesRedcordService)
        {
            _salesRedcordService = salesRedcordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? min, DateTime? max)
        {
            if (!min.HasValue)
            {
                min = new (DateTime.Now.Year, 1, 1);
            }
            if(!max.HasValue)
            {
                max = DateTime.Now;
            }
            ViewData["min"] = min.Value.ToString("yyyy-MM-dd");
            ViewData["max"] = max.Value.ToString("yyyy-MM-dd");
            var result = await _salesRedcordService.FindByDateAsync(min, max);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? min, DateTime? max)
        {
            if (!min.HasValue)
            {
                min = new(DateTime.Now.Year, 1, 1);
            }
            if (!max.HasValue)
            {
                max = DateTime.Now;
            }
            ViewData["min"] = min.Value.ToString("yyyy-MM-dd");
            ViewData["max"] = max.Value.ToString("yyyy-MM-dd");
            var result = await _salesRedcordService.FindByDateGroupingAsync(min, max);
            return View(result);
        }
    }
}
