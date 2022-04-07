using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Currencyconverter.Data.Migrations
{
    public partial class appdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    transactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amountFrom = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    amountTo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    currencyFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currencyTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.transactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");
        }
    }
}
