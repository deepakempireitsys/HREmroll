
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
using System.IO;
using HREmroll.Globals;
using Microsoft.AspNetCore.Hosting;

namespace HREmroll.Controllers
{
    public class CompanyController : Controller
    {

        private readonly IConfiguration _configuration;
        private IWebHostEnvironment _env;


        public CompanyController(IConfiguration configuration, IWebHostEnvironment env)
        {
            //_logger = logger;
            _configuration = configuration;
            _env = env;
        }

        public ActionResult CompanyLogin()
        {
            CompanyRepository comprepo = new CompanyRepository(_configuration);

            ViewBag.data = comprepo.GetAllCompanys();
            return View();
        }
        [HttpPost]
        public IActionResult CompanyLogin(Company obj)
        {
            try
            {

                CompanyRepository comprepo = new CompanyRepository(_configuration);

                //= comprepo.GetByID(obj.CMP_ID);
                HttpContext.Session.SetString("CMP_ID", obj.CMP_ID.ToString());

                Company editobj = comprepo.GetByID(Convert.ToInt64(HttpContext.Session.GetString("CMP_ID")));
                //RedirectToAction("EditCompany", editobj);
                //ViewBag.data = comprepo.GetAllCompanys();
                return View("EditCompany", editobj);
                //return View("GetAllCompany");
                //CompanyRepository comprepo = new CompanyRepository(_configuration);

                //ViewBag.data = comprepo.GetAllCompanys();
                //return View();

            }
            catch
            {
                return View();
            }

        }
        public IActionResult GetAllCompany()
        {
            CompanyRepository objRepo = new CompanyRepository(_configuration);
            return View(objRepo.GetAllCompanys());
        }

        public IActionResult GetActiveCompany()
        {
            CompanyRepository objRepo = new CompanyRepository(_configuration);
            return View(objRepo.GetActiveCompanys());
        }


        public IActionResult GetInActiveCompany()
        {
            CompanyRepository objRepo = new CompanyRepository(_configuration);
            return View(objRepo.GetInActiveCompanys());
        }
        // GET: Branch/AddBranch      
        public ActionResult AddCompany()
        {
            //HREmroll.Repository.BranchRepository br = new BranchRepository();

            //ViewBag.data = br.GetAllBranchs();
            return View();
        }

        // POST: Branch/AddBranch      
        [HttpPost]
        public IActionResult AddCompany(Company obj, IFormFile files)
        {
            try
            {
                ModelState.Remove("CREATED_DATE");
                ModelState.Remove("MODIFIED_DATE");
                ModelState.Remove("CMP_ID");
                //obj.CREATED_DATE = DateTime.Now;
                //obj.MODIFIED_DATE = DateTime.Now;

                if (ModelState.IsValid)
                {
                    //var objfiles = new CmpLogo();
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


                            obj.LOGO_NAME = newFileName;
                            obj.LOGO_TYPE = fileExtension;
                            obj.LOGO_EXT = fileExtension;

                            var webRoot = _env.WebRootPath;
                            //obj.LOGO_PATH = System.IO.Path.Combine(webRoot, "IMAGES") + @"\" + obj.LOGO_NAME;
                            obj.LOGO_PATH = @"\IMAGES\" + obj.LOGO_NAME;



                            using (var target = new MemoryStream())
                            {
                                files.CopyTo(target);
                                obj.LOGO_BLOB = target.ToArray();

                            }
                            //using (var fileStream = new FileStream(Path.Combine(obj.LOGO_PATH,newFileName), FileMode.Create))
                            //using (var fileStream = new FileStream(obj.LOGO_PATH, FileMode.Create))
                            using (var fileStream = new FileStream(System.IO.Path.Combine(webRoot, "IMAGES") + @"\" + obj.LOGO_NAME, FileMode.Create))
                            {
                                files.CopyTo(fileStream);
                            }



                        }
                    }


                    obj.CREATED_BY = 1;
                    obj.CREATED_DATE = DateTime.Now;
                    obj.MODIFIED_BY = 1;
                    obj.MODIFIED_DATE = DateTime.Now;


                    CompanyRepository objRepo = new CompanyRepository(_configuration);

                    objRepo.AddCompany(obj);
                    //CmpLogoRepository logoRepo = new CmpLogoRepository(_configuration);
                    //logoRepo.AddCmpLogo(objfiles);
                    ViewBag.Message = "Records added successfully.";

                    return RedirectToAction("GetAllCompany");
                    // return View("GetAllCompany");
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                return View();
                throw ex;

            }
        }

        // GET: Bind controls to Update details      
        public IActionResult EditCompany(int id)
        {
            CompanyRepository objRepo = new CompanyRepository(_configuration);
            Company obj = objRepo.GetByID(id);
            //Company obj = objRepo.GetAllCompanys().Find(obj => obj.COMPANY_ID == id);
            //return View(EmpRepo.GetAllBranchs().Find(Emp => Emp. == id));
            //HREmroll.Repository.BranchRepository br = new BranchRepository();

            //ViewBag.data = br.GetAllBranchs();

            string imreBase64Data = Convert.ToBase64String(obj.LOGO_BLOB);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            //Passing image data in viewbag to view  
            ViewBag.ImageData = imgDataURL;
            return View(obj);

        }

        // POST:Update the details into database      
        [HttpPost]
        public IActionResult EditCompany(Company obj, IFormFile files)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var objfiles = new CmpLogo();
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


                            obj.LOGO_NAME = newFileName;
                            obj.LOGO_TYPE = fileExtension;
                            obj.LOGO_EXT = fileExtension;

                            var webRoot = _env.WebRootPath;
                            //obj.LOGO_PATH = System.IO.Path.Combine(webRoot, "IMAGES") + @"\" + obj.LOGO_NAME;
                            obj.LOGO_PATH = @"\IMAGES\" + obj.LOGO_NAME;

                            using (var target = new MemoryStream())
                            {
                                files.CopyTo(target);
                                obj.LOGO_BLOB = target.ToArray();

                            }
                            //using (var fileStream = new FileStream(Path.Combine(obj.LOGO_PATH,newFileName), FileMode.Create))
                            //using (var fileStream = new FileStream(obj.LOGO_PATH, FileMode.Create))
                            using (var fileStream = new FileStream(System.IO.Path.Combine(webRoot, "IMAGES") + @"\" + obj.LOGO_NAME, FileMode.Create))
                            {
                                files.CopyTo(fileStream);
                            }

                        }
                    }

                    //obj.CREATED_BY = 1;
                    //obj.CREATED_DATE = DateTime.Now;
                    obj.MODIFIED_BY = 1;
                    obj.MODIFIED_DATE = DateTime.Now;

                    CompanyRepository objRepo = new CompanyRepository(_configuration);

                    objRepo.UpdateCompany(obj);

                    return RedirectToAction("GetAllCompany");
                }
                else
                {
                    
                    string imreBase64Data = Convert.ToBase64String(obj.LOGO_BLOB);
                    string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
                    //Passing image data in viewbag to view  
                    ViewBag.ImageData = imgDataURL;
                    return View(obj);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Delete  Branch details by id      
        public IActionResult DeleteCompany(int id)
        {
            try
            {
                CompanyRepository objRepo = new CompanyRepository(_configuration);
                if (objRepo.DeleteCompany(id))
                {
                    ViewBag.AlertMsg = "Company deleted successfully";

                }
                return RedirectToAction("GetAllCompany");
            }
            catch
            {
                return RedirectToAction("GetAllCompany");

            }


        }
    }
}
