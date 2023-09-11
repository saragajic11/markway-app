﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Napokon.Shipments.API.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Shipments.API.Migrations
{
    [DbContext(typeof(ShipmentsContext))]
    [Migration("20230908075926_AddedShipmentsAndShipmentsLoadOnLocationTable")]
    partial class AddedShipmentsAndShipmentsLoadOnLocationTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Napokon.Shipments.API.Models.BorderCrossing", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BorderCrossings");
                });

            modelBuilder.Entity("Napokon.Shipments.API.Models.Carrier", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Carriers");
                });

            modelBuilder.Entity("Napokon.Shipments.API.Models.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Napokon.Shipments.API.Models.Customs", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customs");
                });

            modelBuilder.Entity("Napokon.Shipments.API.Models.LoadOnLocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LoadOnLocations");
                });

            modelBuilder.Entity("Napokon.Shipments.API.Models.Note", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Napokon.Shipments.API.Models.Shipment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("Income")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("LicencePlate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Merch")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("MerchAmount")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("Outcome")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("Profit")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("Napokon.Shipments.API.Models.ShipmentLoadOnLocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<long?>("LoadOnLocationId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("ShipmentId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LoadOnLocationId");

                    b.HasIndex("ShipmentId");

                    b.ToTable("ShipmentLoadOnLocations");
                });

            modelBuilder.Entity("Napokon.Shipments.API.Models.ShipmentLoadOnLocation", b =>
                {
                    b.HasOne("Napokon.Shipments.API.Models.LoadOnLocation", "LoadOnLocation")
                        .WithMany()
                        .HasForeignKey("LoadOnLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Napokon.Shipments.API.Models.Shipment", "Shipment")
                        .WithMany()
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoadOnLocation");

                    b.Navigation("Shipment");
                });
#pragma warning restore 612, 618
        }
    }
}
