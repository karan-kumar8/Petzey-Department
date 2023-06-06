using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IDepartmentService
    {
        public Departments AddDepartment(DepartmentDto department);
        public Departments EditDepartment(DepartmentDto departmentDto);
        public List<DepartmentDto> GetAllDepartment();
        public DepartmentDto GetDepartmentById(Guid departmentId);
        public int GetTotalNumberOfDepartments();
        public String GetDepartmentMailById(Guid departmentId);
        public String DeleteDepartment(Guid departmentId);
        public String GetStatusById(Guid departmentId);
    }
}
