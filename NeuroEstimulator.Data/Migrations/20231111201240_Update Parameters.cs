using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeuroEstimulator.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateParameters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PulseWidth",
                table: "SessionParameters",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<double>(
                name: "MaxPulseWidth",
                table: "SessionParameters",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MinPulseWidth",
                table: "SessionParameters",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxPulseWidth",
                table: "SessionParameters");

            migrationBuilder.DropColumn(
                name: "MinPulseWidth",
                table: "SessionParameters");

            migrationBuilder.AlterColumn<double>(
                name: "PulseWidth",
                table: "SessionParameters",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
