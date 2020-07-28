using FloritasStore.Models.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FloritasStore.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome da empresa.")]
        [StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z0-9]{2,20}([\ .A-Za-z0-9]+)*$", ErrorMessage = "Nome Inválido.")]
        [Display(Name = "Empresa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite a Razão Social da Empresa.")]
        [StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z0-9]{2,20}([\ .A-Za-z0-9]+)*$", ErrorMessage = "Razão Social Inválida.")]
        [Display(Name = "Razão Social")]
        [ConcurrencyCheck]
        public string CorporateName { get; set; }

        [Required(ErrorMessage = "Digite um número de Telefone.")]
        [Display(Name = "Telefone")]
        [RegularExpression(@"\([0-9]{2}\)[ ]?[0-9]{5}[-][0-9]{4}$", ErrorMessage = "Número inválido.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Digite o Cnpj da Empresa.")]
        [Display(Name = "CNPJ")]    
        [RegularExpression(@"[0-9]{2}\.?[0-9]{3}\.?[0-9]{3}\/?[0-9]{4}\-?[0-9]{2}", ErrorMessage = "CNPJ não existe.")]
        public string Cnpj { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        
    }
}
