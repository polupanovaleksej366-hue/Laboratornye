using System.Collections.Generic;
using BusinessObjects;
namespace DataObjects
{
    public interface IDoctorDao
    {
        List<Doctor> GetDoctors();
        List<Doctor> GetDoctorsByDepartment(int departmentId);
        void AddDoctor(Doctor doctor);
    }
}