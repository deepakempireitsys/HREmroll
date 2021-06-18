using HREmroll.Models;
using HREmroll.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentOLDController : Controller
    {
        private readonly IDepartmentRepository _departmentRep;
        public DepartmentOLDController(IDepartmentRepository DepartmentRepository)
        {
            _departmentRep = DepartmentRepository;
        }
        // GET api/values
        [HttpGet]
        public async Task<List<Department>> GetDepartments()
        {
            return await _departmentRep.GetDepartments();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetByDepartmentByID(int id)
        {
            return await _departmentRep.GetDepartmentByID(id);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> ADD_Department([FromBody] Department Department)
        {
            if (Department == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid State");
            }

            return await _departmentRep.ADD_Department(Department);
        }

        [HttpPost]
        //public async Task<ActionResult<Department>> Edit_Department([FromBody] Department Department)
        //{
        //    if (Department == null || !ModelState.IsValid)
        //    {
        //        return BadRequest("Invalid State");
        //    }
        //
        //    return await _departmentRep.Edit_Department(Department);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteById(int id)
        {
            return await _departmentRep.DeleteDepartment(id);
        }
    
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
