using System.Collections.Generic;
using BusinessObjects;
namespace DataObjects
{
    public class MedicalCardDao : IMedicalCardDao
    {
        private static readonly Db _db = Db.GetInstance();
        public void AddCard(MedicalCard card)
        {
            card.Id = _db.NextCardId();
            _db.MedicalCards.Add(card);
            _db.Save();
        }
        public MedicalCard GetCard(int id) => _db.MedicalCards.Find(c => c.Id == id);
        public MedicalCard GetCardByPatient(int patientId) =>
            _db.MedicalCards.Find(c => c.PatientId == patientId && c.DischargeDate == null);
        public List<MedicalCard> GetCards() => _db.MedicalCards;
    }
}