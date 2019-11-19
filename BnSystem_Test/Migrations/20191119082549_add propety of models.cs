using Microsoft.EntityFrameworkCore.Migrations;

namespace BnSystem_Test.Migrations
{
    public partial class addpropetyofmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bill_no",
                table: "AccTransfers");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "AccTransfers",
                maxLength: 50,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "action_type",
                table: "AccTransfers",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "is_calculated",
                table: "AccTransfers",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "balance",
                table: "Accounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "AccTransfers");

            migrationBuilder.DropColumn(
                name: "action_type",
                table: "AccTransfers");

            migrationBuilder.DropColumn(
                name: "is_calculated",
                table: "AccTransfers");

            migrationBuilder.DropColumn(
                name: "balance",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "bill_no",
                table: "AccTransfers",
                maxLength: 50,
                nullable: true);
        }
    }
}
