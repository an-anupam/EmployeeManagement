using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace EmpMan.Models
{
    public class Employee
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [MaxLength(30)]
        [DisplayName("First Name")]
        public string? FirstName {get; set;}
         
        [Required]
        [MaxLength(30)]
        [DisplayName("Last Name")] 
        public string? LastName {get; set;}

        [Required]
        [DisplayName("Date Of Joining")]
        public DateOnly DOJ {get; set;}

        [Required]
        [DisplayName("Designation")]
        [MaxLength(20)]
        public string? Designation {get; set;}

        [Required]
        [DisplayName("Email")]
        [MaxLength(40)]
        public string? Email {get; set;}
        
        public int DepartmentId {get; set;}

        [ForeignKey("DepartmentId")]
        [ValidateNever]
        public Department? Department {get; set;}
    }
}