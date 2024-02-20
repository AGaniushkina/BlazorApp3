using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared
{
    public class PassengersInfo
    {
        public string? Sex { get; set; } = "";
        [Required]
        [StringLength(100, ErrorMessage = "String is too long.")]
        public string? FirstName { get; set; } = "";
        [Required]
        [StringLength(100, ErrorMessage = "String is too long.")]
        public string? LastName { get; set; } = "";
        public DateTime DateOfBirth { get; set; } = DateTime.Today;
        [Required]
        public string? Document { get; set; } = "";
        [Required]
        public string? DocumentNumber { get; set; } = "";
        public string? DocumentSeries { get; set; } = "";
        public DateTime ExpiryDate { get; set; } = DateTime.Today;
    }
}
