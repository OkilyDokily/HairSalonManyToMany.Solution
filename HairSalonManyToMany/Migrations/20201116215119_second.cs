using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairSalon.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Stylists_StylistId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_StylistId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "StylistId",
                table: "Clients");

            migrationBuilder.CreateTable(
                name: "ClientStylists",
                columns: table => new
                {
                    ClientStylistId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    StylistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientStylists", x => x.ClientStylistId);
                    table.ForeignKey(
                        name: "FK_ClientStylists_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientStylists_Stylists_StylistId",
                        column: x => x.StylistId,
                        principalTable: "Stylists",
                        principalColumn: "StylistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientStylists_ClientId",
                table: "ClientStylists",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientStylists_StylistId",
                table: "ClientStylists",
                column: "StylistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientStylists");

            migrationBuilder.AddColumn<int>(
                name: "StylistId",
                table: "Clients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_StylistId",
                table: "Clients",
                column: "StylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Stylists_StylistId",
                table: "Clients",
                column: "StylistId",
                principalTable: "Stylists",
                principalColumn: "StylistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
