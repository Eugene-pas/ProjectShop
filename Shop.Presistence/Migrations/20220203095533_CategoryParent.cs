using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Persistence.Migrations
{
    public partial class CategoryParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_CategoryId",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Category",
                newName: "ParentCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_CategoryId",
                table: "Category",
                newName: "IX_Category_ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentCategoryId",
                table: "Category",
                column: "ParentCategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentCategoryId",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId",
                table: "Category",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_ParentCategoryId",
                table: "Category",
                newName: "IX_Category_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_CategoryId",
                table: "Category",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
