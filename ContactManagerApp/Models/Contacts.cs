using System;
using System.ComponentModel.DataAnnotations;

namespace ContactManagerApp.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public bool Married { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        // Helper property to display "Yes" or "No"
        public string MarriedDisplay => Married ? "Yes" : "No";
    }
}
