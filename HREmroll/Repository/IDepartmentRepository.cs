using HREmroll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HREmroll.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartments();
        Task<Department> GetDepartmentByID(long id);
        //Task<Department> Edit_Department(Department customer);
        Task<Department> ADD_Department(Department customer);
        Task<Department> DeleteDepartment(long id);

    }
}
