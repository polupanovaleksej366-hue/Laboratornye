using System;

namespace BusinessObjects
{
    public enum AppointmentKind
    {
        Injection,
        Pills,
        Diagnostic
    }

    public abstract class Appointment : BusinessObject
    {
        public int Id { get; set; }
        public int MedicalCardId { get; set; }
        public int DoctorId { get; set; }
        public int? NurseId { get; set; }
        public string Description { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool IsCompleted => CompletedDate != null;

        public abstract AppointmentKind Kind { get; }

        protected Appointment()
        {
            AddRule(new NotEmptyRule { Property = nameof(Description) }, "Описание назначения");
        }
    }

    public class InjectionAppointment : Appointment
    {
        public int Quantity { get; set; }
        public override AppointmentKind Kind => AppointmentKind.Injection;

        public InjectionAppointment()
        {
            AddRule(new PositiveNumberRule { Property = nameof(Quantity) }, "Количество инъекций");
        }
    }

    public class PillsAppointment : Appointment
    {
        public double DosageMg { get; set; }
        public int Days { get; set; }
        public override AppointmentKind Kind => AppointmentKind.Pills;

        public PillsAppointment()
        {
            AddRule(new PositiveNumberRule { Property = nameof(DosageMg) }, "Дозировка");
            AddRule(new PositiveNumberRule { Property = nameof(Days) }, "Количество дней");
        }
    }

    public class DiagnosticAppointment : Appointment
    {
        public override AppointmentKind Kind => AppointmentKind.Diagnostic;
    }
}