﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TierListApp.Data;

#nullable disable

namespace TierListApp.Migrations
{
    [DbContext(typeof(TierDbContext))]
    partial class TierDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("TierListApp.Models.Tier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TierColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TierListId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TierListId");

                    b.ToTable("Tiers");
                });

            modelBuilder.Entity("TierListApp.Models.TierItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TierId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TierId");

                    b.ToTable("TierItems");
                });

            modelBuilder.Entity("TierListApp.Models.TierList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TierLists");
                });

            modelBuilder.Entity("TierListApp.Models.Tier", b =>
                {
                    b.HasOne("TierListApp.Models.TierList", "TierList")
                        .WithMany("Tiers")
                        .HasForeignKey("TierListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TierList");
                });

            modelBuilder.Entity("TierListApp.Models.TierItem", b =>
                {
                    b.HasOne("TierListApp.Models.Tier", "Tier")
                        .WithMany("TierItems")
                        .HasForeignKey("TierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tier");
                });

            modelBuilder.Entity("TierListApp.Models.Tier", b =>
                {
                    b.Navigation("TierItems");
                });

            modelBuilder.Entity("TierListApp.Models.TierList", b =>
                {
                    b.Navigation("Tiers");
                });
#pragma warning restore 612, 618
        }
    }
}
