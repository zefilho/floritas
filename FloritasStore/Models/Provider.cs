using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FloritasStore.Models
{
    public class Provider
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome / Empresa")]
        [StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z0-9]{2,20}([\ .A-Za-z0-9]+)*$", ErrorMessage = "Campo Inválido.")]        
        public string Name { get; set; }

        [Required]
        [Display(Name = "CNPJ")]
        [RegularExpression(@"[0-9]{2}\.?[0-9]{3}\.?[0-9]{3}\/?[0-9]{4}\-?[0-9]{2}", ErrorMessage = "CNPJ Inválido.")]
        public string Cnpj { get; set; }
       
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Telefone")]
        [RegularExpression(@"\([0-9]{2}\)[ ]?[0-9]{5}[-][0-9]{4}$", ErrorMessage = "Número inválido.")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Endereço")]
        [RegularExpression(@"^[A-Za-zá-ú]{2,20}([\ .A-Za-zá-ú]+)*$", ErrorMessage = "Campo deve ser constituído somente por letras.")]
        [StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 2)]
        public string Address { get; set; }

        [Required]
        [Display(Name= "Bairro")]
        [StringLength(100, ErrorMessage = "A senha deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z0-9]{2,20}([\ .A-Za-z0-9]+)*$", ErrorMessage = "Razão Social Inválida.")]
        public string Neighborhood { get; set; }

        [Display(Name = "Complemento")]
        [RegularExpression(@"^[A-Za-zá-ú]{2,20}([\ .A-Za-zá-ú]+)*$", ErrorMessage = "Campo deve ser constituído somente por letras.")]
        [StringLength(20, ErrorMessage = "A senha deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 2)]
        public string Complement { get; set; }
       
        [Display(Name = "Número")]   
        [DefaultValue(0)]
        public int Number { get; set; }

        [Required]
        [Display(Name = "Estado" )]
        public string State { get; set; }

        [Required]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        [RegularExpression(@"^[A-Za-zá-ú]{2,20}([\ .A-Za-zá-ú]+)*$", ErrorMessage = "Campo deve ser constituído somente por letras.")]
        public string City { get; set; }
        
        [Display(Name = "Informações Adicionais")]
        public string InformAdd { get; set; }
    }
}
