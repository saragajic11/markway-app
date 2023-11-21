// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace Markway.Users.API.Models.DTO
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredConditionalAttribute : RequiredAttribute
    {
        private string PropertyName { get; }

        public RequiredConditionalAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            object instance = context.ObjectInstance;
            Type type = instance.GetType();

            string propertyValue = type.GetProperty(PropertyName).GetValue(instance)?.ToString();

            if (!string.IsNullOrWhiteSpace(propertyValue) && string.IsNullOrWhiteSpace(value?.ToString()))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
