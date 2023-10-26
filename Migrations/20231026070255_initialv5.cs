using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrungTamLuaDao.Migrations
{
    /// <inheritdoc />
    public partial class initialv5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "HomeTown",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "HomeTown",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "communeID",
                table: "Tutors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "districtID",
                table: "Tutors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "provinceID",
                table: "Tutors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "communeID",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "districtID",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "provinceID",
                table: "Students",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "communeID",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "districtID",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "provinceID",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "communeID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "districtID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "provinceID",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeTown",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeTown",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
