using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.CouponAPI.Migrations
{
    public partial class SeedCouponDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "coupon",
                columns: new[] { "Id", "coupon_code", "discount_amount" },
                values: new object[] { 1L, "GEEK10", 10m });

            migrationBuilder.InsertData(
                table: "coupon",
                columns: new[] { "Id", "coupon_code", "discount_amount" },
                values: new object[] { 2L, "GEEK20", 20m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "coupon",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "coupon",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
