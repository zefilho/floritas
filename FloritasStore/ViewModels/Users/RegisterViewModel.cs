using FloritasStore.Attributes;
using FloritasStore.Models.Users;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace FloritasStore.ViewModels.Users
{
    public class RegisterViewModel: CompanyViewModel
    {

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome Completo:")]
        [RegularExpression(@"^[A-Za-zá-ú]{2,20}([\ .A-Za-zá-ú]+)*$", ErrorMessage = "Campo deve ser constituído somente por letras.")]
        [StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "CPF:")]
        [RegularExpression(@"[0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2}", ErrorMessage = "Cpf inválido.")]
        [ValidCPF]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Telefone:")]
        [RegularExpression(@"\([0-9]{2}\)[ ]?[0-9]{5}[-][0-9]{4}$", ErrorMessage = "Número inválido.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha:")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmação de Senha:")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não coincidem.")]
        public string ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "Selecione uma regra.")]
        //[Display(Name = "Regra:")]
        //public string roleID { get; set; }

        //[Display(Name = "Empresa:")]
        //[ValidCompany(nameof(roleID), ErrorMessage = "A regra Administrador não deve ter empresa vinculada ou as " +
        //    "demais regras devem possuir obrigatoriamente uma empresa.")]
        //public int CompanyId { get; set; }

    }


}
