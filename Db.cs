using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using BusinessObjects;
namespace DataObjects
{
    public class Db
    {
        private static Db _instance;
        public static Db GetInstance() => _instance ??= new Db();
        public List<Patient> Patients { get; set; } = new List<Patient>();
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public List<Nurse> Nurses { get; set; } = new List<Nurse>();
        public List<Department> Departments { get; set; } = new List<Department>();
        public List<MedicalCard> MedicalCards { get; set; } = new List<MedicalCard>();
        private int _patientId = 1, _doctorId = 1, _nurseId = 1,
                    _deptId = 1, _cardId = 1, _apptId = 1;
        private const string FilePath = "hospital_db.json";
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new AppointmentConverter() }
        };
        private Db()
        {
            if (File.Exists(FilePath))
            {
                Load();
            }
            else
            {
                Departments.Add(new Department { Id = _deptId++, Name = "Кардиологическое" });
                Departments.Add(new Department { Id = _deptId++, Name = "Хирургическое" });
                Departments.Add(new Department { Id = _deptId++, Name = "Неврологическое" });

                Doctors.Add(new Doctor { Id = _doctorId++, FullName = "Иванов И.И.", Specialization = "Кардиолог", DepartmentId = 1 });
                Doctors.Add(new Doctor { Id = _doctorId++, FullName = "Петров П.П.", Specialization = "Хирург", DepartmentId = 2 });
                Doctors.Add(new Doctor { Id = _doctorId++, FullName = "Смирнов С.С.", Specialization = "Невролог", DepartmentId = 3 });

                Nurses.Add(new Nurse { Id = _nurseId++, FullName = "Сидорова А.А.", DepartmentId = 1 });
                Nurses.Add(new Nurse { Id = _nurseId++, FullName = "Кузнецова М.М.", DepartmentId = 2 });
            }
        }
        public void Save()
        {
            var json = JsonSerializer.Serialize(this, JsonOptions);
            File.WriteAllText(FilePath, json);
        }
        private void Load()
        {
            var json = File.ReadAllText(FilePath);
            var loaded = JsonSerializer.Deserialize<Db>(json, JsonOptions);
            if (loaded == null) return;
            Patients = loaded.Patients;
            Doctors = loaded.Doctors;
            Nurses = loaded.Nurses;
            Departments = loaded.Departments;
            MedicalCards = loaded.MedicalCards;
            _patientId = loaded._patientId;
            _doctorId = loaded._doctorId;
            _nurseId = loaded._nurseId;
            _deptId = loaded._deptId;
            _cardId = loaded._cardId;
            _apptId = loaded._apptId;
        }
        public int NextPatientId() => _patientId++;
        public int NextDoctorId() => _doctorId++;
        public int NextNurseId() => _nurseId++;
        public int NextDepartmentId() => _deptId++;
        public int NextCardId() => _cardId++;
        public int NextAppointmentId() => _apptId++;
    }
}