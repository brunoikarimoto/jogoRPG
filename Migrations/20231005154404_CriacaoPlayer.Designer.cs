﻿// <auto-generated />
using System;
using API_JogoRPG.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace jogoRPG.Migrations
{
    [DbContext(typeof(JogoRPGDbContext))]
    [Migration("20231005154404_CriacaoPlayer")]
    partial class CriacaoPlayer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("API_JogoRPG.Models.Player", b =>
                {
                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Classe")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Forca")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Inteligencia")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Nivel")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Resistencia")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Velocidade")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Vida")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("qntBoss")
                        .HasColumnType("INTEGER");

                    b.HasKey("Nome");

                    b.ToTable("Player");
                });
#pragma warning restore 612, 618
        }
    }
}
