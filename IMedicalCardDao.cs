using System.Collections.Generic;
using BusinessObjects;
namespace DataObjects
{
    public interface IMedicalCardDao
    {
        List<MedicalCard> GetCards();
        MedicalCard GetCard(int id);
        MedicalCard GetCardByPatient(int patientId);
        void AddCard(MedicalCard card);
    }
}