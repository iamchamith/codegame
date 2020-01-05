﻿// <auto-generated />
using System;
using BlocklyPro.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlocklyPro.Core.Migrations
{
    [DbContext(typeof(BlocklyDbContext))]
    [Migration("20200105065241_Application_AddGameTime")]
    partial class Application_AddGameTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlocklyPro.Core.Domain.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Time");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Game","Application");
                });

            modelBuilder.Entity("BlocklyPro.Core.Domain.GameMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ControllerType");

                    b.Property<int>("GameId");

                    b.Property<int>("Height");

                    b.Property<int>("PointX");

                    b.Property<int>("PointY");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("GameMap","Application");
                });

            modelBuilder.Entity("BlocklyPro.Core.Domain.Play.GameCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodeType");

                    b.Property<int>("Order");

                    b.Property<string>("Payload");

                    b.Property<int>("PlayGameId");

                    b.HasKey("Id");

                    b.HasIndex("PlayGameId");

                    b.ToTable("GameCode","Application");
                });

            modelBuilder.Entity("BlocklyPro.Core.Domain.Play.PlayGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("GameId");

                    b.Property<bool>("IsCorrectSolution");

                    b.Property<int>("PlayerId");

                    b.Property<int>("Score");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayGame","Application");
                });

            modelBuilder.Entity("BlocklyPro.Core.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("User","Identity");
                });

            modelBuilder.Entity("BlocklyPro.Core.Domain.Game", b =>
                {
                    b.HasOne("BlocklyPro.Core.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlocklyPro.Core.Domain.GameMap", b =>
                {
                    b.HasOne("BlocklyPro.Core.Domain.Game", "Game")
                        .WithMany("GameMap")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlocklyPro.Core.Domain.Play.GameCode", b =>
                {
                    b.HasOne("BlocklyPro.Core.Domain.Play.PlayGame", "PlayGame")
                        .WithMany("GameCode")
                        .HasForeignKey("PlayGameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlocklyPro.Core.Domain.Play.PlayGame", b =>
                {
                    b.HasOne("BlocklyPro.Core.Domain.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlocklyPro.Core.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
