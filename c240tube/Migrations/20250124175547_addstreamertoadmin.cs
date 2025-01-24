using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace c240tube.Migrations
{
    /// <inheritdoc />
    public partial class addstreamertoadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StreamerId",
                table: "Video",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Video_StreamerId",
                table: "Video",
                column: "StreamerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Streamer_StreamerId",
                table: "Video",
                column: "StreamerId",
                principalTable: "Streamer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_Streamer_StreamerId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_StreamerId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "StreamerId",
                table: "Video");
        }
    }
}
