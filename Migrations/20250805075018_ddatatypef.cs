using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteFood.Migrations
{
    /// <inheritdoc />
    public partial class ddatatypef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Donation_Donor_D_Id",
                table: "Food_Donation");

            migrationBuilder.DropIndex(
                name: "IX_Food_Donation_D_Id",
                table: "Food_Donation");

            migrationBuilder.RenameColumn(
                name: "FD_Id",
                table: "Food_Donation",
                newName: "DonationId");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNo",
                table: "Food_Donation",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DonationId",
                table: "Food_Donation",
                newName: "FD_Id");

            migrationBuilder.AlterColumn<int>(
                name: "ContactNo",
                table: "Food_Donation",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

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
    }
}
