using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index)); //retorno para a pagina index usando o nameof caso a página troque de nome
        }
    }
}
