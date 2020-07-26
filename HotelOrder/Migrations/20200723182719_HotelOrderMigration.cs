using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelOrder.Migrations
{
    public partial class HotelOrderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "static_dining_tables",
                columns: table => new
                {
                    dining_table_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dining_table_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    created_time_stamp = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    updated_time_stamp = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    is_deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_static_dining_tables", x => x.dining_table_id);
                });

            migrationBuilder.CreateTable(
                name: "static_menu_headers",
                columns: table => new
                {
                    menu_header_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menu_header_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    created_time_stamp = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    updated_time_stamp = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    is_deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_static_menu_headers", x => x.menu_header_id);
                });

            migrationBuilder.CreateTable(
                name: "static_orders_status",
                columns: table => new
                {
                    order_status_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    created_time_stamp = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    updated_time_stamp = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    is_deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_static_orders_status", x => x.order_status_id);
                });

            migrationBuilder.CreateTable(
                name: "static_preferences",
                columns: table => new
                {
                    preference_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    preference_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    created_time_stamp = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    updated_time_stamp = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    is_deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_static_preferences", x => x.preference_id);
                });

            migrationBuilder.CreateTable(
                name: "static_menus",
                columns: table => new
                {
                    menu_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menu_name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    price = table.Column<decimal>(type: "money", nullable: true),
                    preference_id = table.Column<int>(nullable: true),
                    created_time_stamp = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    updated_time_stamp = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    is_deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    menu_header_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_static_menus", x => x.menu_id);
                    table.ForeignKey(
                        name: "FK_static_menus_static_menu_headers",
                        column: x => x.menu_header_id,
                        principalTable: "static_menu_headers",
                        principalColumn: "menu_header_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_static_menus_static_preferences",
                        column: x => x.preference_id,
                        principalTable: "static_preferences",
                        principalColumn: "preference_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(nullable: true),
                    dining_table_id = table.Column<int>(nullable: true),
                    menu_id = table.Column<int>(nullable: true),
                    created_time_stamp = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    updated_time_stamp = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    is_deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    order_number = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_id);
                    table.UniqueConstraint("AK_orders_order_number", x => x.order_number);
                    table.ForeignKey(
                        name: "FK_orders_static_dining_tables",
                        column: x => x.dining_table_id,
                        principalTable: "static_dining_tables",
                        principalColumn: "dining_table_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_static_menus",
                        column: x => x.menu_id,
                        principalTable: "static_menus",
                        principalColumn: "menu_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_tracking",
                columns: table => new
                {
                    order_tracking_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_status_id = table.Column<int>(nullable: true),
                    order_number = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    created_time_stamp = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    updated_time_stamp = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    is_deleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_tracking", x => x.order_tracking_id);
                    table.ForeignKey(
                        name: "FK_order_tracking_orders",
                        column: x => x.order_number,
                        principalTable: "orders",
                        principalColumn: "order_number",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_tracking_static_orders_status",
                        column: x => x.order_status_id,
                        principalTable: "static_orders_status",
                        principalColumn: "order_status_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_tracking_order_number",
                table: "order_tracking",
                column: "order_number");

            migrationBuilder.CreateIndex(
                name: "IX_order_tracking_order_status_id",
                table: "order_tracking",
                column: "order_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_dining_table_id",
                table: "orders",
                column: "dining_table_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_menu_id",
                table: "orders",
                column: "menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders",
                table: "orders",
                column: "order_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_static_menus_menu_header_id",
                table: "static_menus",
                column: "menu_header_id");

            migrationBuilder.CreateIndex(
                name: "IX_static_menus_preference_id",
                table: "static_menus",
                column: "preference_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_tracking");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "static_orders_status");

            migrationBuilder.DropTable(
                name: "static_dining_tables");

            migrationBuilder.DropTable(
                name: "static_menus");

            migrationBuilder.DropTable(
                name: "static_menu_headers");

            migrationBuilder.DropTable(
                name: "static_preferences");
        }
    }
}
