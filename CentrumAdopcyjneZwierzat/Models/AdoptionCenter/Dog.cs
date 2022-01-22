using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.Models.AdoptionCenter
{
    public class Dog
    {
        [HiddenInput]
        [Key]
        public int DogId { get; set; }
        public string DogName { get; set; }
        public Breed Breed { get; set; }
        public string Gender { get; set; }
        public Weight Weight { get; set; }
        public int DogBirthYear { get; set; }
        public Box Box { get; set; } // Jeden do wielu
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
