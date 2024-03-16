using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Group5ManagementLibrary.Migrations
{
    /// <inheritdoc />
    public partial class sdvfsdfds44d1114t : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Bookings",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bookings",
                newName: "BookingId");
        }
    }
}
