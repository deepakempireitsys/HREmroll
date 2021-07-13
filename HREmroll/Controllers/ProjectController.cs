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
    public class ProjectController : Controller
    {

        private readonly IConfiguration _configuration;

        public ProjectController(IConfiguration configuration)
        {
            //_logger = logger;
            _configuration = configuration;
        }
        
        public IActionResult GetAllProjects()
        {
            ProjectRepository objRepo = new ProjectRepository(_configuration);
            return View(objRepo.GetAllProjects());
        }

        public IActionResult GetActiveProjects()
        {
            ProjectRepository objRepo = new ProjectRepository(_configuration);
            return View(objRepo.GetActiveProjects());
        }

        public IActionResult GetInActiveProjects()
        {
            ProjectRepository objRepo = new ProjectRepository(_configuration);
            return View(objRepo.GetInActiveProjects());
        }
        // GET: Branch/AddBranch      
        public ActionResult AddProject()
        {
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();
            return View();
        }

        // POST: Branch/AddBranch      
        [HttpPost]
        public IActionResult AddProject(Project obj)
        {
            try
            {
                ModelState.Remove("PROJECT_ID");
                ModelState.Remove("CREATED_DATE");
                ModelState.Remove("MODIFIED_DATE");

                if (ModelState.IsValid)
                {
                    obj.CREATED_BY = 1;
                    obj.CREATED_DATE = DateTime.Now;
                    obj.MODIFIED_BY = 1;
                    obj.MODIFIED_DATE = DateTime.Now;

                    //if (ModelState.IsValid)
                    //{
                    //    
                    //
                    //}
                    ProjectRepository objRepo = new ProjectRepository(_configuration);

                    objRepo.AddProject(obj);

                    ViewBag.Message = "Records added successfully.";

                    return RedirectToAction("GetAllProjects");
                    // return View("GetAllProjects");
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
        public IActionResult EditProject(int id)
        {
            ProjectRepository objRepo = new ProjectRepository(_configuration);
            //Project obj = objRepo.GetAllProjects().Find(obj => obj.PROJECT_ID == id);
            Project obj = objRepo.GetByID(id);
            //return View(EmpRepo.GetAllBranchs().Find(Emp => Emp. == id));
            HREmroll.Repository.BranchRepository br = new BranchRepository(_configuration);

            ViewBag.data = br.GetAllBranchs();
            return View(obj);

        }

        // POST:Update the details into database      
        [HttpPost]
        public IActionResult EditProject(Project obj1)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProjectRepository objRepo = new ProjectRepository(_configuration);

                    objRepo.UpdateProject(obj1);

                    return RedirectToAction("GetAllProjects");
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
        public IActionResult DeleteProject(int id)
        {
            try
            {
                ProjectRepository objRepo = new ProjectRepository(_configuration);
                if (objRepo.DeleteProject(id))
                {
                    ViewBag.AlertMsg = "Project deleted successfully";

                }
                return RedirectToAction("GetAllProjects");
            }
            catch
            {
                return RedirectToAction("GetAllProjects");

            }


        }
    }
}
