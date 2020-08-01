using Microsoft.EntityFrameworkCore.Migrations;

namespace Product.Microservice.Migrations
{
    public partial class ver002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                schema: "products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ConfidentialData",
                schema: "products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Rate",
                schema: "products",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                schema: "products",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfidentialData",
                schema: "products",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "products",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "products",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                schema: "products",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
