using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrowEasy.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainDescs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birhDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    senior = table.Column<bool>(type: "bit", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkedin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    about = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainDescs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vivencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    client = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    beginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MainDescId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vivencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vivencias_MainDescs_MainDescId",
                        column: x => x.MainDescId,
                        principalTable: "MainDescs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VivenciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Vivencias_VivenciaId",
                        column: x => x.VivenciaId,
                        principalTable: "Vivencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MainDescs",
                columns: new[] { "Id", "about", "birhDate", "email", "linkedin", "name", "senior" },
                values: new object[] { 1, "Excelente prossional", new DateTime(1978, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "al-ramos@hotmail.com", "progalexramos", "Alexsandro Ramos", false });

            migrationBuilder.InsertData(
                table: "Vivencias",
                columns: new[] { "Id", "MainDescId", "beginDate", "client", "endDate", "name" },
                values: new object[] { 1, 1, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SysMap / Claro", new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anlyst Programmer" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "VivenciaId", "description", "name" },
                values: new object[] { 1, 1, "WCF / WebService / SOAP / WebForms / ASP.NET / C#", "Programmer .NET" });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_VivenciaId",
                table: "Activities",
                column: "VivenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vivencias_MainDescId",
                table: "Vivencias",
                column: "MainDescId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Vivencias");

            migrationBuilder.DropTable(
                name: "MainDescs");
        }
    }
}
