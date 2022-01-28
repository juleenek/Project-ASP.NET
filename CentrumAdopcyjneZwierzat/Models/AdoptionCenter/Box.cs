using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.Models.AdoptionCenter
{
    public class Box
    {
        public Box()
        {
            Volunteers = new HashSet<Volunteer>();
        }
        [Key]
        [HiddenInput]
        public string BoxId { get; set; }
        [Required(ErrorMessage = "Nazwa placówki jest wymagana.")]
        [StringLength(40, ErrorMessage = "Nazwa placówki musi składać się przynajmniej z {2} znaków", MinimumLength = 3)]
        [RegularExpression("[a-zA-Z-]*[^!@%~?:;#$%^&*()/\"0-9']*",
        ErrorMessage = "Nazwa placówki może składać się z wielkich i małych liter.")]
        [DisplayName("Nazwa")]
        public string BoxName { get; set; }
        [Required(ErrorMessage = "Adres placówki jest wymagany.")]
        [StringLength(40, ErrorMessage = "Adres placówki musi składać się przynajmniej z {2} znaków", MinimumLength = 3)]
        [DisplayName("Adres")]
        public string BoxAddress { get; set; }
        public ICollection<Dog> Dogs { get; set; } // Jeden do wielu
        public ICollection<Volunteer> Volunteers { get; set; } // Wiele do wielu

    }
}
