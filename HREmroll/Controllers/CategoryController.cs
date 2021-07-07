using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HREmroll.Models;
using HREmroll.Repository;
using Microsoft.Extensions.Configuration;

namespace HREmroll.Controllers
{
    public class CategoryController : Controller
    {

        //public IActionResult Test()
        //{
        //    return View();
        //}

        // GET: Branch/GetAllBranchs      
        //private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;


        public CategoryController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }

        public IActionResult GetAllCategorys()
        {
            CategoryRepository objRepo = new CategoryRepository(_configuration);
            return View(objRepo.GetAllCategorys());
        }

        public IActionResult GetActiveCategorys()
        {
            CategoryRepository objRepo = new CategoryRepository(_configuration);
            return View(objRepo.GetActiveCategorys());
        }

        public IActionResult GetInActiveCategorys()
        {
            CategoryRepository objRepo = new CategoryRepository(_configuration);
            return View(objRepo.GetInActiveCategorys());
        }
        // GET: Branch/AddBranch      
        public ActionResult AddCategory()
        {
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();
            return View();
        }

        // POST: Branch/AddBranch      
        [HttpPost]
        public IActionResult AddCategory(Category obj)
        {
            try
            {
                
                ModelState.Remove("CATEGORY_ID");
                ModelState.Remove("CREATED_DATE");
                ModelState.Remove("MODIFIED_DATE");
                if (ModelState.IsValid)
                {
                    obj.CREATED_BY = 1;
                    obj.CREATED_DATE = DateTime.Now;
                    obj.MODIFIED_BY = 1;
                    obj.MODIFIED_DATE = DateTime.Now;
                    obj.BRANCH_NAME = "Default";
                    //if (ModelState.IsValid)
                    //{
                    //    
                    //
                    //}
                    CategoryRepository objRepo = new CategoryRepository(_configuration);

                    objRepo.AddCategory(obj);

                    ViewBag.Message = "Records added successfully.";

                    return RedirectToAction("GetAllCategorys");
                    // return View("GetAllCategorys");
                }
                else
                {
                    HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

                    ViewBag.data = br.GetAllBranchs();
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Bind controls to Update details      
        public IActionResult EditCategory(int id)
        {
            CategoryRepository objRepo = new CategoryRepository(_configuration);
            //Category obj = objRepo.GetAllCategorys().Find(obj => obj.CATEGORY_ID == id);
            Category obj = objRepo.GetByID(id);
            //return View(EmpRepo.GetAllBranchs().Find(Emp => Emp. == id));
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();
            return View(obj);

        }

        // POST:Update the details into database      
        [HttpPost]
        public IActionResult EditCategory(Category obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryRepository objRepo = new CategoryRepository(_configuration);

                    objRepo.UpdateCategory(obj);

                    return RedirectToAction("GetAllCategorys");
                }
                else
                {
                    HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

                    ViewBag.data = br.GetAllBranchs();
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete  Branch details by id      
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                CategoryRepository objRepo = new CategoryRepository(_configuration);
                if (objRepo.DeleteCategory(id))
                {
                    ViewBag.AlertMsg = "Category deleted successfully";

                }
                return RedirectToAction("GetAllCategorys");
            }
            catch
            {
                return RedirectToAction("GetAllCategorys");

            }


        }
    }
}
