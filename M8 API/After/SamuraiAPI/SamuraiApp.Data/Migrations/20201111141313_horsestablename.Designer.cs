﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SamuraiApp.Data;

namespace SamuraiApp.Data.Migrations
{
    [DbContext(typeof(SamuraiContext))]
    [Migration("20201111141313_horsestablename")]
    partial class horsestablename
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SamuraiApp.Domain.Battle", b =>
                {
                    b.Property<int>("BattleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BattleId");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("SamuraiApp.Domain.BattleSamurai", b =>
                {
                    b.Property<int>("BattleId")
                        .HasColumnType("int");

                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateJoined")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("BattleId", "SamuraiId");

                    b.HasIndex("SamuraiId");

                    b.ToTable("BattleSamurai");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Horse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId")
                        .IsUnique();

                    b.ToTable("Horses");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("SamuraiId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Samurai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("SamuraiApp.Domain.BattleSamurai", b =>
                {
                    b.HasOne("SamuraiApp.Domain.Battle", null)
                        .WithMany()
                        .HasForeignKey("BattleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SamuraiApp.Domain.Samurai", null)
                        .WithMany()
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SamuraiApp.Domain.Horse", b =>
                {
                    b.HasOne("SamuraiApp.Domain.Samurai", null)
                        .WithOne("Horse")
                        .HasForeignKey("SamuraiApp.Domain.Horse", "SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SamuraiApp.Domain.Quote", b =>
                {
                    b.HasOne("SamuraiApp.Domain.Samurai", "Samurai")
                        .WithMany("Quotes")
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Samurai");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Samurai", b =>
                {
                    b.Navigation("Horse");

                    b.Navigation("Quotes");
                });
#pragma warning restore 612, 618
        }
    }
}
