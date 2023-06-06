using Domain.Entities;

namespace Data.Repository.Interfaces
{
    public interface IDepartmentRepository
    {
        Department GetById(Guid id);
        List<Department> GetAll();
        Department Add(Department department);
        Department Update(Department department);
        Department Delete(Guid id);
        void SaveChanges();
    }
}