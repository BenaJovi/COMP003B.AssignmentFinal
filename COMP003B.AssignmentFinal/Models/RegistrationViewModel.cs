using System.ComponentModel.DataAnnotations;

namespace COMP003B.AssignmentFinal.Models
{
    public class RegistrationViewModel
    {
      
        [Required]
        [StringLength(100)]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string? UserEmail { get; set; }
        [Required]
        [Phone]
        public string? UserPhoneNumber { get; set; }
        [Required]
        public string? UserAge { get; set; }

    }
}

