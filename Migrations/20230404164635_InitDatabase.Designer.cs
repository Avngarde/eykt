﻿// <auto-generated />
using System;
using Eykt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace eykt.Migrations
{
    [DbContext(typeof(EyktContext))]
    [Migration("20230404164635_InitDatabase")]
    partial class InitDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("Eykt.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TypeEventTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventId");

                    b.HasIndex("TypeEventTypeId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Eykt.EventType", b =>
                {
                    b.Property<int>("EventTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("EventTypeId");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("Eykt.Event", b =>
                {
                    b.HasOne("Eykt.EventType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeEventTypeId");

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}