using System.Collections.Generic;
using BusinessObjects;
namespace DataObjects
{
    public class NurseDao : INurseDao
    {
        private static readonly Db _db = Db.GetInstance();
        public void AddNurse(Nurse nurse)
        {
            nurse.Id = _db.NextNurseId();
            _db.Nurses.Add(nurse);
            _db.Save();
        }
        public List<Nurse> GetNurses() => _db.Nurses;
    }
}