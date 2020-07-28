using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FloritasStore.Attributes
{
    public sealed class ValidPhoto : ValidationAttribute, IClientModelValidator
    {

        public string GetErrorMessage() =>
        $"Arquivo muito grande. Selecione um arquivo menor que 2Mb.";

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {

            var file = value as IFormFile;

            using (var memoryStream = new MemoryStream())
            {                
                file.CopyTo(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length > 2097152)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
