using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieApp.ProfileApi.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_genre",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_genre", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_movie",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    synopsis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    pathM3U8File = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    dt_release = table.Column<DateTime>(type: "datetime2", nullable: false),
                    views = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    dt_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dt_update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_movie", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Profile",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dt_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dt_update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Profile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_genre_movie",
                columns: table => new
                {
                    GenriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoviesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_genre_movie", x => new { x.GenriesId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_tb_genre_movie_tb_genre_GenriesId",
                        column: x => x.GenriesId,
                        principalTable: "tb_genre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_genre_movie_tb_movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "tb_movie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_favorites_movies",
                columns: table => new
                {
                    FavoritesMoviesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FavoritesProfilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_favorites_movies", x => new { x.FavoritesMoviesId, x.FavoritesProfilesId });
                    table.ForeignKey(
                        name: "FK_tb_favorites_movies_tb_movie_FavoritesMoviesId",
                        column: x => x.FavoritesMoviesId,
                        principalTable: "tb_movie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_favorites_movies_tb_Profile_FavoritesProfilesId",
                        column: x => x.FavoritesProfilesId,
                        principalTable: "tb_Profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_rating",
                columns: table => new
                {
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    score = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    dt_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dt_update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_rating", x => new { x.ProfileId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_tb_rating_tb_movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tb_movie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_rating_tb_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "tb_Profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tb_genre",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("09e78d02-b66a-4f94-84bd-61bde10b003f"), "Dança" },
                    { new Guid("1bc31e4c-75a0-4f42-affc-0a770b0dc5e2"), "Cinema de arte" },
                    { new Guid("1c22f87b-2ace-4e29-a01f-66ee59a939bf"), "Ação" },
                    { new Guid("287f4e35-3487-43d6-8ad9-b9eaafb53904"), "Guerra" },
                    { new Guid("28efeafa-e04c-4323-8e9d-333d89588586"), "Filmes com truques" },
                    { new Guid("3a6d12e4-d4d0-4f31-b460-57e049474d54"), "Musical" },
                    { new Guid("40c3f416-3d3e-4024-9987-e6eed475dfad"), "Comédia" },
                    { new Guid("483f0cb6-244a-41c3-b42c-64d7d45e7f75"), "Thriller" },
                    { new Guid("4a61fd49-6ea3-467e-b791-f1d520b990d3"), "Aventura" },
                    { new Guid("50602f64-ae1e-47ea-9b77-298afaf7c714"), "Ficção científica" },
                    { new Guid("555fb230-e24e-4e95-836d-a6a039659d02"), "Faroeste" },
                    { new Guid("5cc9ebea-f2d4-49c2-9972-af0af68ab078"), "Docuficção" },
                    { new Guid("670f2d61-62c0-43d4-bcf5-851980624cf1"), "Comédia de terror" },
                    { new Guid("7dc695db-c624-4854-9480-91fb587a91f6"), "Fantasia" },
                    { new Guid("8b911e2c-806c-4a2f-9d15-47b43a619c65"), "Comédia romântica" },
                    { new Guid("9c928366-2a2b-4b7d-a2c8-80264b40165d"), "Fantasia científica" },
                    { new Guid("9dd4aea2-8b14-4784-b439-472bd540ebba"), "Policial" },
                    { new Guid("aab1ce2a-9a2c-45d3-8f99-55d4adb13cd6"), "Espionagem" },
                    { new Guid("b1d27796-2b55-4020-b64d-a3959d71b6c6"), "Comédia dramática" },
                    { new Guid("c5a7f341-30dc-4fdd-864a-6b27f8f2e829"), "Drama" },
                    { new Guid("c822beae-5132-488d-96b2-9b818ca2570d"), "Terror" },
                    { new Guid("edb5e7e7-0ed9-442c-a8fd-1defa4f2432f"), "Documentário" },
                    { new Guid("f662e40e-c6a5-4d45-a399-240775983aa1"), "Mistério" },
                    { new Guid("f6974b9e-7a7e-48b0-b3ad-aa8348265f7b"), "Romance" },
                    { new Guid("f9d9e4fb-45e8-4359-8926-f92a448b3ca6"), "Comédia de ação" },
                    { new Guid("fa15737b-b921-4fe6-9150-ea10e775af74"), "Chanchada" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_favorites_movies_FavoritesProfilesId",
                table: "tb_favorites_movies",
                column: "FavoritesProfilesId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_genre_name",
                table: "tb_genre",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_genre_movie_MoviesId",
                table: "tb_genre_movie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_movie_name_dt_release",
                table: "tb_movie",
                columns: new[] { "name", "dt_release" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_rating_MovieId",
                table: "tb_rating",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_favorites_movies");

            migrationBuilder.DropTable(
                name: "tb_genre_movie");

            migrationBuilder.DropTable(
                name: "tb_rating");

            migrationBuilder.DropTable(
                name: "tb_genre");

            migrationBuilder.DropTable(
                name: "tb_movie");

            migrationBuilder.DropTable(
                name: "tb_Profile");
        }
    }
}
