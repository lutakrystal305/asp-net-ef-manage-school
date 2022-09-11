using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSchool.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3c8a9335-836f-4555-92aa-b9ca6b650914", "AQAAAAEAACcQAAAAEAR3/xZTDLf9DBEFS7mkvBpzHwj8Uch0D5GXzEzix0XPE0TDqYMnsRuz7dhH73YH3g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fd6d7736-c9ce-4bfa-9e18-374e881af4f4", "AQAAAAEAACcQAAAAEL4EwwbHe/urmxee+riVUsoKXgMrKtusMXEpEFCLc+2bYK9WRJ4hZYaplVw4Xvq//A==" });
        }
    }
}
