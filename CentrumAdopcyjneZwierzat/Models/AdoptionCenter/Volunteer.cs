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
        public string VolunteerFirstName { get; set; }
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
