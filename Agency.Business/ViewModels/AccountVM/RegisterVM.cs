using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.ViewModels.AccountVM
{
    public class RegisterVM
    {
        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        public string Surname { get; set; }
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)] 
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password) , Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }


    }
}
