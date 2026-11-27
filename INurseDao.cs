using System.Collections.Generic;
using BusinessObjects;
namespace DataObjects
{
    public interface INurseDao
    {
        List<Nurse> GetNurses();
        void AddNurse(Nurse nurse);
    }
}