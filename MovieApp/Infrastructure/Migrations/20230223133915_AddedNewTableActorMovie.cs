using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewTableActorMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Movies_MoviesId",
                schema: "dbo",
                table: "Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Actors_ActorId",
                schema: "dbo",
                table: "MovieGenres");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenres_ActorId",
                schema: "dbo",
                table: "MovieGenres");

            migrationBuilder.DropIndex(
                name: "IX_Actors_MoviesId",
                schema: "dbo",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "ActorId",
                schema: "dbo",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "MoviesId",
                schema: "dbo",
                table: "Actors");

            migrationBuilder.AddColumn<string>(
                name: "MovieTitle",
                schema: "dbo",
                table: "WishListItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "MovieId",
                schema: "dbo",
                table: "Actors",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actors_MovieId",
                schema: "dbo",
                table: "Actors",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_MovieId",
                schema: "dbo",
                table: "Actors",
                column: "MovieId",
                principalSchema: "dbo",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Movies_MovieId",
                schema: "dbo",
                table: "Actors");

            migrationBuilder.DropIndex(
                name: "IX_Actors_MovieId",
                schema: "dbo",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "MovieTitle",
                schema: "dbo",
                table: "WishListItems");

            migrationBuilder.DropColumn(
                name: "MovieId",
                schema: "dbo",
                table: "Actors");

            migrationBuilder.AddColumn<Guid>(
                name: "ActorId",
                schema: "dbo",
                table: "MovieGenres",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MoviesId",
                schema: "dbo",
                table: "Actors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_ActorId",
                schema: "dbo",
                table: "MovieGenres",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_MoviesId",
                schema: "dbo",
                table: "Actors",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_MoviesId",
                schema: "dbo",
                table: "Actors",
                column: "MoviesId",
                principalSchema: "dbo",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_Actors_ActorId",
                schema: "dbo",
                table: "MovieGenres",
                column: "ActorId",
                principalSchema: "dbo",
                principalTable: "Actors",
                principalColumn: "Id");
        }
    }
}
