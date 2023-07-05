﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TicketsApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230511175726_v14fixKeys")]
    partial class v14fixKeys
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EventPerformer", b =>
                {
                    b.Property<long>("EventsEventId")
                        .HasColumnType("bigint");

                    b.Property<long>("PerformersPerformerId")
                        .HasColumnType("bigint");

                    b.HasKey("EventsEventId", "PerformersPerformerId");

                    b.HasIndex("PerformersPerformerId");

                    b.ToTable("EventPerformer");
                });

            modelBuilder.Entity("PerformerTour", b =>
                {
                    b.Property<long>("PerformersPerformerId")
                        .HasColumnType("bigint");

                    b.Property<long>("ToursTourId")
                        .HasColumnType("bigint");

                    b.HasKey("PerformersPerformerId", "ToursTourId");

                    b.HasIndex("ToursTourId");

                    b.ToTable("PerformerTour");
                });

            modelBuilder.Entity("TicketsApi.Models.Event", b =>
                {
                    b.Property<long>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("EventId"));

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LiveTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("LocationId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("TicketsAvailable")
                        .HasColumnType("bigint");

                    b.Property<long>("TicketsSold")
                        .HasColumnType("bigint");

                    b.Property<long>("TicketsTotal")
                        .HasColumnType("bigint");

                    b.Property<long?>("TourId")
                        .HasColumnType("bigint");

                    b.HasKey("EventId");

                    b.HasIndex("LocationId");

                    b.HasIndex("TourId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("TicketsApi.Models.Location", b =>
                {
                    b.Property<long>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("LocationId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("TicketsApi.Models.Performer", b =>
                {
                    b.Property<long>("PerformerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("PerformerId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PerformerId");

                    b.ToTable("Performer");
                });

            modelBuilder.Entity("TicketsApi.Models.Ticket", b =>
                {
                    b.Property<long>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("TicketId"));

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Order")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("TicketId");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("TicketsApi.Models.Tour", b =>
                {
                    b.Property<long>("TourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("TourId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TourId");

                    b.ToTable("Tour");
                });

            modelBuilder.Entity("TicketsApi.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("UserId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EventPerformer", b =>
                {
                    b.HasOne("TicketsApi.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketsApi.Models.Performer", null)
                        .WithMany()
                        .HasForeignKey("PerformersPerformerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PerformerTour", b =>
                {
                    b.HasOne("TicketsApi.Models.Performer", null)
                        .WithMany()
                        .HasForeignKey("PerformersPerformerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketsApi.Models.Tour", null)
                        .WithMany()
                        .HasForeignKey("ToursTourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TicketsApi.Models.Event", b =>
                {
                    b.HasOne("TicketsApi.Models.Location", "Location")
                        .WithMany("Events")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketsApi.Models.Tour", "Tour")
                        .WithMany("Events")
                        .HasForeignKey("TourId");

                    b.Navigation("Location");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TicketsApi.Models.Ticket", b =>
                {
                    b.HasOne("TicketsApi.Models.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicketsApi.Models.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TicketsApi.Models.Event", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TicketsApi.Models.Location", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("TicketsApi.Models.Tour", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("TicketsApi.Models.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
