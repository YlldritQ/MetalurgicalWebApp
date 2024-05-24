using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_dotnet7.Migrations
{
    /// <inheritdoc />
    public partial class removingIdFromManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Product_Orders",
                table: "Product_Orders");

            migrationBuilder.DropIndex(
                name: "IX_Product_Orders_ProductId",
                table: "Product_Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Product_Orders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product_Orders",
                table: "Product_Orders",
                columns: new[] { "ProductId", "OrderId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Product_Orders",
                table: "Product_Orders");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Product_Orders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product_Orders",
                table: "Product_Orders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Orders_ProductId",
                table: "Product_Orders",
                column: "ProductId");
        }
    }
}
