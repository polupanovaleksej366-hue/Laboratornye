using System.Collections.Generic;
using BusinessObjects;
namespace DataObjects
{
    public class DoctorDao : IDoctorDao
    {
        private static readonly Db _db = Db.GetInstance();
        public void AddDoctor(Doctor doctor)
        {
            doctor.Id = _db.NextDoctorId();
            _db.Doctors.Add(doctor);
            _db.Save();
        }
        public List<Doctor> GetDoctors() => _db.Doctors;
        public List<Doctor> GetDoctorsByDepartment(int departmentId) =>
            _db.Doctors.FindAll(d => d.DepartmentId == departmentId);
    }
}