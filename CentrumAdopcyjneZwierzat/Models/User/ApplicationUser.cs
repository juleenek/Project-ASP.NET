using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(12)")]
        public string Phone { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(255)")]
        public string StreetAddress { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(10)")]
        public string PostalCode { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(30)")]
        public string City { get; set; }
    }
}
