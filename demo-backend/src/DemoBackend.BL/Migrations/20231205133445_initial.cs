using Microsoft.EntityFrameworkCore.Migrations;

namespace Security.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "UD");

            migrationBuilder.CreateTable(
                name: "Tenants",
                schema: "UD",
                columns: table => new
                {
                    Uid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "ParkingLocations",
                schema: "UD",
                columns: table => new
                {
                    Uid = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantUid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLocations", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_ParkingLocations_Tenants_TenantUid",
                        column: x => x.TenantUid,
                        principalSchema: "UD",
                        principalTable: "Tenants",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "UD",
                columns: table => new
                {
                    Uid = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantUid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Persons_Tenants_TenantUid",
                        column: x => x.TenantUid,
                        principalSchema: "UD",
                        principalTable: "Tenants",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                schema: "UD",
                columns: table => new
                {
                    LicPlateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParkingLocationUid = table.Column<long>(type: "bigint", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantUid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.LicPlateId);
                    table.ForeignKey(
                        name: "FK_Cars_ParkingLocations_ParkingLocationUid",
                        column: x => x.ParkingLocationUid,
                        principalSchema: "UD",
                        principalTable: "ParkingLocations",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Tenants_TenantUid",
                        column: x => x.TenantUid,
                        principalSchema: "UD",
                        principalTable: "Tenants",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                schema: "UD",
                columns: table => new
                {
                    CarLicPlateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonUid = table.Column<long>(type: "bigint", nullable: false),
                    OwnsCarKeys = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => new { x.CarLicPlateId, x.PersonUid });
                    table.ForeignKey(
                        name: "FK_Drivers_Cars_CarLicPlateId",
                        column: x => x.CarLicPlateId,
                        principalSchema: "UD",
                        principalTable: "Cars",
                        principalColumn: "LicPlateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drivers_Persons_PersonUid",
                        column: x => x.PersonUid,
                        principalSchema: "UD",
                        principalTable: "Persons",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ParkingLocationUid",
                schema: "UD",
                table: "Cars",
                column: "ParkingLocationUid");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TenantUid",
                schema: "UD",
                table: "Cars",
                column: "TenantUid");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_PersonUid",
                schema: "UD",
                table: "Drivers",
                column: "PersonUid");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLocations_TenantUid",
                schema: "UD",
                table: "ParkingLocations",
                column: "TenantUid");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TenantUid",
                schema: "UD",
                table: "Persons",
                column: "TenantUid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers",
                schema: "UD");

            migrationBuilder.DropTable(
                name: "Cars",
                schema: "UD");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "UD");

            migrationBuilder.DropTable(
                name: "ParkingLocations",
                schema: "UD");

            migrationBuilder.DropTable(
                name: "Tenants",
                schema: "UD");
        }
    }
}
