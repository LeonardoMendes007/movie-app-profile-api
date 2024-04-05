﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieApp.Infra.Data.Persistence;

#nullable disable

namespace MovieApp.ProfileApi.Infra.Migrations
{
    [DbContext(typeof(MovieAppDbContext))]
    partial class MovieAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieApp.ProfileApi.Domain.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_genre", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("1c22f87b-2ace-4e29-a01f-66ee59a939bf"),
                            Name = "Ação"
                        },
                        new
                        {
                            Id = new Guid("4a61fd49-6ea3-467e-b791-f1d520b990d3"),
                            Name = "Aventura"
                        },
                        new
                        {
                            Id = new Guid("1bc31e4c-75a0-4f42-affc-0a770b0dc5e2"),
                            Name = "Cinema de arte"
                        },
                        new
                        {
                            Id = new Guid("fa15737b-b921-4fe6-9150-ea10e775af74"),
                            Name = "Chanchada"
                        },
                        new
                        {
                            Id = new Guid("40c3f416-3d3e-4024-9987-e6eed475dfad"),
                            Name = "Comédia"
                        },
                        new
                        {
                            Id = new Guid("f9d9e4fb-45e8-4359-8926-f92a448b3ca6"),
                            Name = "Comédia de ação"
                        },
                        new
                        {
                            Id = new Guid("670f2d61-62c0-43d4-bcf5-851980624cf1"),
                            Name = "Comédia de terror"
                        },
                        new
                        {
                            Id = new Guid("b1d27796-2b55-4020-b64d-a3959d71b6c6"),
                            Name = "Comédia dramática"
                        },
                        new
                        {
                            Id = new Guid("8b911e2c-806c-4a2f-9d15-47b43a619c65"),
                            Name = "Comédia romântica"
                        },
                        new
                        {
                            Id = new Guid("09e78d02-b66a-4f94-84bd-61bde10b003f"),
                            Name = "Dança"
                        },
                        new
                        {
                            Id = new Guid("edb5e7e7-0ed9-442c-a8fd-1defa4f2432f"),
                            Name = "Documentário"
                        },
                        new
                        {
                            Id = new Guid("5cc9ebea-f2d4-49c2-9972-af0af68ab078"),
                            Name = "Docuficção"
                        },
                        new
                        {
                            Id = new Guid("c5a7f341-30dc-4fdd-864a-6b27f8f2e829"),
                            Name = "Drama"
                        },
                        new
                        {
                            Id = new Guid("aab1ce2a-9a2c-45d3-8f99-55d4adb13cd6"),
                            Name = "Espionagem"
                        },
                        new
                        {
                            Id = new Guid("555fb230-e24e-4e95-836d-a6a039659d02"),
                            Name = "Faroeste"
                        },
                        new
                        {
                            Id = new Guid("7dc695db-c624-4854-9480-91fb587a91f6"),
                            Name = "Fantasia"
                        },
                        new
                        {
                            Id = new Guid("9c928366-2a2b-4b7d-a2c8-80264b40165d"),
                            Name = "Fantasia científica"
                        },
                        new
                        {
                            Id = new Guid("50602f64-ae1e-47ea-9b77-298afaf7c714"),
                            Name = "Ficção científica"
                        },
                        new
                        {
                            Id = new Guid("28efeafa-e04c-4323-8e9d-333d89588586"),
                            Name = "Filmes com truques"
                        },
                        new
                        {
                            Id = new Guid("287f4e35-3487-43d6-8ad9-b9eaafb53904"),
                            Name = "Guerra"
                        },
                        new
                        {
                            Id = new Guid("f662e40e-c6a5-4d45-a399-240775983aa1"),
                            Name = "Mistério"
                        },
                        new
                        {
                            Id = new Guid("3a6d12e4-d4d0-4f31-b460-57e049474d54"),
                            Name = "Musical"
                        },
                        new
                        {
                            Id = new Guid("9dd4aea2-8b14-4784-b439-472bd540ebba"),
                            Name = "Policial"
                        },
                        new
                        {
                            Id = new Guid("f6974b9e-7a7e-48b0-b3ad-aa8348265f7b"),
                            Name = "Romance"
                        },
                        new
                        {
                            Id = new Guid("c822beae-5132-488d-96b2-9b818ca2570d"),
                            Name = "Terror"
                        },
                        new
                        {
                            Id = new Guid("483f0cb6-244a-41c3-b42c-64d7d45e7f75"),
                            Name = "Thriller"
                        });
                });

            modelBuilder.Entity("MovieApp.ProfileApi.Domain.Entities.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_created");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("imageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("PathM3U8File")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("pathM3U8File");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_release");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("synopsis");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_update");

                    b.Property<int>("Views")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("views");

                    b.HasKey("Id");

                    b.HasIndex("Name", "ReleaseDate")
                        .IsUnique();

                    b.ToTable("tb_movie", (string)null);
                });

            modelBuilder.Entity("MovieApp.ProfileApi.Domain.Entities.Rating", b =>
                {
                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("comment");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_created");

                    b.Property<int>("Score")
                        .HasMaxLength(1)
                        .HasColumnType("int")
                        .HasColumnName("score");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_update");

                    b.HasKey("ProfileId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("tb_rating", (string)null);
                });

            modelBuilder.Entity("MovieApp.ProfileApi.Domain.Entities.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_created");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("dt_update");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.ToTable("tb_Profile", (string)null);
                });

            modelBuilder.Entity("tb_favorites_movies", b =>
                {
                    b.Property<Guid>("FavoritesMoviesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FavoritesProfilesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FavoritesMoviesId", "FavoritesProfilesId");

                    b.HasIndex("FavoritesProfilesId");

                    b.ToTable("tb_favorites_movies");
                });

            modelBuilder.Entity("tb_genre_movie", b =>
                {
                    b.Property<Guid>("GenriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MoviesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GenriesId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("tb_genre_movie");
                });

            modelBuilder.Entity("MovieApp.ProfileApi.Domain.Entities.Rating", b =>
                {
                    b.HasOne("MovieApp.ProfileApi.Domain.Entities.Movie", "Movie")
                        .WithMany("Ratings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieApp.ProfileApi.Domain.Entities.Profile", "Profile")
                        .WithMany("Ratings")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("tb_favorites_movies", b =>
                {
                    b.HasOne("MovieApp.ProfileApi.Domain.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("FavoritesMoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieApp.ProfileApi.Domain.Entities.Profile", null)
                        .WithMany()
                        .HasForeignKey("FavoritesProfilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tb_genre_movie", b =>
                {
                    b.HasOne("MovieApp.ProfileApi.Domain.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieApp.ProfileApi.Domain.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieApp.ProfileApi.Domain.Entities.Movie", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("MovieApp.ProfileApi.Domain.Entities.Profile", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
