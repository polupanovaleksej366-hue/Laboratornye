using System.Collections.Generic;
using BusinessObjects;
namespace DataObjects
{
    public class AppointmentDao : IAppointmentDao
    {
        private static readonly Db _db = Db.GetInstance();
        public void AddAppointment(Appointment appointment)
        {
            appointment.Id = _db.NextAppointmentId();
            var card = _db.MedicalCards.Find(c => c.Id == appointment.MedicalCardId);
            card?.Appointments.Add(appointment);
            _db.Save();
        }
        public List<Appointment> GetAppointmentsByCard(int cardId)
        {
            var card = _db.MedicalCards.Find(c => c.Id == cardId);
            return card?.Appointments ?? new List<Appointment>();
        }
    }
}