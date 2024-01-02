using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace EmpMan.Models
{
    public class Skill
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [DisplayName("Skill")]
        public string? allSkills {get; set;}

        //  [Required]
        // [DisplayName("Secondary Skill")]
        // public string? SecondarySkill {get; set;}
        
        [Required]
        [DisplayName("Ratings on Skill")]
        public int ratingsInSkill {get; set;}
        
        [Required]
        [DisplayName("Experiences in Skills")]
        [Range(1,40, ErrorMessage = "Experience Skill Must be between 1-40")]
        public int experienceInSkill {get; set;}
    
        public int EmployeeId { get; set; }

        // Navigation property to link the Skill with the corresponding Employee
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }
    
    }
}