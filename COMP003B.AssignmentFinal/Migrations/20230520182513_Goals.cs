using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP003B.AssignmentFinal.Migrations
{
    /// <inheritdoc />
    public partial class Goals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalId",
                table: "TrainerSpecialties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "TrainerSpecialties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoalWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalHealth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalBenchPress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalSquat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalArmCurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalMileTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.GoalId);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileHeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileGender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerSpecialties_GoalId",
                table: "TrainerSpecialties",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerSpecialties_ProfileId",
                table: "TrainerSpecialties",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerSpecialties_Goals_GoalId",
                table: "TrainerSpecialties",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "GoalId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerSpecialties_Profiles_ProfileId",
                table: "TrainerSpecialties",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainerSpecialties_Goals_GoalId",
                table: "TrainerSpecialties");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerSpecialties_Profiles_ProfileId",
                table: "TrainerSpecialties");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_TrainerSpecialties_GoalId",
                table: "TrainerSpecialties");

            migrationBuilder.DropIndex(
                name: "IX_TrainerSpecialties_ProfileId",
                table: "TrainerSpecialties");

            migrationBuilder.DropColumn(
                name: "GoalId",
                table: "TrainerSpecialties");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "TrainerSpecialties");
        }
    }
}
