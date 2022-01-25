﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public string BoxName { get; set; }
        public string BoxAddress { get; set; }
        public ICollection<Dog> Dogs { get; set; } // Jeden do wielu
        public ICollection<Volunteer> Volunteers { get; set; } // Wiele do wielu

    }
}
