using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpMan.Models
{
    public class EmployeeSkill
    {
        [Key]
        public int Id { get; set; }


        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

        public int SkillId { get; set; }
        [ForeignKey("SkillId")]
        public Skill? Skill { get; set; }


        [Required]
        [DisplayName("Ratings on Skill")]
        [Range(1, 10, ErrorMessage = "Rating Skill Must be between 1-10")]
        public int ratingsInSkill { get; set; }


        [Required]
        [DisplayName("Experiences in Skills")]
        [Range(1, 40, ErrorMessage = "Experience Skill Must be between 1-40")]
        public int experienceInSkill { get; set; }

    }
}