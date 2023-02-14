using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibraryApp.Data.Migrations
{
    public partial class MaybeItHelps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEGTjLU8NM99z1T+RIJeToFiuO4yP5X0q9Ge7EjZL67tOycv/DdYdeujrkXAEISp5qA==");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEEgamGUkMvfEvqACrRi+VTBhNNw1/MnnlZdCxod426CGoh+gDL7gUmmo0V76fz96Nw==");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEPSARBQNVLxKDrrt9V4spV3B3/RkUejmHFgXjJ5UtwVSN9LvRTBNa29W9J2mRfr7pw==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "library");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "member");
        }
    }
}
