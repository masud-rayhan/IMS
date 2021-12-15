using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMS.DataAccess.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Color_Color_ColorId",
                table: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Color_ColorId",
                table: "Color");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Color");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ColorId",
                table: "Color",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Color_ColorId",
                table: "Color",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Color_Color_ColorId",
                table: "Color",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
