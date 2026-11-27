using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using DataObjects;
namespace Service
{
    public class Service : IService
    {
        private static readonly IDepartmentDao _deptDao = new DepartmentDao();
        private static readonly IDoctorDao _docDao = new DoctorDao();
        private static readonly INurseDao _nurseDao = new NurseDao();
        private static readonly IPatientDao _patDao = new PatientDao();
        private static readonly IMedicalCardDao _cardDao = new MedicalCardDao();
        private static readonly IAppointmentDao _appDao = new AppointmentDao();
        public List<Department> GetDepartments() => _deptDao.GetDepartments();
        public List<Doctor> GetDoctors() => _docDao.GetDoctors();
        public List<Doctor> GetDoctorsByDepartment(int deptId) => _docDao.GetDoctorsByDepartment(deptId);
        public List<Nurse> GetNurses() => _nurseDao.GetNurses();
        public List<Patient> GetPatients() => _patDao.GetPatients();
        public Patient GetPatient(int id) => _patDao.GetPatient(id);
        public MedicalCard GetActiveCard(int patientId) => _cardDao.GetCardByPatient(patientId);
        public List<MedicalCard> GetAllCards() => _cardDao.GetCards();
        public MedicalCard AdmitPatient(Patient patient, int departmentId, int doctorId)
        {
            var errors = patient.Validate();
            if (errors.Any())
                throw new Exception("Пациент невалиден: " + string.Join("; ", errors));
            _patDao.AddPatient(patient);
            var card = new MedicalCard
            {
                PatientId = patient.Id,
                DepartmentId = departmentId,
                AttendingDoctorId = doctorId,
                AdmissionDate = DateTime.Now
            };
            _cardDao.AddCard(card);
            return card;
        }
        public void AssignDoctor(int cardId, int doctorId)
        {
            var card = _cardDao.GetCard(cardId) ?? throw new Exception("ЭМК не найдена");
            card.AttendingDoctorId = doctorId;
            Db.GetInstance().Save();
        }
        public void AddAppointment(Appointment appt)
        {
            var errors = appt.Validate();
            if (errors.Any())
                throw new Exception("Назначение невалидно: " + string.Join("; ", errors));
            _appDao.AddAppointment(appt);
        }
        public List<Appointment> GetAppointments(int cardId) => _appDao.GetAppointmentsByCard(cardId);
        public void CompleteAppointment(Appointment appt, int? nurseId)
        {
            if (appt.Kind != AppointmentKind.Diagnostic && nurseId == null)
                throw new Exception("Медикаментозные назначения выполняет медсестра");
            appt.NurseId = nurseId;
            appt.CompletedDate = DateTime.Now;
            Db.GetInstance().Save();
        }
        public DischargeEpicrisis DischargePatient(int cardId)
        {
            var card = _cardDao.GetCard(cardId) ?? throw new Exception("ЭМК не найдена");
            card.DischargeDate = DateTime.Now;
            Db.GetInstance().Save();
            var patient = _patDao.GetPatient(card.PatientId);
            var completed = card.Appointments.Where(a => a.IsCompleted).ToList();
            return new DischargeEpicrisis
            {
                Patient = patient,
                Card = card,
                CompletedAppointments = completed
            };
        }
    }
}