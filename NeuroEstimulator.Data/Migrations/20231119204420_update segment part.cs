using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeuroEstimulator.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatesegmentpart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Repetitions",
                table: "Session");

            migrationBuilder.DropColumn(
                name: "Repetitions",
                table: "Patient");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "SessionSegment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 19, 17, 44, 20, 373, DateTimeKind.Local).AddTicks(7999),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "Emergency",
                table: "SessionSegment",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SmgDetected",
                table: "SessionSegment",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "SessionPhoto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 19, 17, 44, 20, 370, DateTimeKind.Local).AddTicks(7397),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "SessionParameters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 19, 17, 44, 20, 370, DateTimeKind.Local).AddTicks(3425),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Session",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 19, 17, 44, 20, 369, DateTimeKind.Local).AddTicks(7697),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Profile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 19, 17, 44, 20, 368, DateTimeKind.Local).AddTicks(7423),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Patient",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 19, 17, 44, 20, 368, DateTimeKind.Local).AddTicks(2661),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "AccountProfile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 19, 17, 44, 20, 367, DateTimeKind.Local).AddTicks(5087),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Account",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 19, 17, 44, 20, 367, DateTimeKind.Local).AddTicks(804),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emergency",
                table: "SessionSegment");

            migrationBuilder.DropColumn(
                name: "SmgDetected",
                table: "SessionSegment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "SessionSegment",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 19, 17, 44, 20, 373, DateTimeKind.Local).AddTicks(7999));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "SessionPhoto",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 19, 17, 44, 20, 370, DateTimeKind.Local).AddTicks(7397));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "SessionParameters",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 19, 17, 44, 20, 370, DateTimeKind.Local).AddTicks(3425));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Session",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 19, 17, 44, 20, 369, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.AddColumn<int>(
                name: "Repetitions",
                table: "Session",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Profile",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 19, 17, 44, 20, 368, DateTimeKind.Local).AddTicks(7423));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Patient",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 19, 17, 44, 20, 368, DateTimeKind.Local).AddTicks(2661));

            migrationBuilder.AddColumn<int>(
                name: "Repetitions",
                table: "Patient",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "AccountProfile",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 19, 17, 44, 20, 367, DateTimeKind.Local).AddTicks(5087));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Account",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 19, 17, 44, 20, 367, DateTimeKind.Local).AddTicks(804));
        }
    }
}
