using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class add_order_category_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b5a92d3-052a-499c-92a4-f6ef631a8578");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d66a111e-4d2e-4764-9696-b746109a81b4", "9996f9ca-3d8f-4989-a6b2-d7614cd5417d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d66a111e-4d2e-4764-9696-b746109a81b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9996f9ca-3d8f-4989-a6b2-d7614cd5417d");

            migrationBuilder.AddColumn<int>(
                name: "CategoryOrderCategoryPK",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1ba68bf3-7f4c-45a6-ab5b-7e9be54e3e47", "fdd41c7d-4879-42d3-a5eb-dc2f28921cd6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a7f0297-c806-4192-95a4-f3be699c4420", "c066d625-dcfc-4e03-a036-045f336c0dae", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "Login", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e7c5d9a6-2584-4ace-86df-559a8480f978", 0, "77a542b6-183f-43cd-87ea-b68156763e1d", "User", "tarikkataryna1999@gmail.com", false, "Taras", null, "Kataryna", false, null, "tarikkataryna1999@gmail.com", null, "TARIKKATARYNA1999@GMAIL.COM", "AQAAAAEAACcQAAAAEIjuYGyuj3Qn/H6aXXYTBo5MjVV/TsaJ4xNCoYu0pzB0knyqwc6cFZNKKnOIv3H9+Q==", null, false, "260b213f-2bd0-4c57-ad4b-d068a64a2d8b", false, "tarikkataryna1999@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1ba68bf3-7f4c-45a6-ab5b-7e9be54e3e47", "e7c5d9a6-2584-4ace-86df-559a8480f978" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CategoryOrderCategoryPK",
                table: "Orders",
                column: "CategoryOrderCategoryPK");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderCategories_CategoryOrderCategoryPK",
                table: "Orders",
                column: "CategoryOrderCategoryPK",
                principalTable: "OrderCategories",
                principalColumn: "OrderCategoryPK",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderCategories_CategoryOrderCategoryPK",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CategoryOrderCategoryPK",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a7f0297-c806-4192-95a4-f3be699c4420");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1ba68bf3-7f4c-45a6-ab5b-7e9be54e3e47", "e7c5d9a6-2584-4ace-86df-559a8480f978" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ba68bf3-7f4c-45a6-ab5b-7e9be54e3e47");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7c5d9a6-2584-4ace-86df-559a8480f978");

            migrationBuilder.DropColumn(
                name: "CategoryOrderCategoryPK",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d66a111e-4d2e-4764-9696-b746109a81b4", "e45ead5c-29e8-43bd-bd4e-59fede94ae82", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b5a92d3-052a-499c-92a4-f6ef631a8578", "98166429-2e54-4861-9928-c3c55b7c7bfe", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "Login", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9996f9ca-3d8f-4989-a6b2-d7614cd5417d", 0, "c4316b18-195d-49cd-8a8c-6ca8591f467d", "User", "tarikkataryna1999@gmail.com", false, "Taras", null, "Kataryna", false, null, "tarikkataryna1999@gmail.com", null, null, "AQAAAAEAACcQAAAAELckq74cbWGV8J7+9TpkzIV77AVNq7Uk3Jrcr+PLSlPiVm0g9APTjrl+VGvuALIwJA==", null, false, "974efafe-4e25-46bf-86f9-331aa00573c5", false, "tarikkataryna1999@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d66a111e-4d2e-4764-9696-b746109a81b4", "9996f9ca-3d8f-4989-a6b2-d7614cd5417d" });
        }
    }
}
