using Data.Data_Access_Layer;
using Data.Repository.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Implementations
{
   
        public class DepartmentRepository : IDepartmentRepository
        {
            private readonly AppDbContext _context;

            public DepartmentRepository(AppDbContext dbContext)
            {
                _context = dbContext;
            }

            public Department GetById(Guid id)
            {
                return _context.Departments.Find(id);
            }

            public List<Department> GetAll()
            {
                return _context.Departments.ToList();
            }

            public Department Add(Department department)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return department;
            }

            public Department Update(Department department)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
                return department;
            }

            public Department Delete(Guid id)
            {
                var department = GetById(id);
                if (department != null)
                {
                    _context.Departments.Remove(department);
                    _context.SaveChanges();
                }
                return department;
            }

            public void SaveChanges()
            {
                _context.SaveChanges();
            }

        }
    
}
