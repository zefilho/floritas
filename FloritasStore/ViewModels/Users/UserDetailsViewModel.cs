using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FloritasStore.Attributes;

namespace FloritasStore.ViewModels.Users
{
    public class UserDetailsViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Nome Completo:")]
        public string Name { get; set; }
        
        [Display(Name = "CPF:")]        
        public string Cpf { get; set; }
        
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Display(Name = "Telefone:")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Regra:")]
        public string Role { get; set; }

        [Display(Name = "Empresa:")]        
        public string Company { get; set; }

        [Display(Name = "Foto")]
        public string PhotoMimeType { get; set; }
    }
}
