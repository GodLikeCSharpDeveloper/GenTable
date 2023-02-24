﻿// <auto-generated />
using BlazorStoreServAppV5.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorStoreServAppV5.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20230223111016_123456")]
    partial class _123456
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
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

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

            modelBuilder.Entity("BlazorStoreServAppV5.Models.BLogicModel.ProductOrderModel", b =>
                {
                    b.Property<int>("ProductModelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderModelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductModelId", "OrderModelId");

                    b.HasIndex("OrderModelId");

                    b.ToTable("ProductOrder");
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

            modelBuilder.Entity("BlazorStoreServAppV5.Models.AuthModel.UserRoles", b =>
                {
                    b.HasOne("BlazorStoreServAppV5.Models.AuthModel.Roles", "Roles")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorStoreServAppV5.Models.AuthModel.Users", "Users")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("BlazorStoreServAppV5.Models.BLogicModel.ProductOrderModel", b =>
                {
                    b.HasOne("BlazorStoreServAppV5.Models.BLogicModel.OrderModel", "OrderModel")
                        .WithMany("ProductOrders")
                        .HasForeignKey("OrderModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorStoreServAppV5.Models.BLogicModel.ProductModel", "ProductModel")
                        .WithMany("ProductOrders")
                        .HasForeignKey("ProductModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderModel");

                    b.Navigation("ProductModel");
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

            modelBuilder.Entity("BlazorStoreServAppV5.Models.AuthModel.Roles", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("BlazorStoreServAppV5.Models.AuthModel.Users", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("BlazorStoreServAppV5.Models.BLogicModel.OrderModel", b =>
                {
                    b.Navigation("ProductOrders");
                });

            modelBuilder.Entity("BlazorStoreServAppV5.Models.BLogicModel.ProductModel", b =>
                {
                    b.Navigation("ProductOrders");
                });
#pragma warning restore 612, 618
        }
    }
}