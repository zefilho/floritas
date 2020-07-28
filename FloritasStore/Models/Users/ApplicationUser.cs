using FloritasStore.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FloritasStore.Models.Users
{
    public class ApplicationUser: IdentityUser
    {
        public virtual ICollection<ApplicationUserClaim> Claims { get; set; }
        public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
        public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

        [Required]      
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]        
        public string Cpf { get; set; }
                
        [Display(Name = "Empresa")]
        public int? CompanyId { get; set; }

        [Display(Name = "Empresa")]
        public Company Company { get; set; }

        [Display(Name = "Foto")]
        public string PhotoMimeType { get; set; }

        public string PhotoPoints { get; set; }

        public byte[] Photo { get; set; }

        [NotMapped]
        public IFormFile formFile { get; set; }
    }
  
}
