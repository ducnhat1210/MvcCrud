using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StrartCRUD.Models
{
    public class CustomValidationAttributeDemo
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        public sealed class ValidBirthDate : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if(value != null)
                {
                    DateTime _birthJoin = Convert.ToDateTime(value);
                    if (_birthJoin > DateTime.Now)
                    {
                        return new ValidationResult("Ngay sinh khong the lon hon ngay hien tai");
                    }
                }
                return ValidationResult.Success;
            }
        }
    }
}