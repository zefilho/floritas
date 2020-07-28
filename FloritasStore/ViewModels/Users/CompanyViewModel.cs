using FloritasStore.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FloritasStore.ViewModels
{
    public class CompanyViewModel
    {
        [Required(ErrorMessage = "Selecione uma regra.")]
        [Display(Name = "Regra:")]
        public string roleID { get; set; }

        [Display(Name = "Empresa:")]
        [ValidCompany(nameof(roleID), ErrorMessage = "A regra Administrador não deve ter empresa vinculada ou as " +
            "demais regras devem possuir obrigatoriamente uma empresa.")]
        public int CompanyId { get; set; }
    }
}
