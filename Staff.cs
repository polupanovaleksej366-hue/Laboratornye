namespace BusinessObjects
{
    public abstract class Staff : BusinessObject
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int DepartmentId { get; set; }

        protected Staff()
        {
            AddRule(new NotEmptyRule { Property = nameof(FullName) }, "ФИО сотрудника");
        }

        public override string ToString() => FullName;
    }

    public class Doctor : Staff
    {
        public string Specialization { get; set; }
    }

    public class Nurse : Staff { }
}