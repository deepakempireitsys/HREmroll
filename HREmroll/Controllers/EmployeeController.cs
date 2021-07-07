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
using Microsoft.AspNetCore.Hosting;


namespace HREmroll.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _configuration;

        private IWebHostEnvironment _env;
        public EmployeeController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;

        }
        public IActionResult GetAllEmployee()
        {
            EmployeeRepository objRepo = new EmployeeRepository(_configuration);
            return View(objRepo.GetAllEmployees());
        }

        public IActionResult GetActiveEmployee()
        {
            EmployeeRepository objRepo = new EmployeeRepository(_configuration);
            return View(objRepo.GetActiveEmployees());
        }


        public IActionResult GetInActiveEmployee()
        {
            EmployeeRepository objRepo = new EmployeeRepository(_configuration);
            return View(objRepo.GetInActiveEmployees());
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
            //return PartialView("_EmpPersonalDetails");



        }

        [HttpPost]
      
        public IActionResult AddEmployee(Employee obj, IFormFile files)
        {
            try
            {
                
                obj.CREATED_BY = 1;
                obj.CREATED_DATE = DateTime.Now;
                obj.MODIFIED_BY = 1;    
                obj.MODIFIED_DATE = DateTime.Now;
                ModelState.Remove("CREATED_DATE");  
                ModelState.Remove("MODIFIED_DATE");
               
                
                if (ModelState.IsValid)
                {

                    if (files != null)
                    {
                        if (files.Length > 0)
                        {
                            //Getting FileName
                            var fileName = Path.GetFileName(files.FileName);
                            //Getting file Extension
                            var fileExtension = Path.GetExtension(fileName);
                            // concatenating  FileName + FileExtension
                            var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);


                            obj.IMAGE_NAME = newFileName;
                            obj.IMAGE_TYPE = fileExtension;
                            obj.IMAGE_EXT = fileExtension;

                            var webRoot = _env.WebRootPath;

                            obj.IMAGE_PATH = @"\IMAGES\" + obj.IMAGE_NAME;



                            using (var target = new MemoryStream())
                            {
                                files.CopyTo(target);
                                obj.IMAGE_BLOB = target.ToArray();

                            }


                            using (var fileStream = new FileStream(System.IO.Path.Combine(webRoot, "IMAGES") + @"\" + obj.IMAGE_NAME, FileMode.Create))
                            {
                                files.CopyTo(fileStream);
                            }



                        }
                    }
                    else
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
                        ViewBag.imagenotupload = "Please upload image";
                        return View();
                    }
               
                    //obj.BRANCH_NAME = "Default";

                    EmployeeRepository objRepo = new EmployeeRepository(_configuration);

                    objRepo.AddEmployee(obj);

                    ViewBag.Message = "Records added successfully.";

                    return RedirectToAction("GetAllEmployee");
                }
                else
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

            }
            catch
            {
                return View();
            }
        }


        // GET: Bind controls to Update details      
        public IActionResult EditEmployee(int id)
        {
            EmployeeRepository objRepo = new EmployeeRepository(_configuration);
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
            Employee obj = objRepo.GetByID(id);


            string imreBase64Data = Convert.ToBase64String(obj.IMAGE_BLOB);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);

            ViewBag.ImageData = imgDataURL;
            return View(obj);

        }

        // POST:Update the details into database      
        [HttpPost]
        public IActionResult EditEmployee(Employee obj, IFormFile files)
        {
            try
            {
                //var objfiles = new CmpIMAGE();
                if (files != null)
                {
                    if (files.Length > 0)
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(files.FileName);
                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);
                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);


                        obj.IMAGE_NAME = newFileName;
                        obj.IMAGE_TYPE = fileExtension;
                        obj.IMAGE_EXT = fileExtension;

                        var webRoot = _env.WebRootPath;
                        //obj.IMAGE_PATH = System.IO.Path.Combine(webRoot, "IMAGES") + @"\" + obj.IMAGE_NAME;
                        obj.IMAGE_PATH = @"\IMAGES\" + obj.IMAGE_NAME;



                        using (var target = new MemoryStream())
                        {
                            files.CopyTo(target);
                            obj.IMAGE_BLOB = target.ToArray();

                        }
                        //using (var fileStream = new FileStream(Path.Combine(obj.IMAGE_PATH,newFileName), FileMode.Create))
                        //using (var fileStream = new FileStream(obj.IMAGE_PATH, FileMode.Create))
                        using (var fileStream = new FileStream(System.IO.Path.Combine(webRoot, "IMAGES") + @"\" + obj.IMAGE_NAME, FileMode.Create))
                        {
                            files.CopyTo(fileStream);
                        }



                    }
                }


                //obj.CREATED_BY = 1;
                //obj.CREATED_DATE = DateTime.Now;
                obj.MODIFIED_BY = 1;
                obj.MODIFIED_DATE = DateTime.Now;

                EmployeeRepository objRepo = new EmployeeRepository(_configuration);

                objRepo.UpdateEmployee(obj);

                return RedirectToAction("GetAllEmployee");
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete  Branch details by id      
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                EmployeeRepository objRepo = new EmployeeRepository(_configuration);
                if (objRepo.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Employee deleted successfully";

                }
                return RedirectToAction("GetAllEmployee");
            }
            catch
            {
                return RedirectToAction("GetAllEmployee");

            }


        }

        //public IActionResult EmpDetails()
        //{
        //    return PartialView("_EmpPersonalDetails");


        //}




    }
}

