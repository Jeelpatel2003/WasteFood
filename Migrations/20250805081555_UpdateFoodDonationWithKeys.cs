using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteFood.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFoodDonationWithKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodDescription",
                table: "Food_Donation");

            migrationBuilder.DropColumn(
                name: "FoodName",
                table: "Food_Donation");

            migrationBuilder.CreateIndex(
                name: "IX_Food_Donation_D_Id",
                table: "Food_Donation",
                column: "D_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Donation_Donor_D_Id",
                table: "Food_Donation",
                column: "D_Id",
                principalTable: "Donor",
                principalColumn: "D_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Donation_Donor_D_Id",
                table: "Food_Donation");

            migrationBuilder.DropIndex(
                name: "IX_Food_Donation_D_Id",
                table: "Food_Donation");

            migrationBuilder.AddColumn<string>(
                name: "FoodDescription",
                table: "Food_Donation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FoodName",
                table: "Food_Donation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
