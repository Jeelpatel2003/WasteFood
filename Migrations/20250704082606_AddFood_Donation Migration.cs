using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteFood.Migrations
{
    /// <inheritdoc />
    public partial class AddFood_DonationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Food_Donations",
                columns: table => new
                {
                    Fd_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    D_Id = table.Column<int>(type: "int", nullable: false),
                    Food_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Food_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food_Donations", x => x.Fd_ID);
                    table.ForeignKey(
                        name: "FK_Food_Donations_Donor_D_Id",
                        column: x => x.D_Id,
                        principalTable: "Donor",
                        principalColumn: "D_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Food_Donations_D_Id",
                table: "Food_Donations",
                column: "D_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Food_Donations");
        }
    }
}
