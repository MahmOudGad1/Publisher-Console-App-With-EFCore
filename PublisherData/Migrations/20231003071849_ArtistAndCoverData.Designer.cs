﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PublisherData;

#nullable disable

namespace PublisherData.Migrations
{
    [DbContext(typeof(PubContext))]
    [Migration("20231003071849_ArtistAndCoverData")]
    partial class ArtistAndCoverData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtistCover", b =>
                {
                    b.Property<int>("ArtistsArtistId")
                        .HasColumnType("int");

                    b.Property<int>("CoversCoverId")
                        .HasColumnType("int");

                    b.HasKey("ArtistsArtistId", "CoversCoverId");

                    b.HasIndex("CoversCoverId");

                    b.ToTable("ArtistCover");
                });

            modelBuilder.Entity("PublisherDomain.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            ArtistId = 1,
                            FirstName = "mahmoud",
                            LastName = "gad"
                        },
                        new
                        {
                            ArtistId = 2,
                            FirstName = "dee",
                            LastName = "Bell"
                        },
                        new
                        {
                            ArtistId = 3,
                            FirstName = "kahrine",
                            LastName = "kutharic"
                        });
                });

            modelBuilder.Entity("PublisherDomain.Author", b =>
                {
                    b.Property<int?>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("AuthorId"));

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 4,
                            Firstname = "mah",
                            Lastname = "asccd"
                        },
                        new
                        {
                            AuthorId = 5,
                            Firstname = "mahsx",
                            Lastname = "ascsd"
                        },
                        new
                        {
                            AuthorId = 6,
                            Firstname = "masddh",
                            Lastname = "asc"
                        },
                        new
                        {
                            AuthorId = 7,
                            Firstname = "madsdh",
                            Lastname = "asdsc"
                        },
                        new
                        {
                            AuthorId = 8,
                            Firstname = "madsdh",
                            Lastname = "aswetsc"
                        },
                        new
                        {
                            AuthorId = 9,
                            Firstname = "mahdddd",
                            Lastname = "sdsasc"
                        },
                        new
                        {
                            AuthorId = 10,
                            Firstname = "mahds",
                            Lastname = "ascer"
                        });
                });

            modelBuilder.Entity("PublisherDomain.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("authorId")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("authorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("PublisherDomain.Cover", b =>
                {
                    b.Property<int>("CoverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoverId"));

                    b.Property<bool>("DegetalOnly")
                        .HasColumnType("bit");

                    b.Property<string>("DesignIdeas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CoverId");

                    b.ToTable("Covers");

                    b.HasData(
                        new
                        {
                            CoverId = 1,
                            DegetalOnly = false,
                            DesignIdeas = "How about a left hand in the dark?"
                        },
                        new
                        {
                            CoverId = 2,
                            DegetalOnly = true,
                            DesignIdeas = "Should We Put A clock "
                        },
                        new
                        {
                            CoverId = 3,
                            DegetalOnly = false,
                            DesignIdeas = "Big eaarc in th rclouds "
                        });
                });

            modelBuilder.Entity("ArtistCover", b =>
                {
                    b.HasOne("PublisherDomain.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistsArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PublisherDomain.Cover", null)
                        .WithMany()
                        .HasForeignKey("CoversCoverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PublisherDomain.Book", b =>
                {
                    b.HasOne("PublisherDomain.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("authorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("PublisherDomain.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
