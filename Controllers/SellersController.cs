using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService; 

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService; //injeto dependencia com o SellerService
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll(); //recebo a lista de vendedores
            return View(list); //passo a lista para a view
        }
    }
}
