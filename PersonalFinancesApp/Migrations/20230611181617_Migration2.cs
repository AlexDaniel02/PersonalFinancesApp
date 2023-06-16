using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PersonalFinancesApp.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Persons_PersonId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Categories_CategoryId",
                table: "Incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Persons_PersonId",
                table: "Incomes");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_PersonId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_PersonId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Incomes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_CategoryId",
                table: "Incomes",
                newName: "IX_Incomes_UserId");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Expenses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserId",
                table: "Expenses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Users_UserId",
                table: "Incomes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Users_UserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Users_UserId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_UserId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Incomes",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_UserId",
                table: "Incomes",
                newName: "IX_Incomes_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Incomes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Expenses",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_PersonId",
                table: "Incomes",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PersonId",
                table: "Expenses",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Persons_PersonId",
                table: "Expenses",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Categories_CategoryId",
                table: "Incomes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Persons_PersonId",
                table: "Incomes",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
