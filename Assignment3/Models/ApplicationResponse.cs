using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment3.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public int year { get; set; }
        [Required]
        public string director { get; set; }
        [Required]
        public string rating { get; set; }
        [Required]
        public bool edited { get; set; }
        [Required]
        public string lentTo { get; set; }
        [Required]
        public string notes { get; set; }
    }

}

