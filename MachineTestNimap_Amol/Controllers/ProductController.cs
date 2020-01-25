using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Repository;
using DAL.Repository.IRepository;
using MachineTestNimap_Amol.Models;

namespace MachineTestNimap_Amol.Controllers
{
    public class ProductController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
       
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddUpdateProduct(int id=0)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            if (id > 0)
            {
              var product=  unitOfWork.productRepository.Get(s => s.ProductId == id);
                productViewModel.ProductName = product.ProductName;
                productViewModel.CategoryId = product.CategoryId;
                productViewModel.Price = product.Price;
                productViewModel.ProductId = product.ProductId;
                
            }
            ViewBag.CategoryList = unitOfWork.categoryRepository.GetAll();
           
            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult AddUpdateProduct(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                if (productViewModel.ProductId > 0)
                {
                    var updateProduct = unitOfWork.productRepository.Get(s => s.ProductId == productViewModel.ProductId);

                    updateProduct.ProductName = productViewModel.ProductName;
                    updateProduct.CategoryId = productViewModel.CategoryId;
                    updateProduct.Price = productViewModel.Price;
                    unitOfWork.productRepository.Update(updateProduct);
                }
                else
                {
                    ProductMaster productMaster = new ProductMaster();
                    productMaster.ProductName = productViewModel.ProductName;
                    productMaster.CategoryId = productViewModel.CategoryId;
                    productMaster.Price = productViewModel.Price;
                    unitOfWork.productRepository.Add(productMaster);

                }
                unitOfWork.productRepository.Save();
            }
            ViewBag.CategoryList = unitOfWork.categoryRepository.GetAll();
            return View(productViewModel);
        }

    }
}