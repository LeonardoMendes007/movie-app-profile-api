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
                name: "tb_profile",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dt_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dt_update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_profile", x => x.id);
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
                        name: "FK_tb_favorites_movies_tb_profile_FavoritesProfilesId",
                        column: x => x.FavoritesProfilesId,
                        principalTable: "tb_profile",
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
                        name: "FK_tb_rating_tb_profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "tb_profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tb_genre",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("01582970-47ae-4e12-9d21-cd1278ae962a"), "Documentário" },
                    { new Guid("2b9473d6-4ca6-431f-b219-e592f5d7a563"), "Guerra" },
                    { new Guid("2f5c0210-71f1-43e4-bbd6-725b48ac0f29"), "Filmes com truques" },
                    { new Guid("388f4472-3227-4180-8ce4-27b3f6b1d5b1"), "Ação" },
                    { new Guid("45d63e6f-c403-405d-ae6e-73a01d606fc9"), "Musical" },
                    { new Guid("4cd3b891-2900-47d0-ba72-1420c36b3653"), "Chanchada" },
                    { new Guid("51c7d9ff-8303-48c5-bdb7-c07340abe56d"), "Mistério" },
                    { new Guid("64035083-6df0-44b3-9ced-a1542aaf5cf5"), "Fantasia" },
                    { new Guid("66e2d70e-d4b6-4dbb-a5c8-6ef14151712c"), "Comédia romântica" },
                    { new Guid("6c201b8b-4282-4965-b347-778c59de74b1"), "Aventura" },
                    { new Guid("79b6aa69-ac86-4c00-a12b-54969eba8503"), "Comédia de terror" },
                    { new Guid("8023b5ed-3944-40b3-a0a3-4511f01f4b5d"), "Comédia dramática" },
                    { new Guid("80e25cf4-59f0-4859-93e4-d1f5d1a58452"), "Drama" },
                    { new Guid("82892d07-cb22-48d9-83b0-dd6bb2ed7be9"), "Dança" },
                    { new Guid("947b7dce-4f1c-4f7b-a758-ebcc86e97e43"), "Cinema de arte" },
                    { new Guid("a1d847b1-4668-4a8d-942e-f4c7c35702eb"), "Comédia de ação" },
                    { new Guid("a48c915d-4cf0-4972-8ec8-01c233c3eb16"), "Terror" },
                    { new Guid("a48f64d7-d5b6-45a1-b8c7-d4d034895712"), "Docuficção" },
                    { new Guid("a54ef8cf-793a-42b3-bce3-39d2112a1348"), "Faroeste" },
                    { new Guid("a7cc8eae-e731-446c-9b85-ebc9db70107f"), "Comédia" },
                    { new Guid("ccd1d48a-5665-4cff-b866-02d8d9b043e1"), "Espionagem" },
                    { new Guid("d70fc206-397d-4a7e-8770-1fea0af76f69"), "Thriller" },
                    { new Guid("d8d73828-09ff-4254-9f48-400c07dfd4d2"), "Policial" },
                    { new Guid("dcac09a1-1fbd-4f67-ad95-d8fa998fac8e"), "Romance" },
                    { new Guid("f66920c2-3d2e-4fa1-a6e5-2d1d9fd80fd4"), "Fantasia científica" },
                    { new Guid("fcec430e-0c46-4acf-a87e-1aed1855a3b5"), "Ficção científica" }
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
                name: "tb_profile");
        }
    }
}
