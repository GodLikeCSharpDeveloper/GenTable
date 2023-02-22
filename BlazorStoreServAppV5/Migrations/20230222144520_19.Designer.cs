﻿// <auto-generated />
using System;
using BlazorStoreServAppV5.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorStoreServAppV5.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20230222144520_19")]
    partial class _19
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("BlazorStoreServAppV5.Models.AuthModel.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BlazorStoreServAppV5.Models.AuthModel.UserRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RolesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RolesId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("BlazorStoreServAppV5.Models.AuthModel.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CashbackCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BlazorStoreServAppV5.Models.BLogicModel.DescriptionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Descriptions");
                });

            modelBuilder.Entity("BlazorStoreServAppV5.Models.BLogicModel.OrderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CloseOrderDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreateOrderDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FullPrice")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BlazorStoreServAppV5.Models.BLogicModel.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("InStock")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCashback")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DescriptionModelProductModel", b =>
                {
                    b.Property<int>("DescriptionModelsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DescriptionModelsId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("DescriptionModelProductModel");
                });

            modelBuilder.Entity("OrderModelProductModel", b =>
                {
                    b.Property<int>("OrderModelsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderModelsId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("OrderModelProductModel");
                });

            modelBuilder.Entity("RolesUsers", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RolesUsers");
                });

            modelBuilder.Entity("BlazorStoreServAppV5.Models.AuthModel.UserRoles", b =>
                {
                    b.HasOne("BlazorStoreServAppV5.Models.AuthModel.Roles", "Roles")
                        .WithMany("UserRoles")
                        .HasForeignKey("RolesId");

                    b.HasOne("BlazorStoreServAppV5.Models.AuthModel.Users", "Users")
                        .WithMany("UserRoles")
                        .HasForeignKey("UsersId");

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BlazorStoreServAppV5.Models.BLogicModel.OrderModel", b =>
                {
                    b.HasOne("BlazorStoreServAppV5.Models.AuthModel.Users", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DescriptionModelProductModel", b =>
                {
                    b.HasOne("BlazorStoreServAppV5.Models.BLogicModel.DescriptionModel", null)
                        .WithMany()
                        .HasForeignKey("DescriptionModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorStoreServAppV5.Models.BLogicModel.ProductModel", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderModelProductModel", b =>
                {
                    b.HasOne("BlazorStoreServAppV5.Models.BLogicModel.OrderModel", null)
                        .WithMany()
                        .HasForeignKey("OrderModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorStoreServAppV5.Models.BLogicModel.ProductModel", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RolesUsers", b =>
                {
                    b.HasOne("BlazorStoreServAppV5.Models.AuthModel.Roles", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorStoreServAppV5.Models.AuthModel.Users", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlazorStoreServAppV5.Models.AuthModel.Roles", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("BlazorStoreServAppV5.Models.AuthModel.Users", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
