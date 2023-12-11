﻿// <auto-generated />
using System;
using Markway.Shipments.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Shipments.API.Migrations
{
    [DbContext(typeof(ShipmentsContext))]
    [Migration("20231129174452_AddedBorderCrossingToRoute")]
    partial class AddedBorderCrossingToRoute
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Markway.Shipments.API.Models.BorderCrossing", b =>
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

            modelBuilder.Entity("Markway.Shipments.API.Models.Carrier", b =>
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

            modelBuilder.Entity("Markway.Shipments.API.Models.Customer", b =>
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

            modelBuilder.Entity("Markway.Shipments.API.Models.Customs", b =>
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

            modelBuilder.Entity("Markway.Shipments.API.Models.LoadOnLocation", b =>
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

            modelBuilder.Entity("Markway.Shipments.API.Models.Note", b =>
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

            modelBuilder.Entity("Markway.Shipments.API.Models.Shipment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("CustomerId")
                        .IsRequired()
                        .HasColumnType("bigint");

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

                    b.Property<string>("Merch")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("MerchAmount")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("NoteId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("Profit")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("NoteId");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("Markway.Shipments.API.Models.ShipmentCustoms", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("CustomId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<long?>("RouteId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<int>("type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomId");

                    b.HasIndex("RouteId");

                    b.ToTable("ShipmentCustoms");
                });

            modelBuilder.Entity("Markway.Shipments.API.Models.ShipmentLoadOnLocation", b =>
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

                    b.Property<long?>("RouteId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LoadOnLocationId");

                    b.HasIndex("RouteId");

                    b.ToTable("ShipmentLoadOnLocations");
                });

            modelBuilder.Entity("Markway.Shipments.API.Models.ShipmentsRoute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("BorderCrossingId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CarrierId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LicencePlate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Outcome")
                        .HasColumnType("bigint");

                    b.Property<long?>("ShipmentId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BorderCrossingId");

                    b.HasIndex("CarrierId");

                    b.HasIndex("ShipmentId");

                    b.ToTable("ShipmentsRoutes");
                });

            modelBuilder.Entity("Markway.Shipments.API.Models.Shipment", b =>
                {
                    b.HasOne("Markway.Shipments.API.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Markway.Shipments.API.Models.Note", "Note")
                        .WithMany()
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Note");
                });

            modelBuilder.Entity("Markway.Shipments.API.Models.ShipmentCustoms", b =>
                {
                    b.HasOne("Markway.Shipments.API.Models.Customs", "Custom")
                        .WithMany()
                        .HasForeignKey("CustomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Markway.Shipments.API.Models.ShipmentsRoute", "Route")
                        .WithMany("ShipmentCustoms")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Custom");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Markway.Shipments.API.Models.ShipmentLoadOnLocation", b =>
                {
                    b.HasOne("Markway.Shipments.API.Models.LoadOnLocation", "LoadOnLocation")
                        .WithMany()
                        .HasForeignKey("LoadOnLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Markway.Shipments.API.Models.ShipmentsRoute", "Route")
                        .WithMany("ShipmentLoadOnLocations")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoadOnLocation");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Markway.Shipments.API.Models.ShipmentsRoute", b =>
                {
                    b.HasOne("Markway.Shipments.API.Models.BorderCrossing", "BorderCrossing")
                        .WithMany()
                        .HasForeignKey("BorderCrossingId");

                    b.HasOne("Markway.Shipments.API.Models.Carrier", "Carrier")
                        .WithMany()
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Markway.Shipments.API.Models.Shipment", "Shipment")
                        .WithMany("ShipmentRoutes")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BorderCrossing");

                    b.Navigation("Carrier");

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("Markway.Shipments.API.Models.Shipment", b =>
                {
                    b.Navigation("ShipmentRoutes");
                });

            modelBuilder.Entity("Markway.Shipments.API.Models.ShipmentsRoute", b =>
                {
                    b.Navigation("ShipmentCustoms");

                    b.Navigation("ShipmentLoadOnLocations");
                });
#pragma warning restore 612, 618
        }
    }
}
