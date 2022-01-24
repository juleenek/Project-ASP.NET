using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.Models.AdoptionCenter
{
    public class Dog
    {
        [HiddenInput]
        [Key]
        [Required(ErrorMessage = "Podaj id psa.")]
        [DisplayName("Dogs Id")]
        public string DogId { get; set; }
        [DisplayName("Dogs Name")]
        public string DogName { get; set; }
        [DisplayName("Dogs Breed")]
        public Breed Breed { get; set; }
        [DisplayName("Dogs Gender")]
        public string Gender { get; set; }
        [DisplayName("Dogs Weight")]
        public Weight Weight { get; set; }
        [DisplayName("Dogs Birth Year")]
        public int DogBirthYear { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
        [DisplayName("Dogs Box")]
        public Box Box { get; set; } // Jeden do wielu
        [DisplayName("Dogs Volunteer")]
        public int VolunteerId { get; set; } // Jeden do wielu
    }

    public enum Breed
    {
        [Display(Name ="Samiec")] Male,
        [Display(Name = "Samica")] Female
    }

    public enum Weight
    {
        [Display(Name = "Mały")] Small,
        [Display(Name = "Średni")] Medium,
        [Display(Name = "Duży")] Big
    }
}
