using System;
namespace BusinessObjects
{
    public class NotEmptyRule : BusinessRule
    {
        public override bool Validate(BusinessObject businessObject)
        {
            var value = GetPropertyValue(businessObject) as string;
            return !string.IsNullOrWhiteSpace(value);
        }
    }
    public class PositiveNumberRule : BusinessRule
    {
        public override bool Validate(BusinessObject businessObject)
        {
            var value = GetPropertyValue(businessObject);
            if (value == null) return false;
            try
            {
                return Convert.ToDouble(value) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
    public class DateRangeRule : BusinessRule
    {
        public string EndProperty { get; set; }
        public override bool Validate(BusinessObject businessObject)
        {
            var startObj = GetPropertyValue(businessObject);
            var prop = businessObject.GetType().GetProperty(EndProperty);
            var endObj = prop?.GetValue(businessObject);
            if (startObj == null || endObj == null) return true;
            return (DateTime)startObj <= (DateTime)endObj;
        }
    }
}