using Domain.Entities;

namespace Data.Repository.Interfaces
{
    public interface IDepartmentRepository
    {
        Departments GetById(Guid id);
        List<Departments> GetAll();
        Departments Add(Departments department);
        Departments Update(Departments department);
        Departments Delete(Guid id);
        void SaveChanges();
    }
}