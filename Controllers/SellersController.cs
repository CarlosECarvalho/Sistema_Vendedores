using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services;
using SalesWebMVC.Services.Exceptions;
using System.Diagnostics;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService; //injeto dependencia com o SellerService
            _departmentService = departmentService; //injeto dependencia com o DepartmentService
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll(); //recebo a lista de vendedores
            return View(list); //passo a lista para a view
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll(); //carrego os departamentos
            var viewModel = new SellerFormViewModel { Departments = departments };//carrego a lista de departamentos na view
            return View(viewModel); //carrego a view para o create
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index)); //retorno para a pagina index usando o nameof caso a página troque de nome
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Forneça o Id para este procedimento."});
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id fornecido não existe."});
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Forneça o Id para este procedimento."});
            }
            var obj = _sellerService.FindById(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id fornecido não existe."});
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Forneça o Id para este procedimento." });
            }
            var obj = _sellerService.FindById(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id fornecido não existe." });
            }
            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewmodel = new SellerFormViewModel { Seller = obj, Departments = departments};
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (int id, Seller seller)
        {
            if(id != seller.SellerID)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id fornecido não corresponde ao vendedor informado." });
            }
            try
            {
                _sellerService.Update(seller); //recebo o ID e o vendedor atualizo e retorno ao Index
                return RedirectToAction(nameof(Index));
            }catch (ApplicationException e) 
            { 
                return RedirectToAction(nameof(Error), new { e.Message }); 
            }


        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel {Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(viewModel);
        }
    }
}
