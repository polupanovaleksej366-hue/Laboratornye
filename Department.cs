namespace BusinessObjects
{
    public class Department : BusinessObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department()
        {
            AddRule(new NotEmptyRule { Property = nameof(Name) }, "Название отделения");
        }
        public override string ToString() => Name;
    }
}