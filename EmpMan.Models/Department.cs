using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EmpMan.Models
{
    public class Department
    {
    
        [Key]
        public int Id {get; set;}
        
        [Required]
        [MaxLength(20)] 
        public string? Name {get; set;}
    }
}