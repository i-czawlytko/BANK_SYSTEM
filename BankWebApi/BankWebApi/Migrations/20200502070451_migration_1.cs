using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankWebApi.Migrations
{
    public partial class migration_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyClients",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    company_name = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    parent_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyClients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    owner_id = table.Column<int>(nullable: false),
                    amount = table.Column<decimal>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    percent = table.Column<int>(nullable: false),
                    owner_type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    owner_id = table.Column<int>(nullable: false),
                    amount = table.Column<decimal>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    cap = table.Column<bool>(nullable: false),
                    owner_type = table.Column<string>(nullable: true),
                    percent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Giros",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    owner_id = table.Column<int>(nullable: false),
                    amount = table.Column<decimal>(nullable: false),
                    create_date = table.Column<DateTime>(nullable: false),
                    owner_type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giros", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PhysClients",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    client_name = table.Column<string>(nullable: true),
                    birth_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysClients", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyClients");

            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Giros");

            migrationBuilder.DropTable(
                name: "PhysClients");
        }
    }
}
