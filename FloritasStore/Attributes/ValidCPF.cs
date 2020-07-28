using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FloritasStore.Attributes
{
    public sealed class ValidCPF : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);
            var cpfProperty = (string)value;

            var cpfNumber = from el in cpfProperty.ToCharArray()
                            where el != '.' && el != '-'
                            select (int) char.GetNumericValue(el);

            if (cpfNumber.Distinct().Count() == 1)
                return new ValidationResult(GetErroMessage());

            int sumFirstDigit = 0, sumSecondDigit = 0, indexEl = 0;

            foreach (var el in cpfNumber.SkipLast(2))
            {
                sumFirstDigit += (el * (10 - indexEl));
                sumSecondDigit += (el * (11 - indexEl++));
            }

            bool validFirstDigit = ((sumFirstDigit * 10) % 11 == cpfNumber.ElementAt(9));

            if (!validFirstDigit)
                return new ValidationResult(GetErroMessage());

            sumSecondDigit += cpfNumber.ElementAt(9) * 2;

            bool validSecondDigit = ((sumSecondDigit * 10) % 11 == cpfNumber.ElementAt(10));

            if (!validFirstDigit)
                return new ValidationResult(GetErroMessage());

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-valid-cpf", GetErroMessage());
        }

        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {

            if (attributes.ContainsKey(key))
                return false;

            attributes.Add(key, value);
            return true;
        }

        private string GetErroMessage() => "Cpf inválido.";
    }
}
