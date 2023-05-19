using COMP003B.AssignmentFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.AssignmentFinal.Data
{
    public class WebDevAcademyContext : DbContext
    {
        public WebDevAcademyContext(DbContextOptions<WebDevAcademyContext> options)
            : base(options)
        {
        }
        public DbSet<BuildProfile> BuildProfiles { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<TrainerSpecialty> TrainerSpecialties { get; set; }
    }

}
