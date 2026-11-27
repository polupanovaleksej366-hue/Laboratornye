using System.Collections.Generic;
using BusinessObjects;
namespace Service
{
    public interface IService
    {
        List<Department> GetDepartments();
        List<Doctor> GetDoctors();
        List<Doctor> GetDoctorsByDepartment(int deptId);
        List<Nurse> GetNurses();
        List<Patient> GetPatients();
        Patient GetPatient(int id);
        MedicalCard GetActiveCard(int patientId);
        List<MedicalCard> GetAllCards();
        MedicalCard AdmitPatient(Patient patient, int departmentId, int doctorId);
        void AssignDoctor(int cardId, int doctorId);
        void AddAppointment(Appointment appt);
        List<Appointment> GetAppointments(int cardId);
        void CompleteAppointment(Appointment appt, int? nurseId);
        DischargeEpicrisis DischargePatient(int cardId);
    }
}