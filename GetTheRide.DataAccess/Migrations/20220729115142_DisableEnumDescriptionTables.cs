using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetTheRide.DataAccess.Migrations
{
    public partial class DisableEnumDescriptionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trip_state");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trip_state",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trip_state", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "trip_state",
                columns: new[] { "id", "state" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Closed" },
                    { 3, "Canceled" }
                });
        }
    }
}
