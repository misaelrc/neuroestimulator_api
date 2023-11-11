using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeuroEstimulator.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addfieldrepetitionsonpatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Repetitions",
                table: "Patient",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Repetitions",
                table: "Patient");
        }
    }
}
