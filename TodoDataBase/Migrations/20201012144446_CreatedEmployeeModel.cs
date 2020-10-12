using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoDataBase.Migrations
{
    public partial class CreatedEmployeeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "TodoItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_EmployeeId",
                table: "TodoItems",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Employees_EmployeeId",
                table: "TodoItems",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Employees_EmployeeId",
                table: "TodoItems");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_EmployeeId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "TodoItems");
        }
    }
}
