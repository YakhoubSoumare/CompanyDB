using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyDB.Data.Migrations
{
    public partial class seededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrganizationNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TradeUnion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePosition",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    PositionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePosition", x => new { x.EmployeesId, x.PositionsId });
                    table.ForeignKey(
                        name: "FK_EmployeePosition_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePosition_Positions_PositionsId",
                        column: x => x.PositionsId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePositions",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePositions", x => new { x.EmployeeId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_EmployeePositions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name", "OrganizationNumber" },
                values: new object[,]
                {
                    { 1, "Fitness Company", "5555-4444" },
                    { 2, "Test Company", "929292Test" },
                    { 3, "Third Company", "333-333" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Site Responsible" },
                    { 2, "Site Manager" },
                    { 3, "Sales Corporate" },
                    { 4, "Economist" },
                    { 5, "Financial Manager" },
                    { 6, "Market Boss" },
                    { 7, "Marketer" },
                    { 8, "Area Manager" },
                    { 9, "TestPosition" },
                    { 10, "Second TestPosition" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CompanyId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Economy" },
                    { 2, 1, "Market" },
                    { 3, 1, "Sales" },
                    { 4, 1, "Facility" },
                    { 5, 2, "TestDepartment" },
                    { 6, 3, "TestDepartment2" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "FirstName", "LastName", "Salary", "TradeUnion" },
                values: new object[,]
                {
                    { 1, 5, "Yakhoub", "Soumare", 1000.00m, false },
                    { 2, 5, "Christine", "Svensson", 1500.00m, true },
                    { 3, 5, "Ismael", "Smith", 800.00m, false },
                    { 4, 2, "Robban", "Matsson", 2000.00m, true },
                    { 5, 4, "Eric", "Sarr", 2100.00m, false },
                    { 6, 1, "Ahmed", "Winclar", 1900.00m, true },
                    { 7, 2, "Mahe", "Yussuf", 2200.00m, false },
                    { 8, 1, "Jennifer", "Bavul", 1900.00m, false },
                    { 9, 4, "Amina", "Nkuku", 2300.00m, true },
                    { 10, 6, "ttt", "hshs", 200.00m, false }
                });

            migrationBuilder.InsertData(
                table: "EmployeePositions",
                columns: new[] { "EmployeeId", "PositionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 4, 7 },
                    { 5, 3 },
                    { 6, 4 },
                    { 7, 6 },
                    { 8, 5 },
                    { 9, 3 },
                    { 10, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CompanyId",
                table: "Departments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePosition_PositionsId",
                table: "EmployeePosition",
                column: "PositionsId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositions_PositionId",
                table: "EmployeePositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePosition");

            migrationBuilder.DropTable(
                name: "EmployeePositions");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
