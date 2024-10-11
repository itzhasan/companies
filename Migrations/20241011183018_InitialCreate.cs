using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employ_Departments_DepartmentId",
                table: "Employ");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employ",
                table: "Employ");

            migrationBuilder.RenameTable(
                name: "Employ",
                newName: "Employs");

            migrationBuilder.RenameIndex(
                name: "IX_Employ_DepartmentId",
                table: "Employs",
                newName: "IX_Employs_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employs",
                table: "Employs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employs_Departments_DepartmentId",
                table: "Employs",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employs_Departments_DepartmentId",
                table: "Employs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employs",
                table: "Employs");

            migrationBuilder.RenameTable(
                name: "Employs",
                newName: "Employ");

            migrationBuilder.RenameIndex(
                name: "IX_Employs_DepartmentId",
                table: "Employ",
                newName: "IX_Employ_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employ",
                table: "Employ",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employ_Departments_DepartmentId",
                table: "Employ",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
