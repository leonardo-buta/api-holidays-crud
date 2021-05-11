﻿// <auto-generated />
using System;
using Holidays.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Holidays.Data.Migrations
{
    [DbContext(typeof(HolidaysContext))]
    partial class HolidaysContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Holidays.Domain.Models.Holiday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("char(5)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("EndTime")
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Legislation")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("StartTime")
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Holidays");
                });

            modelBuilder.Entity("Holidays.Domain.Models.HolidayVariableDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("char(5)");

                    b.Property<int?>("HolidayId")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("char(4)");

                    b.HasKey("Id");

                    b.HasIndex("HolidayId");

                    b.ToTable("HolidayVariableDates");
                });

            modelBuilder.Entity("Holidays.Domain.Models.HolidayVariableDate", b =>
                {
                    b.HasOne("Holidays.Domain.Models.Holiday", "Holiday")
                        .WithMany("HolidayVariableDates")
                        .HasForeignKey("HolidayId");

                    b.Navigation("Holiday");
                });

            modelBuilder.Entity("Holidays.Domain.Models.Holiday", b =>
                {
                    b.Navigation("HolidayVariableDates");
                });
#pragma warning restore 612, 618
        }
    }
}
