using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProTecht.Migrations
{
    /// <inheritdoc />
    public partial class added_quote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quote",
                table: "AppPeople");

            migrationBuilder.CreateTable(
                name: "AppQuotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vendor = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppQuotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppQuotes_AppPeople_PersonId",
                        column: x => x.PersonId,
                        principalTable: "AppPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppQuotes_PersonId",
                table: "AppQuotes",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppQuotes");

            migrationBuilder.AddColumn<string>(
                name: "Quote",
                table: "AppPeople",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
