using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync(); //recebo a lista de vendedores
            return View(list); //passo a lista para a view
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync(); //carrego os departamentos
            var viewModel = new SellerFormViewModel { Departments = departments };//carrego a lista de departamentos na view
            return View(viewModel); //carrego a view para o create
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            if (ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments};
                return View(viewModel);
            }
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index)); //retorno para a pagina index usando o nameof caso a página troque de nome
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Forneça o Id para este procedimento."});
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id fornecido não existe."});
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sellerService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException ex) 
            { 
                return RedirectToAction(nameof(Error), new { ex.Message }); 
            }
            
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Forneça o Id para este procedimento."});
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id fornecido não existe."});
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Forneça o Id para este procedimento." });
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id fornecido não existe." });
            }
            List<Department> departments = await _departmentService.FindAllAsync();
            SellerFormViewModel viewmodel = new() { Seller = obj, Departments = departments };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, Seller seller)
        {   
            if (!ModelState.IsValid)
            {
                var departments =  await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            if(id != seller.SellerID)
            {
                return RedirectToAction(nameof(Error), new { message = "O Id fornecido não corresponde ao vendedor informado." });
            }
            try
            {
                
                await _sellerService.UpdateAsync(seller); //recebo o ID e o vendedor atualizo e retorno ao Index
                return RedirectToAction(nameof(Index));
            }catch (ApplicationException e) 
            { 
                return RedirectToAction(nameof(Error), new { e.Message }); 
            }


        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel 
            {
                Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            };
            return View(viewModel);
        }
    }
}
