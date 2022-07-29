using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetTheRide.DataAccess.Migrations
{
    public partial class EditColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_users_user_id",
                table: "vehicles");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "vehicles",
                newName: "driver_id");

            migrationBuilder.RenameIndex(
                name: "ix_vehicles_user_id",
                table: "vehicles",
                newName: "ix_vehicles_driver_id");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_users_driver_id",
                table: "vehicles",
                column: "driver_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_users_driver_id",
                table: "vehicles");

            migrationBuilder.RenameColumn(
                name: "driver_id",
                table: "vehicles",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "ix_vehicles_driver_id",
                table: "vehicles",
                newName: "ix_vehicles_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_users_user_id",
                table: "vehicles",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
