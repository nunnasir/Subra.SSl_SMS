using Subra.SSL_SMS.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Subra.SSL_SMS.Web.Models
{
    public class ValidateContactIds : ValidationAttribute
    {
        public string GetErrorMessage() =>
            "Ivalid Contact Format or length";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty("ContatId");
            object propertyValue = property.GetValue(instance);

            foreach (var itemValue in propertyValue.ToString().Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var item = Regex.Replace(itemValue, @"\s", "");
                if(! Double.TryParse(item, out double number))
                    return new ValidationResult(GetErrorMessage());

                if(!(item.Length >= 10 && item.Length <= 13) || item.Length == 12)
                    return new ValidationResult(GetErrorMessage());

                if (item.Length == 13 && item.Substring(0, 4) != "8801")
                    return new ValidationResult(GetErrorMessage());

                if (item.Length == 11 && item.Substring(0, 2) != "01")
                    return new ValidationResult(GetErrorMessage());
                
                if (item.Length == 10 && item.Substring(0, 1) != "1")
                    return new ValidationResult(GetErrorMessage());

            }

            return ValidationResult.Success;
        }
    }
}
