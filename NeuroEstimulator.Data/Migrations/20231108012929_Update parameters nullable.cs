using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeuroEstimulator.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updateparametersnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_SessionParameters_ParametersId",
                table: "Patient");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParametersId",
                table: "Patient",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_SessionParameters_ParametersId",
                table: "Patient",
                column: "ParametersId",
                principalTable: "SessionParameters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_SessionParameters_ParametersId",
                table: "Patient");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParametersId",
                table: "Patient",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_SessionParameters_ParametersId",
                table: "Patient",
                column: "ParametersId",
                principalTable: "SessionParameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
