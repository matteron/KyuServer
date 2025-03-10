﻿// <auto-generated />
using System;
using KyuApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KyuApi.Migrations
{
    [DbContext(typeof(KyuContext))]
    partial class KyuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("KyuApi.Data.Entities.Entry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Body")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("EntryStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EntryTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EntryStatusId");

                    b.HasIndex("EntryTypeId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("KyuApi.Data.Entities.HashHolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hash")
                        .HasColumnType("TEXT");

                    b.Property<string>("Salt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("HashHolders");
                });

            modelBuilder.Entity("KyuApi.Data.Entities.Navigation.EntryTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("EntryId")
                        .HasColumnType("TEXT");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.HasIndex("TagId");

                    b.ToTable("EntryTags");
                });

            modelBuilder.Entity("KyuApi.Data.Entities.TypeTables.EntryStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EntryStatuses");
                });

            modelBuilder.Entity("KyuApi.Data.Entities.TypeTables.EntryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EntryTypes");
                });

            modelBuilder.Entity("KyuApi.Data.Entities.TypeTables.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("KyuApi.Data.Entities.Entry", b =>
                {
                    b.HasOne("KyuApi.Data.Entities.TypeTables.EntryStatus", "EntryStatus")
                        .WithMany()
                        .HasForeignKey("EntryStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KyuApi.Data.Entities.TypeTables.EntryType", "EntryType")
                        .WithMany()
                        .HasForeignKey("EntryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KyuApi.Data.Entities.Navigation.EntryTag", b =>
                {
                    b.HasOne("KyuApi.Data.Entities.Entry", "Entry")
                        .WithMany("EntryTags")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KyuApi.Data.Entities.TypeTables.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
