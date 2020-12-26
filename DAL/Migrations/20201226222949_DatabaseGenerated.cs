using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DatabaseGenerated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7c5d9a6-2584-4ace-86df-559a8480f978",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39724c57-2ec5-4b72-b45a-ad507b44b9f0", "AQAAAAEAACcQAAAAEH+oPd3WVH4LRqH9nAc/yXlNODGngrkDDgTDI6d56P2Yy0ihO27ko993JUS77vjxVA==", "d13cb249-dea4-489a-8e95-06fb4da51093" });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "PositionPK", "HourlyPremium", "PositionName" },
                values: new object[,]
                {
                    { 1, 1.0, "Junior" },
                    { 2, 2.0, "Medium" },
                    { 3, 3.0, "Senior" }
                });

            migrationBuilder.InsertData(
                table: "ProjectComplexityTypes",
                columns: new[] { "ProjectComplexityTypePK", "ProjectComplexityTypeName" },
                values: new object[,]
                {
                    { 1, "Easy" },
                    { 2, "Medium" },
                    { 3, "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "QualificationPK", "HourlyRate", "QualificationName" },
                values: new object[,]
                {
                    { 1, 5.0, "First Qualification" },
                    { 2, 7.0, "Second Qualification" },
                    { 3, 10.0, "Third Qualification" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionPK",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionPK",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "PositionPK",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProjectComplexityTypes",
                keyColumn: "ProjectComplexityTypePK",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectComplexityTypes",
                keyColumn: "ProjectComplexityTypePK",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProjectComplexityTypes",
                keyColumn: "ProjectComplexityTypePK",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "QualificationPK",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "QualificationPK",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "QualificationPK",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7c5d9a6-2584-4ace-86df-559a8480f978",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a50de59b-eb36-4dba-a643-fbd4cf5da871", "AQAAAAEAACcQAAAAEKUd9GKe1SPvC/C0MqJrRy0/Zi4is46Hm0KS2VnoVi0FiF5IPg7ckXowrvtSOuQqkQ==", "54273769-9fca-4f95-94d5-609f75041676" });
        }
    }
}
