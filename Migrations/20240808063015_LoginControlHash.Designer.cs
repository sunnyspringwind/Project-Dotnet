﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using wandermate_backend.Data;

#nullable disable

namespace wandermate_backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240808063015_LoginControlHash")]
    partial class LoginControlHash
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("wandermate_backend.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("FreeCancellation")
                        .HasColumnType("boolean");

                    b.Property<List<string>>("Image")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

                    b.Property<bool>("ReserveNow")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("wandermate_backend.Models.HotelDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("HotelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HotelId")
                        .IsUnique();

                    b.ToTable("HotelDetails");
                });

            modelBuilder.Entity("wandermate_backend.Models.HotelReview", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReviewId"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("HotelId")
                        .HasColumnType("integer");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ReviewId");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelReviews");
                });

            modelBuilder.Entity("wandermate_backend.Models.TravelPackageDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("Image")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TravelPackageId")
                        .HasColumnType("integer");

                    b.Property<string>("Weather")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TravelPackageId")
                        .IsUnique();

                    b.ToTable("TravelPackageDetails");
                });

            modelBuilder.Entity("wandermate_backend.Models.TravelPackageReview", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReviewId"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TravelPackageId")
                        .HasColumnType("integer");

                    b.HasKey("ReviewId");

                    b.HasIndex("TravelPackageId");

                    b.ToTable("TravelPackageReviews");
                });

            modelBuilder.Entity("wandermate_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("wandermate_backend.models.TravelPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("Image")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Weather")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TravelPackage");
                });

            modelBuilder.Entity("wandermate_backend.Models.HotelDetails", b =>
                {
                    b.HasOne("wandermate_backend.Models.Hotel", "Hotel")
                        .WithOne("HotelDetails")
                        .HasForeignKey("wandermate_backend.Models.HotelDetails", "HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("wandermate_backend.Models.HotelReview", b =>
                {
                    b.HasOne("wandermate_backend.Models.Hotel", "Hotel")
                        .WithMany("HotelReviews")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("wandermate_backend.Models.TravelPackageDetails", b =>
                {
                    b.HasOne("wandermate_backend.models.TravelPackage", "TravelPackage")
                        .WithOne("TravelPackageDetails")
                        .HasForeignKey("wandermate_backend.Models.TravelPackageDetails", "TravelPackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TravelPackage");
                });

            modelBuilder.Entity("wandermate_backend.Models.TravelPackageReview", b =>
                {
                    b.HasOne("wandermate_backend.models.TravelPackage", "TravelPackage")
                        .WithMany("TravelPackageReviews")
                        .HasForeignKey("TravelPackageId");

                    b.Navigation("TravelPackage");
                });

            modelBuilder.Entity("wandermate_backend.Models.Hotel", b =>
                {
                    b.Navigation("HotelDetails");

                    b.Navigation("HotelReviews");
                });

            modelBuilder.Entity("wandermate_backend.models.TravelPackage", b =>
                {
                    b.Navigation("TravelPackageDetails");

                    b.Navigation("TravelPackageReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
