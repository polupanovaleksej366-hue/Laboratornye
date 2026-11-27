using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public class MedicalCard : BusinessObject
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DepartmentId { get; set; }
        public int? AttendingDoctorId { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public MedicalCard()
        {
            AddRule(new DateRangeRule
            {
                Property = nameof(AdmissionDate),
                EndProperty = nameof(DischargeDate)
            }, "Период пребывания");
        }
    }
}