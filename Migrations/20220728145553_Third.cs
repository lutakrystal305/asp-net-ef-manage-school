using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSchool.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9fd9d241-bc7c-4aad-b830-8a60fe3c8003", "AQAAAAEAACcQAAAAED3N7P56oa0Oo2Lv/qGAiGfkD7ChYKScMKta6S7H1EsBuSwfzMfstP3WApt+LnvMbA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f5308b22-c118-4cc2-8ae5-02c087483e0a", "AQAAAAEAACcQAAAAEHzgpabQwCqr/eydHWYKHf3pYNgv5uMzI+/b1De+6IvMZuLntfmMyjn2SfVtbfp/Xw==" });
        }
    }
}
