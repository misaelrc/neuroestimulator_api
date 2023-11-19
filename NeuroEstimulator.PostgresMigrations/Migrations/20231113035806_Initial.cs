using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeuroEstimulator.PostgresMigrations.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "varchar(500)", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2023, 11, 13, 0, 58, 6, 238, DateTimeKind.Local).AddTicks(7704)),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Code = table.Column<string>(type: "varchar(80)", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2023, 11, 13, 0, 58, 6, 243, DateTimeKind.Local).AddTicks(2840)),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amplitude = table.Column<double>(type: "double precision", nullable: false),
                    Frequency = table.Column<double>(type: "double precision", nullable: false),
                    PulseWidth = table.Column<double>(type: "double precision", nullable: true),
                    MaxPulseWidth = table.Column<double>(type: "double precision", nullable: true),
                    MinPulseWidth = table.Column<double>(type: "double precision", nullable: true),
                    StimulationTime = table.Column<double>(type: "double precision", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2023, 11, 13, 0, 58, 6, 246, DateTimeKind.Local).AddTicks(9700)),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2023, 11, 13, 0, 58, 6, 239, DateTimeKind.Local).AddTicks(4808)),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountProfile_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountProfile_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    TherapistId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParametersId = table.Column<Guid>(type: "uuid", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    SessionAllowed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CaretakerName = table.Column<string>(type: "text", nullable: true),
                    CaretakerPhone = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2023, 11, 13, 0, 58, 6, 241, DateTimeKind.Local).AddTicks(4411)),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patient_Account_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patient_SessionParameters_ParametersId",
                        column: x => x.ParametersId,
                        principalTable: "SessionParameters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TherapistId = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParametersId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartWristAmplitudeMeasurement = table.Column<double>(type: "double precision", nullable: true),
                    FinishWristAmplitudeMeasurement = table.Column<double>(type: "double precision", nullable: true),
                    SessionDuration = table.Column<int>(type: "integer", nullable: true),
                    Repetitions = table.Column<int>(type: "integer", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FinishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2023, 11, 13, 0, 58, 6, 245, DateTimeKind.Local).AddTicks(5790)),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_Account_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Session_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Session_SessionParameters_ParametersId",
                        column: x => x.ParametersId,
                        principalTable: "SessionParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionPhoto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Path = table.Column<string>(type: "varchar(300)", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2023, 11, 13, 0, 58, 6, 248, DateTimeKind.Local).AddTicks(996)),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionPhoto_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SessionSegment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsedParametersId = table.Column<Guid>(type: "uuid", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Intensity = table.Column<int>(type: "integer", nullable: false),
                    Difficulty = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2023, 11, 13, 0, 58, 6, 249, DateTimeKind.Local).AddTicks(4812)),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionSegment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionSegment_SessionParameters_UsedParametersId",
                        column: x => x.UsedParametersId,
                        principalTable: "SessionParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionSegment_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfile_AccountId",
                table: "AccountProfile",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfile_ProfileId",
                table: "AccountProfile",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_AccountId",
                table: "Patient",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_ParametersId",
                table: "Patient",
                column: "ParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_TherapistId",
                table: "Patient",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_ParametersId",
                table: "Session",
                column: "ParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_PatientId",
                table: "Session",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_TherapistId",
                table: "Session",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionPhoto_SessionId",
                table: "SessionPhoto",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionSegment_SessionId",
                table: "SessionSegment",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionSegment_UsedParametersId",
                table: "SessionSegment",
                column: "UsedParametersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountProfile");

            migrationBuilder.DropTable(
                name: "SessionPhoto");

            migrationBuilder.DropTable(
                name: "SessionSegment");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "SessionParameters");
        }
    }
}
