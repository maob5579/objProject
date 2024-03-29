﻿// <auto-generated />
using CoreWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreWebApi.Migrations
{
    [DbContext(typeof(MoodFullContext))]
    [Migration("20191207141313_CoreWebApi.Models.RestaurantInfoUpdate")]
    partial class CoreWebApiModelsRestaurantInfoUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreWebApi.Models.Evaluation", b =>
                {
                    b.Property<long>("EvaluationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Experience")
                        .HasColumnType("decimal(4,2)");

                    b.Property<decimal>("MoodRating")
                        .HasColumnType("decimal(4,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(4,2)");

                    b.Property<long>("RestaurantId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("EvaluationId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId");

                    b.ToTable("Evaluation");

                    b.HasData(
                        new
                        {
                            EvaluationId = 1L,
                            Experience = 3.3m,
                            MoodRating = 4.2m,
                            Price = 1.5m,
                            RestaurantId = 1L,
                            UserId = 1L
                        },
                        new
                        {
                            EvaluationId = 2L,
                            Experience = 4.23m,
                            MoodRating = 1.55m,
                            Price = 6.23m,
                            RestaurantId = 2L,
                            UserId = 2L
                        });
                });

            modelBuilder.Entity("CoreWebApi.Models.Restaurant", b =>
                {
                    b.Property<long>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("SpecifyStreet")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurant");

                    b.HasData(
                        new
                        {
                            RestaurantId = 1L,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Can can"
                        },
                        new
                        {
                            RestaurantId = 2L,
                            Latitude = 0.0,
                            Longitude = 0.0,
                            Name = "Katpedele"
                        });
                });

            modelBuilder.Entity("CoreWebApi.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1L,
                            FirstName = "admin",
                            LastName = "admin",
                            Password = "admin",
                            UserType = 1,
                            Username = "admin"
                        },
                        new
                        {
                            UserId = 2L,
                            FirstName = "labas",
                            LastName = "lab",
                            Password = "labaslabas",
                            UserType = 2,
                            Username = "labas"
                        });
                });

            modelBuilder.Entity("CoreWebApi.Models.Evaluation", b =>
                {
                    b.HasOne("CoreWebApi.Models.Restaurant", "Restaurant")
                        .WithMany("Evaluations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreWebApi.Models.User", "User")
                        .WithMany("Evaluations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
