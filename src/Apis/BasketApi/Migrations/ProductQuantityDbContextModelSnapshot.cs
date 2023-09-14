﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsApi.Products.Repository;

#nullable disable

namespace BasketApi.Migrations
{
    [DbContext(typeof(ProductQuantityDbContext))]
    partial class ProductQuantityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BasketApi.Basket.Repositories.ProductQuantity", b =>
                {
                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("OwnerId", "ProductId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("OwnerId", "ProductId"), false);

                    b.ToTable("ProductQuantity");
                });
#pragma warning restore 612, 618
        }
    }
}