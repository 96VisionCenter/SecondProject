using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Models
{
    public class Ragister
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public GenderType Gender{ get; set; }
        public bool Subscribe { get; set; }
        [Display(Name="City")]
        public int Cityid { get; set; }
        [Required]

        public City City{ get; set; }
        [NotMapped]
        [Display(Name="State")]
        public int Stateid { get; set; }
        [NotMapped]
        [Display(Name="Country")]
        public int Countryid { get; set; }


    }
}