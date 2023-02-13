using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmpCompute.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeNo = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    DOB = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Designation = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    NationalInsuranceNo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    StudentLoan = table.Column<int>(type: "integer", nullable: false),
                    UnionMember = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Postcode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    YearOfTax = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NiNo = table.Column<string>(type: "text", nullable: false),
                    PayDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PayMonth = table.Column<string>(type: "text", nullable: false),
                    TaxYearId = table.Column<int>(type: "integer", nullable: false),
                    TaxCode = table.Column<string>(type: "text", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "money", nullable: false),
                    HoursWorked = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ContractualHours = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    OvertimeHours = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ContractualEarnings = table.Column<decimal>(type: "money", nullable: false),
                    OvertimeEarnings = table.Column<decimal>(type: "money", nullable: false),
                    Tax = table.Column<decimal>(type: "money", nullable: false),
                    NIC = table.Column<decimal>(type: "money", nullable: false),
                    UnionFee = table.Column<decimal>(type: "money", nullable: true),
                    SLC = table.Column<decimal>(type: "money", nullable: true),
                    TotalEarnings = table.Column<decimal>(type: "money", nullable: false),
                    TotalDeduction = table.Column<decimal>(type: "money", nullable: false),
                    NetPayment = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentRecords_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentRecords_TaxYears_TaxYearId",
                        column: x => x.TaxYearId,
                        principalTable: "TaxYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecords_EmployeeId",
                table: "PaymentRecords",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRecords_TaxYearId",
                table: "PaymentRecords",
                column: "TaxYearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentRecords");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TaxYears");
        }
    }
}
