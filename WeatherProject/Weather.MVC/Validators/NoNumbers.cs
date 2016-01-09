using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Text.RegularExpressions;

namespace Weather.MVC.Validators
{
    public class NoNumbersAttribute : ValidationAttribute, IClientValidatable
    {
        public NoNumbersAttribute()
            :base("The cityname can not contain any numbers")
        {
            //tom!
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            return value is string && !Regex.IsMatch(value.ToString(), @"\d");
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "nonumber"
            };
        }
    }
}