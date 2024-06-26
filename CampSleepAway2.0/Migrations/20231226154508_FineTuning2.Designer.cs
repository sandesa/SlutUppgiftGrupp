﻿// <auto-generated />
using System;
using CampSleepAway2._0;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CampSleepAway2._0.Migrations
{
    [DbContext(typeof(CampContext))]
    [Migration("20231226154508_FineTuning2")]
    partial class FineTuning2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CampSleepAway2._0.Cabin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumberOfResidence")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cabins");
                });

            modelBuilder.Entity("CampSleepAway2._0.Camper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Campers");
                });

            modelBuilder.Entity("CampSleepAway2._0.Councelor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Councelors");
                });

            modelBuilder.Entity("CampSleepAway2._0.NextOfKin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CamperId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CamperId");

                    b.HasIndex("PersonId");

                    b.ToTable("NextOfKins");
                });

            modelBuilder.Entity("CampSleepAway2._0.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("CamperStay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CabinId")
                        .HasColumnType("int");

                    b.Property<int>("CamperId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CabinId");

                    b.HasIndex("CamperId");

                    b.ToTable("Stays");
                });

            modelBuilder.Entity("CouncelorAssignments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CabinId")
                        .HasColumnType("int");

                    b.Property<int?>("CouncelorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CabinId")
                        .IsUnique();

                    b.HasIndex("CouncelorId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("CampSleepAway2._0.Camper", b =>
                {
                    b.HasOne("CampSleepAway2._0.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CampSleepAway2._0.Councelor", b =>
                {
                    b.HasOne("CampSleepAway2._0.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CampSleepAway2._0.NextOfKin", b =>
                {
                    b.HasOne("CampSleepAway2._0.Camper", "Camper")
                        .WithMany("Kins")
                        .HasForeignKey("CamperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampSleepAway2._0.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camper");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CamperStay", b =>
                {
                    b.HasOne("CampSleepAway2._0.Cabin", "Cabin")
                        .WithMany("Stays")
                        .HasForeignKey("CabinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampSleepAway2._0.Camper", "Camper")
                        .WithMany("Stays")
                        .HasForeignKey("CamperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabin");

                    b.Navigation("Camper");
                });

            modelBuilder.Entity("CouncelorAssignments", b =>
                {
                    b.HasOne("CampSleepAway2._0.Cabin", "Cabin")
                        .WithOne("Councelor")
                        .HasForeignKey("CouncelorAssignments", "CabinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampSleepAway2._0.Councelor", "Councelor")
                        .WithMany("CabinAssignments")
                        .HasForeignKey("CouncelorId");

                    b.Navigation("Cabin");

                    b.Navigation("Councelor");
                });

            modelBuilder.Entity("CampSleepAway2._0.Cabin", b =>
                {
                    b.Navigation("Councelor")
                        .IsRequired();

                    b.Navigation("Stays");
                });

            modelBuilder.Entity("CampSleepAway2._0.Camper", b =>
                {
                    b.Navigation("Kins");

                    b.Navigation("Stays");
                });

            modelBuilder.Entity("CampSleepAway2._0.Councelor", b =>
                {
                    b.Navigation("CabinAssignments");
                });
#pragma warning restore 612, 618
        }
    }
}
