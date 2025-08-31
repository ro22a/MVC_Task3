using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicketsSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories\r\nVALUES \r\n('Action'), \r\n('Comedy'), \r\n('Drama'), \r\n('Documentary'), \r\n('Cartoon'), \r\n('Horror')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("truncate table Categories");
        }
    }
}
