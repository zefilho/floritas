using FloritasStore.Attributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FloritasStore.ViewModels.Users
{
    public class EditUserViewModel: CompanyViewModel
    {
        [Required]
        public string Id { get; set; }

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

        [Required]
        [Display(Name = "Telefone:")]
        [RegularExpression(@"\([0-9]{2}\)[ ]?[0-9]{5}[-][0-9]{4}$", ErrorMessage = "Número inválido.")]
        public string PhoneNumber { get; set; }

        public string PhotoPoints { get; set; }

        public IFormFile formFile { get; set; }
    }
}
