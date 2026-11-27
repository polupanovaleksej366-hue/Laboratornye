using System.Collections.Generic;
using BusinessObjects;
namespace DataObjects
{
    public class DepartmentDao : IDepartmentDao
    {
        private static readonly Db _db = Db.GetInstance();
        public void AddDepartment(Department department)
        {
            department.Id = _db.NextDepartmentId();
            _db.Departments.Add(department);
            _db.Save();
        }
        public Department GetDepartment(int id) => _db.Departments.Find(d => d.Id == id);
        public List<Department> GetDepartments() => _db.Departments;
    }
}