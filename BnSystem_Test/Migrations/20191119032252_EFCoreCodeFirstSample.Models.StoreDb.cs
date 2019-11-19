using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BnSystem_Test.Migrations
{
    public partial class EFCoreCodeFirstSampleModelsStoreDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IBAN = table.Column<string>(maxLength: 20, nullable: true),
                    active_status = table.Column<string>(maxLength: 10, nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    create_user = table.Column<string>(maxLength: 50, nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    update_user = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bill_no = table.Column<string>(maxLength: 50, nullable: true),
                    active_status = table.Column<string>(maxLength: 10, nullable: true),
                    create_date = table.Column<DateTime>(nullable: true),
                    create_user = table.Column<string>(maxLength: 50, nullable: true),
                    update_date = table.Column<DateTime>(nullable: true),
                    update_user = table.Column<string>(maxLength: 50, nullable: true),
                    Accounts_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccTransfers_Accounts_Accounts_Id",
                        column: x => x.Accounts_Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccTransfers_Accounts_Id",
                table: "AccTransfers",
                column: "Accounts_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccTransfers");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
