using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopsRUs.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    IsEmployee = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsAffiliate = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    DiscountType = table.Column<string>(type: "TEXT", nullable: true),
                    Percentage = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DateCreated", "DateModified", "FirstName", "IsAffiliate", "IsDeleted", "IsEmployee", "LastName" },
                values: new object[] { new Guid("298bd642-113f-41bc-a60f-4fe6ebab78d6"), new DateTime(2021, 2, 22, 0, 17, 24, 881, DateTimeKind.Local).AddTicks(4911), new DateTime(2021, 2, 22, 0, 17, 24, 884, DateTimeKind.Local).AddTicks(211), "Jane", true, false, false, "Doe" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DateCreated", "DateModified", "FirstName", "IsAffiliate", "IsDeleted", "IsEmployee", "LastName" },
                values: new object[] { new Guid("3546ea9a-661f-4332-83a8-1024258ea7b9"), new DateTime(2021, 2, 22, 0, 17, 24, 884, DateTimeKind.Local).AddTicks(7841), new DateTime(2021, 2, 22, 0, 17, 24, 884, DateTimeKind.Local).AddTicks(7860), "Bash", false, false, true, "Ali" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DateCreated", "DateModified", "FirstName", "IsAffiliate", "IsDeleted", "IsEmployee", "LastName" },
                values: new object[] { new Guid("45018454-e409-4d64-ac8e-4cc9a6b1e1b9"), new DateTime(2016, 2, 22, 0, 17, 24, 884, DateTimeKind.Local).AddTicks(9305), new DateTime(2021, 2, 22, 0, 17, 24, 884, DateTimeKind.Local).AddTicks(9297), "Shina", false, false, false, "Peters" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DateCreated", "DateModified", "FirstName", "IsAffiliate", "IsDeleted", "IsEmployee", "LastName" },
                values: new object[] { new Guid("e38c35a7-9ecf-4112-a845-ff3aeb6cd991"), new DateTime(2021, 2, 22, 0, 17, 24, 884, DateTimeKind.Local).AddTicks(9601), new DateTime(2021, 2, 22, 0, 17, 24, 884, DateTimeKind.Local).AddTicks(9608), "Victor", false, false, false, "Ifeanyi" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "DateCreated", "DateModified", "DiscountType", "IsDeleted", "Name", "Percentage" },
                values: new object[] { new Guid("ae43c021-4a23-439e-a402-0682499a932f"), new DateTime(2021, 2, 22, 0, 17, 24, 889, DateTimeKind.Local).AddTicks(6801), new DateTime(2021, 2, 22, 0, 17, 24, 889, DateTimeKind.Local).AddTicks(6840), "discount_for_affiliate", false, "Discount For Affiliate", 10m });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "DateCreated", "DateModified", "DiscountType", "IsDeleted", "Name", "Percentage" },
                values: new object[] { new Guid("f42fe41d-a8e1-427a-b916-1692a128311a"), new DateTime(2021, 2, 22, 0, 17, 24, 891, DateTimeKind.Local).AddTicks(6741), new DateTime(2021, 2, 22, 0, 17, 24, 891, DateTimeKind.Local).AddTicks(6779), "discount_for_employees", false, "Discount For Employees", 30m });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "DateCreated", "DateModified", "DiscountType", "IsDeleted", "Name", "Percentage" },
                values: new object[] { new Guid("a7fe0188-59a0-4924-93a8-e990ee7ef8f3"), new DateTime(2021, 2, 22, 0, 17, 24, 891, DateTimeKind.Local).AddTicks(6800), new DateTime(2021, 2, 22, 0, 17, 24, 891, DateTimeKind.Local).AddTicks(6804), "discount_for_loyal_customers", false, "Discount For Loyal Customers", 0m });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "DateCreated", "DateModified", "DiscountType", "IsDeleted", "Name", "Percentage" },
                values: new object[] { new Guid("4cc77530-874c-4d6f-a459-6d6d04d5b899"), new DateTime(2021, 2, 22, 0, 17, 24, 891, DateTimeKind.Local).AddTicks(6813), new DateTime(2021, 2, 22, 0, 17, 24, 891, DateTimeKind.Local).AddTicks(6817), "every_100_dollar_discount", false, "Every 100 Dollar Discount", 0m });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
