using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeuroEstimulator.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updateafterallmodifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartedAt",
                table: "SessionSegment");

            migrationBuilder.DropColumn(
                name: "WristAmplitudeMeasurement",
                table: "SessionSegment");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "SessionParameters");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "SessionSegment",
                newName: "Intensity");

            migrationBuilder.RenameColumn(
                name: "PulseDuration",
                table: "SessionParameters",
                newName: "StimulationTime");

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "SessionSegment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "FinishWristAmplitudeMeasurement",
                table: "Session",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedAt",
                table: "Session",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Repetitions",
                table: "Session",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SessionDuration",
                table: "Session",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "StartWristAmplitudeMeasurement",
                table: "Session",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedAt",
                table: "Session",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Session",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ParametersId",
                table: "Patient",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TherapistId",
                table: "Patient",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Patient_ParametersId",
                table: "Patient",
                column: "ParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_TherapistId",
                table: "Patient",
                column: "TherapistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Account_TherapistId",
                table: "Patient",
                column: "TherapistId",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_SessionParameters_ParametersId",
                table: "Patient",
                column: "ParametersId",
                principalTable: "SessionParameters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Account_TherapistId",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_SessionParameters_ParametersId",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_ParametersId",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_TherapistId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "SessionSegment");

            migrationBuilder.DropColumn(
                name: "FinishWristAmplitudeMeasurement",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "FinishedAt",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "Repetitions",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "SessionDuration",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "StartWristAmplitudeMeasurement",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "StartedAt",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "ParametersId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "TherapistId",
                table: "Patient");

            migrationBuilder.RenameColumn(
                name: "Intensity",
                table: "SessionSegment",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "StimulationTime",
                table: "SessionParameters",
                newName: "PulseDuration");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedAt",
                table: "SessionSegment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "WristAmplitudeMeasurement",
                table: "SessionSegment",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Difficulty",
                table: "SessionParameters",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
