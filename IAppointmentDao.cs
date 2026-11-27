using System.Collections.Generic;
using BusinessObjects;
namespace DataObjects
{
    public interface IAppointmentDao
    {
        List<Appointment> GetAppointmentsByCard(int cardId);
        void AddAppointment(Appointment appointment);
    }
}