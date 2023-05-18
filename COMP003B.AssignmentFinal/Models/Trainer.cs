using System.ComponentModel.DataAnnotations;

namespace COMP003B.AssignmentFinal.Models
{
	public class Trainer
	{
		
        public int TrainerId { get; set; }

		[Required]
		public string TrainerName { get; set; }

		[Required]
		public string TrainerGender { get; set; }

		// Collection navigation property
		public virtual ICollection<TrainerSpecialty>? TrainerSpecialties { get; set; }
	}
}
