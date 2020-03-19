using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddEnumFuel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fuel",
                table: "JobCards",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fuel",
                table: "JobCards",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
