using System.Collections.Generic;
using BusinessObjects;
namespace DataObjects
{
    public interface IDepartmentDao
    {
        List<Department> GetDepartments();
        Department GetDepartment(int id);
        void AddDepartment(Department department);
    }
}