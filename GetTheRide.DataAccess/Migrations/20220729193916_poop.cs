using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetTheRide.DataAccess.Migrations
{
    public partial class poop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_trips_users_driver_id",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "ix_trips_driver_id",
                table: "trips");

            migrationBuilder.AlterColumn<int>(
                name: "passenger_trip_id",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "driver_trip_id",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_users_driver_trip_id",
                table: "users",
                column: "driver_trip_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_users_trips_driver_trip_id1",
                table: "users",
                column: "driver_trip_id",
                principalTable: "trips",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_trips_driver_trip_id1",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_driver_trip_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "driver_trip_id",
                table: "users");

            migrationBuilder.AlterColumn<int>(
                name: "passenger_trip_id",
                table: "users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "ix_trips_driver_id",
                table: "trips",
                column: "driver_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_trips_users_driver_id",
                table: "trips",
                column: "driver_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
