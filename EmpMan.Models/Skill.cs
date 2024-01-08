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

        
    
    }
}