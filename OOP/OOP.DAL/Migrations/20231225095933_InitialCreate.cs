using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OOP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Client_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contact_information = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contract = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Client_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.department_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projectRoles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectRoles", x => x.role_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Client_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Order_id);
                    table.ForeignKey(
                        name: "FK_orders_clients_Client_id",
                        column: x => x.Client_id,
                        principalTable: "clients",
                        principalColumn: "Client_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    position = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    salary = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    departament_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_employees_department_departament_id",
                        column: x => x.departament_id,
                        principalTable: "department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    project_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description_ = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status_ = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    start_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    end_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    order_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.project_id);
                    table.ForeignKey(
                        name: "FK_projects_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "Order_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employeesInProject",
                columns: table => new
                {
                    assignment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeesInProject", x => x.assignment_id);
                    table.ForeignKey(
                        name: "FK_employeesInProject_employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employees",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employeesInProject_projectRoles_role_id",
                        column: x => x.role_id,
                        principalTable: "projectRoles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employeesInProject_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "project_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mediaResources",
                columns: table => new
                {
                    resource_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    project_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mediaResources", x => x.resource_id);
                    table.ForeignKey(
                        name: "FK_mediaResources_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "project_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "Email", "Name", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, "g_drakin@mail.ru", "Admin", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "803335876", 2 },
                    { 2, "g_drakin@mail.ru", "Moderator", "481f6cc0511143ccdd7e2d1b1b94faf0a700a8b49cd13922a70b5ae28acaa8c5", "803335876", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_departament_id",
                table: "employees",
                column: "departament_id");

            migrationBuilder.CreateIndex(
                name: "IX_employeesInProject_employee_id",
                table: "employeesInProject",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_employeesInProject_project_id",
                table: "employeesInProject",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_employeesInProject_role_id",
                table: "employeesInProject",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_mediaResources_project_id",
                table: "mediaResources",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_Client_id",
                table: "orders",
                column: "Client_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_order_id",
                table: "projects",
                column: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeesInProject");

            migrationBuilder.DropTable(
                name: "mediaResources");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "projectRoles");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
