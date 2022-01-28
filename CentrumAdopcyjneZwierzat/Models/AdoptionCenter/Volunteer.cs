using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.Models.AdoptionCenter
{
    public class Volunteer
    {
        public Volunteer()
        {
           Boxes = new HashSet<Box>();
        }
        [Key]
        [HiddenInput]
        [DisplayName("Volunteer Id")]
        public string VolunteerId { get; set; }
        [Required(ErrorMessage = "Imię jest wymagane.")]
        [StringLength(40, ErrorMessage = "Imię musi składać się przynajmniej z {2} znaków", MinimumLength = 3)]
        [RegularExpression("[a-zA-Z-]*[^!@%~?:;#$%^&*()/\"0-9']*",
         ErrorMessage = "Imię może składać się z wielkich i małych liter.")]
        [DisplayName("Imię")]
        public string VolunteerFirstName { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        [StringLength(40, ErrorMessage = "Nazwisko musi składać się przynajmniej z {2} znaków", MinimumLength = 2)]
        [RegularExpression("[a-zA-Z-]*[^!@%~?:;#$%^&*()/\"0-9']*",
          ErrorMessage = "Nazwisko może składać się z wielkich i małych liter.")]
        [DisplayName("Nazwisko")]
        public string VolunteerLastName { get; set; }
        [StringLength(11, ErrorMessage = "Pesel musi składać się z {1} znaków", MinimumLength = 11)]
        public string VolunteerPesel { get; set; }
        [Required(ErrorMessage = "E-mail jest wymagany.")]
        [EmailAddress(ErrorMessage = "Proszę wprowadzić e-mail w poprawnym formacie")]
        public string VolunteerEmail { get; set; }
        public string VolunteerPhone { get; set; }
        public Dog Dog { get; set; } // Jeden do wielu
        public ICollection<Box> Boxes { get; set; } // Wiele do wielu
    }
}
