﻿// <auto-generated />
using System;
using EvenlyAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EvenlyAPI.Migrations
{
    [DbContext(typeof(EvenlyDbContext))]
    partial class EvenlyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EvenlyAPI.Models.ExpenseModel", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("expense_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExpenseId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("amount");

                    b.Property<DateTime>("DateOfExpense")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_of_expense");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<int>("GroupId")
                        .HasColumnType("int")
                        .HasColumnName("group_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("ExpenseId");

                    b.HasIndex("UserId", "GroupId");

                    b.ToTable("Expenses");

                    b.HasData(
                        new
                        {
                            ExpenseId = 1,
                            Amount = 200m,
                            DateOfExpense = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Seeded expense",
                            GroupId = 1,
                            UserId = 1
                        },
                        new
                        {
                            ExpenseId = 2,
                            Amount = 500m,
                            DateOfExpense = new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Another seeded expense",
                            GroupId = 2,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("EvenlyAPI.Models.GroupModel", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("group_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("group_name");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            GroupName = "Simrishamnsgatan"
                        },
                        new
                        {
                            GroupId = 2,
                            GroupName = "Familjen"
                        });
                });

            modelBuilder.Entity("EvenlyAPI.Models.UserGroupModel", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<int>("GroupId")
                        .HasColumnType("int")
                        .HasColumnName("group_id");

                    b.Property<decimal>("Balance")
                        .HasColumnType("DECIMAL(10,2)")
                        .HasColumnName("balance");

                    b.HasKey("UserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("UserGroups");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            GroupId = 1,
                            Balance = 0m
                        },
                        new
                        {
                            UserId = 2,
                            GroupId = 1,
                            Balance = 0m
                        },
                        new
                        {
                            UserId = 1,
                            GroupId = 2,
                            Balance = 0m
                        },
                        new
                        {
                            UserId = 3,
                            GroupId = 2,
                            Balance = 0m
                        },
                        new
                        {
                            UserId = 4,
                            GroupId = 2,
                            Balance = 0m
                        });
                });

            modelBuilder.Entity("EvenlyAPI.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Name = "Otto"
                        },
                        new
                        {
                            UserId = 2,
                            Name = "Hilda"
                        },
                        new
                        {
                            UserId = 3,
                            Name = "Eva"
                        },
                        new
                        {
                            UserId = 4,
                            Name = "Sören"
                        });
                });

            modelBuilder.Entity("EvenlyAPI.Models.ExpenseModel", b =>
                {
                    b.HasOne("EvenlyAPI.Models.UserGroupModel", "UserGroup")
                        .WithMany("Expenses")
                        .HasForeignKey("UserId", "GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserGroup");
                });

            modelBuilder.Entity("EvenlyAPI.Models.UserGroupModel", b =>
                {
                    b.HasOne("EvenlyAPI.Models.GroupModel", "Group")
                        .WithMany("UserGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EvenlyAPI.Models.UserModel", "User")
                        .WithMany("UserGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EvenlyAPI.Models.GroupModel", b =>
                {
                    b.Navigation("UserGroups");
                });

            modelBuilder.Entity("EvenlyAPI.Models.UserGroupModel", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("EvenlyAPI.Models.UserModel", b =>
                {
                    b.Navigation("UserGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
