using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RequiredFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dealers",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Artifacts",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dealers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Artifacts",
                type:"float",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
