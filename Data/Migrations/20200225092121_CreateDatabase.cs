using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: false),
                    Address = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SparePart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemCode = table.Column<string>(maxLength: 30, nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    ManufacturersCode = table.Column<string>(maxLength: 30, nullable: false),
                    ManufacturersName = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    LeadTimeDelivery = table.Column<string>(nullable: true),
                    QuantityInStock = table.Column<int>(maxLength: 3, nullable: false),
                    UnitPriceSales = table.Column<float>(maxLength: 5, nullable: false),
                    UnitPricePurchase = table.Column<float>(maxLength: 5, nullable: false),
                    Discount = table.Column<int>(maxLength: 2, nullable: false),
                    VatRate = table.Column<int>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SparePart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegistrationNumber = table.Column<string>(maxLength: 20, nullable: false),
                    CarModel = table.Column<string>(maxLength: 20, nullable: false),
                    EngineNo = table.Column<string>(maxLength: 20, nullable: false),
                    ChassisNo = table.Column<string>(maxLength: 20, nullable: false),
                    Year = table.Column<string>(maxLength: 4, nullable: false),
                    GearSrNo = table.Column<string>(maxLength: 20, nullable: false),
                    GearBoxSrNo = table.Column<string>(maxLength: 20, nullable: false),
                    TurboSrNo = table.Column<string>(maxLength: 20, nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    OdometerReading = table.Column<string>(nullable: true),
                    Fuel = table.Column<string>(maxLength: 15, nullable: false),
                    DateIn = table.Column<DateTime>(nullable: false),
                    DateOutEstimated = table.Column<DateTime>(nullable: false),
                    DateOutActual = table.Column<DateTime>(nullable: true),
                    CustomerComment = table.Column<string>(nullable: true),
                    JobDescription = table.Column<string>(maxLength: 600, nullable: false),
                    Status = table.Column<string>(nullable: false),
                    EmploeeId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobCards_Employees_EmploeeId",
                        column: x => x.EmploeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobCards_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobParts",
                columns: table => new
                {
                    JobCardId = table.Column<int>(nullable: false),
                    SparePartId = table.Column<int>(nullable: false),
                    QuantityInstalled = table.Column<int>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobParts", x => new { x.JobCardId, x.SparePartId });
                    table.ForeignKey(
                        name: "FK_JobParts_JobCards_JobCardId",
                        column: x => x.JobCardId,
                        principalTable: "JobCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobParts_SparePart_SparePartId",
                        column: x => x.SparePartId,
                        principalTable: "SparePart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_EmploeeId",
                table: "JobCards",
                column: "EmploeeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobCards_VehicleId",
                table: "JobCards",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_JobParts_SparePartId",
                table: "JobParts",
                column: "SparePartId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CustomerId",
                table: "Vehicles",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobParts");

            migrationBuilder.DropTable(
                name: "JobCards");

            migrationBuilder.DropTable(
                name: "SparePart");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
