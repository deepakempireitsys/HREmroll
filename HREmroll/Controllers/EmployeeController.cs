using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HREmroll.Models;
using HREmroll.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using HREmroll.Globals;
using System.IO;

namespace HREmroll.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }
        public IActionResult GetAllEmployee()
        {
            EmployeeRepository objRepo = new EmployeeRepository(_configuration);
            return View(objRepo.GetAllEmployees());
        }
        public IActionResult AddEmployee()
        {
            BranchRepository br = new BranchRepository(_configuration);
            GradeRepository Grade1 = new GradeRepository(_configuration);
            ShiftRepository Shift1 = new ShiftRepository(_configuration);
            DesignationRepository Desig = new DesignationRepository(_configuration);
            DepartmentRepository Dept = new DepartmentRepository(_configuration);
            CategoryRepository Cate = new CategoryRepository(_configuration);
            SubBranchRepository SubBr = new SubBranchRepository(_configuration);

            ViewBag.SBranch = SubBr.GetAllSBranch();
            ViewBag.Category = Cate.GetAllCategorys();
            ViewBag.Departments = Dept.GetAllDepartments();
            ViewBag.Designation = Desig.GetAllDesignation();
            ViewBag.Shift = Shift1.GetAll();
            ViewBag.Grade = Grade1.GetAllGrades();
            ViewBag.data = br.GetAllBranchs();
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee obj)
        {
            try
            {
                //if (files != null)
                //{
                //    if (files.Length > 0)
                //    {
                //        //Getting FileName
                //        var fileName = Path.GetFileName(files.FileName);
                //        //Getting file Extension
                //        var fileExtension = Path.GetExtension(fileName);
                //        // concatenating  FileName + FileExtension
                //        var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);


                //        obj.LOGO_NAME = newFileName;
                //        obj.LOGO_TYPE = fileExtension;
                //        obj.LOGO_EXT = fileExtension;

                //        var webRoot = _env.WebRootPath;
                //        obj.LOGO_PATH = System.IO.Path.Combine(webRoot, "IMAGES");



                //        using (var target = new MemoryStream())
                //        {
                //            files.CopyTo(target);
                //            obj.LOGO_BLOB = target.ToArray();

                //        }
                //        using (var fileStream = new FileStream(Path.Combine(obj.LOGO_PATH, newFileName), FileMode.Create))
                //        {
                //            files.CopyTo(fileStream);
                //        }



                //    }
                //}
                obj.CREATED_BY = 1;
                obj.CREATED_DATE = DateTime.Now;
                obj.MODIFIED_BY = 1;
                obj.MODIFIED_DATE = DateTime.Now;
                obj.BRANCH_NAME = "Default";
               
                EmployeeRepository objRepo = new EmployeeRepository(_configuration);

                objRepo.AddEmployee(obj);

                ViewBag.Message = "Records added successfully.";

                return RedirectToAction("GetAllEmployees");
               
            }
            catch
            {
                return View();
            }
        }
    }
}
