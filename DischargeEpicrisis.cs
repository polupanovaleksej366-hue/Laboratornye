using System.Collections.Generic;
using System.Text;
namespace BusinessObjects
{
    public class DischargeEpicrisis
    {
        public Patient Patient { get; set; }
        public MedicalCard Card { get; set; }
        public List<Appointment> CompletedAppointments { get; set; } = new List<Appointment>();
        public string BuildText()
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== ВЫПИСНОЙ ЭПИКРИЗ ===");
            sb.AppendLine($"Пациент: {Patient.FullName}");
            sb.AppendLine($"Дата рождения: {Patient.BirthDate:dd.MM.yyyy}");
            sb.AppendLine($"Период пребывания: {Card.AdmissionDate:dd.MM.yyyy} — {Card.DischargeDate:dd.MM.yyyy}");
            sb.AppendLine($"Диагноз при поступлении: {Patient.DiagnosisOnAdmission}");
            sb.AppendLine("Выполненные назначения:");
            foreach (var a in CompletedAppointments)
                sb.AppendLine($"  - {a.Kind}: {a.Description} (выполнено {a.CompletedDate:dd.MM.yyyy})");
            return sb.ToString();
        }
    }
}