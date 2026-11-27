using System.Collections.Generic;
namespace BusinessObjects
{
    public abstract class BusinessObject
    {
        private readonly List<BusinessRule> _rules = new List<BusinessRule>();
        private readonly Dictionary<string, string> _fieldNames = new Dictionary<string, string>();
        protected void AddRule(BusinessRule rule, string displayName)
        {
            _rules.Add(rule);
            _fieldNames[rule.Property] = displayName; 
        }
        public List<string> Validate()
        {
            var errors = new List<string>();
            foreach (var rule in _rules)
            {
                if (!rule.Validate(this))
                {
                    if (_fieldNames.TryGetValue(rule.Property, out var displayName))
                        errors.Add($"Поле '{displayName}' заполнено неверно");
                    else
                        errors.Add($"Поле '{rule.Property}' заполнено неверно");
                }
            }
            return errors;
        }
    }
}