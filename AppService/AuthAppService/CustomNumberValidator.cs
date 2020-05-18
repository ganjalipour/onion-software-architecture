using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Consulting.Applications.AppService.AuthAppService
{
    public class CustomNumberValidateAttribute : ValidationAttribute
    {

        private readonly int _minValue;
        public CustomNumberValidateAttribute(int minValue)
        {
            _minValue = minValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
                return new ValidationResult(ErrorMessage);

            if (value.GetType().IsArray)
            {
                int[] arr = (int[])value;
                if(arr.Length < _minValue)
                    return new ValidationResult(ErrorMessage);
            }
           else if ((int)value < _minValue)
            {
                //return new ValidationResult($"لطفا {validationContext.DisplayName} انتخاب شود.");
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
