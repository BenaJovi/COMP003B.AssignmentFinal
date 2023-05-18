namespace COMP003B.AssignmentFinal.Models
{
	public class TrainerSpecialty
	{
		public int Id { get; set; }
		public int TrainerId { get; set; }
		public int SpecialtyId { get; set; }

		// Nullable navigation properties
		public virtual Trainer? Trainer { get; set; }
		public virtual Specialty? Specialty { get; set; }
	}
}
