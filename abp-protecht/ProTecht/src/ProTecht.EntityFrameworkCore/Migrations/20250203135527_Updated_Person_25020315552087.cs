using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProTecht.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Person_25020315552087 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AppPeople",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "AppPeople");
        }
    }
}
