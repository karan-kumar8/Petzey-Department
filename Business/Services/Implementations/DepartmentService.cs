using AutoMapper;
using Business.Services.Interfaces;
using Data.Repository.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public Departments AddDepartment(DepartmentDto departmentDto)
        {
            try
            {
                var department = _mapper.Map<Departments>(departmentDto);
                _departmentRepository.Add(department);
                return department;
            }
            catch (Exception ex)
            {
                // handle exception
                return null;
            }
        }

        public Departments EditDepartment(DepartmentDto departmentDto)
        {
            try
            {
                var department = _mapper.Map<Departments>(departmentDto);
                _departmentRepository.Update(department);
                return department;
            }
            catch (Exception ex)
            {
                // handle exception
                return null;
            }
        }

        public List<DepartmentDto> GetAllDepartment()
        {
            try
            {
                var departments = _departmentRepository.GetAll();
                var departmentDto = _mapper.Map<List<DepartmentDto>>(departments);
                return departmentDto;
            }
            catch (Exception ex)
            {
                // handle exception
                return null;
            }
        }

        public DepartmentDto GetDepartmentById(Guid departmentId)
        {
            try
            {
                var department = _departmentRepository.GetById(departmentId);
                var departmentDto = _mapper.Map<DepartmentDto>(department);
                return departmentDto;
            }
            catch (Exception ex)
            {
                // handle exception
                return null;
            }
        }

        public int GetTotalNumberOfDepartments()
        {
            try
            {
                var departments = _departmentRepository.GetAll();
                return departments.Count;
            }
            catch (Exception ex)
            {
                // handle exception
                return 0;
            }
        }

        public string GetDepartmentMailById(Guid departmentId)
        {
            try
            {
                var department = _departmentRepository.GetById(departmentId);
                return department.DepartmentEmail;
            }
            catch (Exception ex)
            {
                // handle exception
                return null;
            }
        }

        public string DeleteDepartment(Guid departmentId)
        {
            try
            {
                var department = _departmentRepository.Delete(departmentId);
                if (department == null)
                {
                    return "Department not found";
                }
                return "Department deleted successfully";
            }
            catch (Exception ex)
            {
                // handle exception
                return "Failed to delete department";
            }
        }

        public string GetStatusById(Guid departmentId)
        {
            try
            {
                var department = _departmentRepository.GetById(departmentId);
                return department.Status ? "Active" : "Inactive";
            }
            catch (Exception ex)
            {
                // handle exception
                return null;
            }
        }
    }
}
