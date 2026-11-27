using System.Reflection;

namespace BusinessObjects
{
    public abstract class BusinessRule
    {
        public string Property { get; set; }

        public abstract bool Validate(BusinessObject businessObject);

        protected object GetPropertyValue(BusinessObject businessObject)
        {
            if (businessObject == null) return null;
            var prop = businessObject.GetType().GetProperty(Property, BindingFlags.Public | BindingFlags.Instance);
            return prop?.GetValue(businessObject);
        }
    }
}