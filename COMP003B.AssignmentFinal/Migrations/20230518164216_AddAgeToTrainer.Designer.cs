﻿// <auto-generated />
using COMP003B.AssignmentFinal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace COMP003B.AssignmentFinal.Migrations
{
    [DbContext(typeof(WebDevAcademyContext))]
    [Migration("20230518164216_AddAgeToTrainer")]
    partial class AddAgeToTrainer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("COMP003B.AssignmentFinal.Models.Specialty", b =>
                {
                    b.Property<int>("SpecialtyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpecialtyId"));

                    b.Property<string>("SpecialtyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialtyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecialtyId");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("COMP003B.AssignmentFinal.Models.Trainer", b =>
                {
                    b.Property<int>("TrainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainerId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("TrainerGender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainerId");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("COMP003B.AssignmentFinal.Models.TrainerSpecialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("int");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecialtyId");

                    b.HasIndex("TrainerId");

                    b.ToTable("TrainerSpecialties");
                });

            modelBuilder.Entity("COMP003B.AssignmentFinal.Models.TrainerSpecialty", b =>
                {
                    b.HasOne("COMP003B.AssignmentFinal.Models.Specialty", "Specialty")
                        .WithMany("TrainerSpecialties")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("COMP003B.AssignmentFinal.Models.Trainer", "Trainer")
                        .WithMany("TrainerSpecialties")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialty");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("COMP003B.AssignmentFinal.Models.Specialty", b =>
                {
                    b.Navigation("TrainerSpecialties");
                });

            modelBuilder.Entity("COMP003B.AssignmentFinal.Models.Trainer", b =>
                {
                    b.Navigation("TrainerSpecialties");
                });
#pragma warning restore 612, 618
        }
    }
}
