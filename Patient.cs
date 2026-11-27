using System;
namespace BusinessObjects
{
    public class Patient : BusinessObject
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string DiagnosisOnAdmission { get; set; }
        public Patient()
        {
            AddRule(new NotEmptyRule { Property = nameof(FullName) }, "ФИО пациента");
            AddRule(new NotEmptyRule { Property = nameof(DiagnosisOnAdmission) }, "Диагноз при поступлении");
        }
        public override string ToString() => $"{Id}. {FullName}";
    }
}