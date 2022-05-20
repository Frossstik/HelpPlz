using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebStore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    orderTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    shortDesc = table.Column<string>(nullable: true),
                    longDesc = table.Column<string>(nullable: true),
                    img = table.Column<string>(nullable: true),
                    price = table.Column<double>(nullable: false),
                    isFavourite = table.Column<bool>(nullable: false),
                    available = table.Column<bool>(nullable: false),
                    categoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_category_categoryID",
                        column: x => x.categoryID,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<int>(nullable: false),
                    productId = table.Column<int>(nullable: false),
                    price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_orderId",
                        column: x => x.orderId,
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_product_productId",
                        column: x => x.productId,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "webStoreCartItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productid = table.Column<int>(nullable: true),
                    price = table.Column<double>(nullable: false),
                    WebStoreCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_webStoreCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_webStoreCartItem_product_productid",
                        column: x => x.productid,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_orderId",
                table: "OrderDetail",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_productId",
                table: "OrderDetail",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_product_categoryID",
                table: "product",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_webStoreCartItem_productid",
                table: "webStoreCartItem",
                column: "productid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "webStoreCartItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
