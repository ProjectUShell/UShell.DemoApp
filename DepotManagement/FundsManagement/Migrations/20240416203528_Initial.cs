using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundsManagement.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "fds");

            migrationBuilder.CreateTable(
                name: "Depots",
                schema: "fds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepotNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funds",
                schema: "fds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FundsTransactions",
                schema: "fds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepotId = table.Column<int>(type: "int", nullable: false),
                    FundId = table.Column<int>(type: "int", nullable: false),
                    Cash = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Shares = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kind = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundsTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundsTransactions_Depots_DepotId",
                        column: x => x.DepotId,
                        principalSchema: "fds",
                        principalTable: "Depots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundsTransactions_Funds_FundId",
                        column: x => x.FundId,
                        principalSchema: "fds",
                        principalTable: "Funds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundsTransactions_DepotId",
                schema: "fds",
                table: "FundsTransactions",
                column: "DepotId");

            migrationBuilder.CreateIndex(
                name: "IX_FundsTransactions_FundId",
                schema: "fds",
                table: "FundsTransactions",
                column: "FundId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundsTransactions",
                schema: "fds");

            migrationBuilder.DropTable(
                name: "Depots",
                schema: "fds");

            migrationBuilder.DropTable(
                name: "Funds",
                schema: "fds");
        }
    }
}
