using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using HREmroll.Models;

using HREmroll.Repository;
using Microsoft.Extensions.Configuration;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace HREmroll.Controllers
{
  

    public class AccountController : Microsoft.AspNetCore.Mvc.Controller
     {

        private readonly IConfiguration _configuration;
        private IWebHostEnvironment _env;

        public AccountController(IConfiguration configuration, IWebHostEnvironment env)
        {
            //_logger = logger;
            _configuration = configuration;
            _env = env;
        }

        //    [Route("")]
        //    [Route("Login")]
        //    [Route("~/")]
        public IActionResult UserLogin()
        
        {
            CompanyRepository comprepo = new CompanyRepository(_configuration);

            ViewBag.data = comprepo.GetAllCompanys();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserLogin(string user_name, string password)
        {

            if (ModelState.IsValid)
            {
                if (user_name != null && password != null && user_name.Equals("Admin") && password.Equals("Admin@123"))
                {
                    HttpContext.Session.SetString("username", user_name);

                    return RedirectToAction("GetAllCompany", "Company");

                }

                else
                {
                    ViewBag.error = "Invalid Account";
                    return RedirectToAction("UserLogin", "Account");

                }

            }
            else
            {
                return View();
            }

        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }

    }
}
