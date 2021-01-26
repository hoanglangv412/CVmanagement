using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cvManagement.Models
{
    public class CustomValidationAttribute
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        public sealed class ValidDate : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    DateTime _dateJoin = Convert.ToDateTime(value);

                    if (_dateJoin > DateTime.Now)
                    {
                        return new ValidationResult("Ngày không được lớn hơn ngày hiện tại.");
                    }
                }

                return ValidationResult.Success;
            }
        }
    }
}