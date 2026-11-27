using System;
using Xunit;
using BusinessObjects;
namespace Hospital.Tests
{
    public class PatientTests
    {
        [Fact]
        public void Validate_EmptyPatient_ReturnsErrors()
        {
            var patient = new Patient
            {
                FullName = "",
                DiagnosisOnAdmission = ""
            };
            var errors = patient.Validate();
            Assert.NotEmpty(errors);
            Assert.Equal(2, errors.Count);
        }

        [Fact]
        public void Validate_ValidPatient_ReturnsNoErrors()
        {
            var patient = new Patient
            {
                FullName = "Иванов Иван",
                DiagnosisOnAdmission = "ОРВИ"
            };
            var errors = patient.Validate();
            Assert.Empty(errors);
        }
    }
}