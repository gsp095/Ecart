using DAL;
using DAL.Repository;
using MachineTestNimap_Amol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MachineTestNimap_Amol.Controllers
{
    public class CategoryController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddUpdateCategory(int id = 0)
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            if (id > 0)
            {
                var category = unitOfWork.categoryRepository.Get(s => s.CategoryId == id);
                categoryViewModel.CategoryName = category.CategoryName;
                categoryViewModel.CategoryId =  category.CategoryId;
            }
            return View(categoryViewModel);
        }

        [HttpPost]
        public ActionResult AddUpdateCategory(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                if (categoryViewModel.CategoryId > 0)
                {
                    var updateCategory = unitOfWork.categoryRepository.Get(s => s.CategoryId == categoryViewModel.CategoryId);

                    updateCategory.CategoryName = categoryViewModel.CategoryName;
                 
                    unitOfWork.categoryRepository.Update(updateCategory);
                }
                else
                {
                    CategoryMaster categoryMaster = new CategoryMaster();
                    categoryMaster.CategoryName = categoryViewModel.CategoryName;
                    unitOfWork.categoryRepository.Add(categoryMaster);

                }
                unitOfWork.categoryRepository.Save();
            }
            return View(categoryViewModel);
        }
    }
}