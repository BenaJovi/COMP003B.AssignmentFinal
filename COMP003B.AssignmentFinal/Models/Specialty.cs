using System.ComponentModel.DataAnnotations;

namespace COMP003B.AssignmentFinal.Models
{
	public class Specialty
	{
		public int SpecialtyId { get; set; }

     
        [Required]
		public string SpecialtyName { get; set; }
		[Required]
		public string SpecialtyType { get; set; }

		// Collection navigation property
		public virtual ICollection<TrainerSpecialty>? TrainerSpecialties { get; set; }
	}
}
