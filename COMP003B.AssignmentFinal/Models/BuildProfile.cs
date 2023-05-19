using System.ComponentModel.DataAnnotations;

namespace COMP003B.AssignmentFinal.Models
{
    public class BuildProfile
    {
        public int BuildProfileId { get; set; }

        [Required]
        public string? ProfileGender { get; set; }
        [Required]
        public string? ProfileHeight { get; set; }
        [Required]
        public string? ProfileWeight { get; set; }
        public virtual ICollection<TrainerSpecialty>? TrainerSpecialties { get; set; }

    }
}
