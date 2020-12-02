using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBTest.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "testobj");

            migrationBuilder.CreateTable(
                name: "Obj",
                schema: "testobj",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeIndex = table.Column<DateTime>(nullable: false),
                    DateTimeValue = table.Column<DateTime>(nullable: false),
                    DateTime2Index = table.Column<DateTimeOffset>(nullable: false),
                    DateTime2Value = table.Column<DateTimeOffset>(nullable: false),
                    IntIndex = table.Column<int>(nullable: false),
                    IntValue = table.Column<int>(nullable: false),
                    LongIndex = table.Column<long>(nullable: false),
                    LongValue = table.Column<long>(nullable: false),
                    FloatIndex = table.Column<float>(nullable: false),
                    FloatValue = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obj", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obj_DateTime2Index",
                schema: "testobj",
                table: "Obj",
                column: "DateTime2Index");

            migrationBuilder.CreateIndex(
                name: "IX_Obj_DateTimeIndex",
                schema: "testobj",
                table: "Obj",
                column: "DateTimeIndex");

            migrationBuilder.CreateIndex(
                name: "IX_Obj_FloatIndex",
                schema: "testobj",
                table: "Obj",
                column: "FloatIndex");

            migrationBuilder.CreateIndex(
                name: "IX_Obj_IntIndex",
                schema: "testobj",
                table: "Obj",
                column: "IntIndex");

            migrationBuilder.CreateIndex(
                name: "IX_Obj_LongIndex",
                schema: "testobj",
                table: "Obj",
                column: "LongIndex");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obj",
                schema: "testobj");
        }
    }
}
