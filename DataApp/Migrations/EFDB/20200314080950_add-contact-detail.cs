using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataApp.Migrations.EFDB
{
    public partial class addcontactdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ContactDetailsId",
                table: "Supplier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactLocation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    LocationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactDetails_ContactLocation_LocationId",
                        column: x => x.LocationId,
                        principalTable: "ContactLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ContactDetailsId",
                table: "Supplier",
                column: "ContactDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_LocationId",
                table: "ContactDetails",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_ContactDetails_ContactDetailsId",
                table: "Supplier",
                column: "ContactDetailsId",
                principalTable: "ContactDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_ContactDetails_ContactDetailsId",
                table: "Supplier");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "ContactLocation");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_ContactDetailsId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ContactDetailsId",
                table: "Supplier");
        }
    }
}
