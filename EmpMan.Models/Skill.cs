using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpMan.Models
{
    public class Skill
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [DisplayName("Primary Skill")]
        public string? PrimarySkill {get; set;}

         [Required]
        [DisplayName("Secondary Skill")]
        public string? SecondarySkill {get; set;}
        
        [Required]
        [DisplayName("Ratings on Skill")]
        public int ratingsInSkill {get; set;}
        
        [Required]
        [DisplayName("Experiences in Skills")]
        public int experienceInSkill {get; set;}
    }
}