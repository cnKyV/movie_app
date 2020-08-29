using Microsoft.EntityFrameworkCore.Migrations;

namespace Movie_API.Migrations
{
    public partial class ActorMovieAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movies_MovieId",
                table: "ActorMovie");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "ActorMovie",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "ActorMovie",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorId",
                table: "ActorMovie",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movies_MovieId",
                table: "ActorMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movies_MovieId",
                table: "ActorMovie");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "ActorMovie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "ActorMovie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorId",
                table: "ActorMovie",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movies_MovieId",
                table: "ActorMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
