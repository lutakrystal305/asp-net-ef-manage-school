using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSchool.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f5308b22-c118-4cc2-8ae5-02c087483e0a", "AQAAAAEAACcQAAAAEHzgpabQwCqr/eydHWYKHf3pYNgv5uMzI+/b1De+6IvMZuLntfmMyjn2SfVtbfp/Xw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3c8a9335-836f-4555-92aa-b9ca6b650914", "AQAAAAEAACcQAAAAEAR3/xZTDLf9DBEFS7mkvBpzHwj8Uch0D5GXzEzix0XPE0TDqYMnsRuz7dhH73YH3g==" });
        }
    }
}
