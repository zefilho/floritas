using FloritasStore.Models.Users;
using FloritasStore.ViewModels;
using FloritasStore.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FloritasStore.Attributes
{
    public sealed class ValidCompany : ValidationAttribute, IClientModelValidator
    {
        private readonly string PropertyName;
            
        public ValidCompany(string property)
        {
            PropertyName = property;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Função que garante se na hora da criação do usuário a Regra Administrador não está sendo 
            //atribuida a um usuario de uma companhia
            //Todas as outras roles sao obrigadas a possuirem uma empresa
            
            var registerUser = (CompanyViewModel) validationContext.ObjectInstance;

            RoleManager<ApplicationRole> _roleManager = (RoleManager<ApplicationRole>)validationContext.GetService(typeof(RoleManager<ApplicationRole>));

            var role = _roleManager.FindByNameAsync("Admin").Result;

            bool validRole = registerUser.roleID.Equals(role.Id);
            bool validCompany = (registerUser.CompanyId != 0);
                        
            if ((validRole && validCompany) || !(validRole || validCompany))
            {                
                return new ValidationResult(ErrorMessage);
            }
            
            return ValidationResult.Success;
                                         
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            MergeAttribute(context.Attributes, "data-val", "true");
            //MergeAttribute(context.Attributes, "data-val-valid-company", GetValidationClientErrorMessage(context));
            MergeAttribute(context.Attributes, "data-val-valid-company", ErrorMessage);
            MergeAttribute(context.Attributes, "data-val-valid-company-field", PropertyName);
        }

        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {

            if (attributes.ContainsKey(key))
                return false;

            attributes.Add(key, value);
            return true;
        }

        private string GetErrorMessage() => ErrorMessage;

        private string GetValidationClientErrorMessage(ClientModelValidationContext context)
        {            
            return string.Format(ErrorMessage, context.ModelMetadata?.GetDisplayName(), PropertyName);
        }

    }
}
