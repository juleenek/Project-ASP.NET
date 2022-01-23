using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.Models.User
{
    public class AdminModel
    {
        [Required(ErrorMessage = "Podaj swój login.")]
        [StringLength(20, ErrorMessage = "Nazwa użytkownika musi zawierać {2}-{1} znaków", MinimumLength = 6)]
        [RegularExpression("[a-zA-Z0-9]*[^!@%~?:;#$%^&*()/\"']*",
        ErrorMessage = "Login może składać się z wielkich i małych liter oraz cyfr.")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
