using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetTheRide.DataAccess.Migrations
{
    public partial class ConfigureUserTripRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_trips_trip_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_trip_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "trip_id",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "passenger_trip_id",
                table: "users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "driver_id",
                table: "trips",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_users_passenger_trip_id",
                table: "users",
                column: "passenger_trip_id");

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

            migrationBuilder.AddForeignKey(
                name: "fk_users_trips_trip_id",
                table: "users",
                column: "passenger_trip_id",
                principalTable: "trips",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_trips_users_driver_id",
                table: "trips");

            migrationBuilder.DropForeignKey(
                name: "fk_users_trips_trip_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_passenger_trip_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_trips_driver_id",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "passenger_trip_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "driver_id",
                table: "trips");

            migrationBuilder.AddColumn<int>(
                name: "trip_id",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_users_trip_id",
                table: "users",
                column: "trip_id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_trips_trip_id",
                table: "users",
                column: "trip_id",
                principalTable: "trips",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
