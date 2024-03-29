﻿// <auto-generated />
using System;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230619010231_DrHabit")]
    partial class DrHabit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AlterationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("AlterationUser")
                        .HasColumnType("int");

                    b.Property<ulong>("DailyActivity")
                        .HasColumnType("bit")
                        .HasColumnName("DailyActivity");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("Datetime")
                        .HasColumnName("Deadline");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Description");

                    b.Property<DateTime>("InclusionDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Score")
                        .HasColumnType("int")
                        .HasColumnName("Score");

                    b.Property<ulong>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("Status");

                    b.Property<string>("Type")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Type");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Activity", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ActivityHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AlterationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("AlterationUser")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("Count");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Datetime")
                        .HasColumnName("Date");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InclusionDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("GroupId");

                    b.ToTable("ActivityHistory", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AlterationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("AlterationUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Description");

                    b.Property<DateTime>("InclusionDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Group", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.GroupProfile", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AlterationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("AlterationUser")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("InclusionDate")
                        .HasColumnType("datetime");

                    b.Property<int>("ScoreGroup")
                        .HasColumnType("int")
                        .HasColumnName("ScoreGroup");

                    b.HasKey("GroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupProfile", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AlterationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("AlterationUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Description");

                    b.Property<DateTime>("InclusionDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Note", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AlterationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("AlterationUser")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<DateTime>("InclusionDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Score")
                        .HasColumnType("int")
                        .HasColumnName("Score");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Activity", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.ActivityHistory", b =>
                {
                    b.HasOne("Domain.Entities.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Domain.Entities.GroupProfile", b =>
                {
                    b.HasOne("Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Domain.Entities.Note", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
