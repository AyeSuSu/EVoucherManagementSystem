﻿// <auto-generated />
using System;
using EVoucherManagementSystem.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EVoucherManagementSystem.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220326160318_DBInit")]
    partial class DBInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EVoucherManagementSystem.Models.UsersModel", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("char(37)");

                    b.Property<DateTime>("createdDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("phoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime?>("updatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id")
                        .HasName("PK_Users");

                    b.ToTable("Users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}