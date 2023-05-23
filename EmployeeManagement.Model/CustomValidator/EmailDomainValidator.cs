using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model.CustomValidator
{
    public class EmailDomainValidator : ValidationAttribute
    {
        public string domainName { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null) {
                string[] strings = value.ToString().Split("@");
                if (strings.Length > 1 && strings[1].ToUpper() == domainName.ToUpper())
                {
                    return null;
                }
                return new ValidationResult($"Domain name must be {domainName}", new[] { validationContext.MemberName });
            }
            return null;
        }
    }
}
