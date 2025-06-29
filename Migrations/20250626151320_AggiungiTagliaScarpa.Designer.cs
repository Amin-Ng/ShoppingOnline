﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingOnline.Data;

#nullable disable

namespace ShoppingOnline.Migrations
{
    [DbContext(typeof(ShoppingOnlineContext))]
    [Migration("20250626151320_AggiungiTagliaScarpa")]
    partial class AggiungiTagliaScarpa
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShoppingOnline.Models.CatalogoScarpe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descrizione")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImmagineUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("CatalogoScarpe");
                });

            modelBuilder.Entity("ShoppingOnline.Models.TagliaScarpa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CatalogoScarpaId")
                        .HasColumnType("int");

                    b.Property<int>("Quantita")
                        .HasColumnType("int");

                    b.Property<int>("Taglia")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CatalogoScarpaId");

                    b.ToTable("TagliaScarpa");
                });

            modelBuilder.Entity("ShoppingOnline.Models.TagliaScarpa", b =>
                {
                    b.HasOne("ShoppingOnline.Models.CatalogoScarpe", "CatalogoScarpa")
                        .WithMany("tagliaScarpa")
                        .HasForeignKey("CatalogoScarpaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogoScarpa");
                });

            modelBuilder.Entity("ShoppingOnline.Models.CatalogoScarpe", b =>
                {
                    b.Navigation("tagliaScarpa");
                });
#pragma warning restore 612, 618
        }
    }
}
