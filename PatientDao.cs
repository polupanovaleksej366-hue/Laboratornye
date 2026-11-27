using System.Collections.Generic;
using BusinessObjects;
namespace DataObjects
{
    public class PatientDao : IPatientDao
    {
        private static readonly Db _db = Db.GetInstance();
        public void AddPatient(Patient patient)
        {
            patient.Id = _db.NextPatientId();
            _db.Patients.Add(patient);
            _db.Save();
        }
        public Patient GetPatient(int id) => _db.Patients.Find(p => p.Id == id);
        public List<Patient> GetPatients() => _db.Patients;
    }
}