using System.Collections.Generic;
using BusinessObjects;
namespace DataObjects
{
    public interface IPatientDao
    {
        List<Patient> GetPatients();
        Patient GetPatient(int id);
        void AddPatient(Patient patient);
    }
}