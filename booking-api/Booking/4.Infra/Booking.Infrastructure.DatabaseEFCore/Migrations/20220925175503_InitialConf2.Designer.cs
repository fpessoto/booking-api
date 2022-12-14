// <auto-generated />
using System;
using Booking.Infrastructure.DatabaseEFCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Booking.Infrastructure.DatabaseEFCore.Migrations
{
    [DbContext(typeof(BookingDBContext))]
    [Migration("20220925175503_InitialConf2")]
    partial class InitialConf2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Booking.Domain.Reservations.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("TB_RESERVATION", (string)null);
                });

            modelBuilder.Entity("Booking.Domain.Rooms.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("TB_ROOM", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c83a4a7c-ccfd-4625-ae23-98cf9f62ba2a"),
                            CreatedDate = new DateTime(2022, 3, 30, 16, 14, 37, 755, DateTimeKind.Unspecified).AddTicks(4636),
                            Description = "The best room in the world! Beautiful view!",
                            UpdatedDate = new DateTime(2022, 3, 30, 16, 14, 37, 758, DateTimeKind.Unspecified).AddTicks(1509)
                        });
                });

            modelBuilder.Entity("Booking.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TB_USER", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("4db89c05-1b67-4771-96a2-4b607d287123"),
                            CreatedDate = new DateTime(2022, 3, 30, 16, 14, 37, 755, DateTimeKind.Unspecified).AddTicks(4636),
                            Email = "admin@admin.com",
                            Password = "admin",
                            Role = "admin",
                            UpdatedDate = new DateTime(2022, 3, 30, 16, 14, 37, 758, DateTimeKind.Unspecified).AddTicks(1509),
                            Username = "admin"
                        },
                        new
                        {
                            Id = new Guid("d6df6771-ef40-4713-81d5-a0429cd34ab9"),
                            CreatedDate = new DateTime(2022, 3, 30, 16, 14, 37, 755, DateTimeKind.Unspecified).AddTicks(4636),
                            Email = "guest@gmail.com",
                            Password = "guest",
                            Role = "guest",
                            UpdatedDate = new DateTime(2022, 3, 30, 16, 14, 37, 758, DateTimeKind.Unspecified).AddTicks(1509),
                            Username = "guest"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
