﻿// <auto-generated />
using System;
using GCGuildManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GCGuildManager.Migrations
{
    [DbContext(typeof(GuildManagerContext))]
    [Migration("20191107204843_Teste2")]
    partial class Teste2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GCGuildManager.Models.Cargo", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("GCGuildManager.Models.Classe", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("nome")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("GCGuildManager.Models.Equipe", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("mascote1id")
                        .HasColumnType("bigint");

                    b.Property<long?>("mascote2id")
                        .HasColumnType("bigint");

                    b.Property<long?>("personagem1id")
                        .HasColumnType("bigint");

                    b.Property<long?>("personagem2id")
                        .HasColumnType("bigint");

                    b.Property<long?>("personagem3id")
                        .HasColumnType("bigint");

                    b.Property<long?>("personagem4id")
                        .HasColumnType("bigint");

                    b.Property<long?>("personagem5id")
                        .HasColumnType("bigint");

                    b.Property<long?>("personagem6id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("mascote1id");

                    b.HasIndex("mascote2id");

                    b.HasIndex("personagem1id");

                    b.HasIndex("personagem2id");

                    b.HasIndex("personagem3id");

                    b.HasIndex("personagem4id");

                    b.HasIndex("personagem5id");

                    b.HasIndex("personagem6id");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("GCGuildManager.Models.Mascote", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("nome")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Mascotes");
                });

            modelBuilder.Entity("GCGuildManager.Models.Membro", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("cargoid")
                        .HasColumnType("bigint");

                    b.Property<string>("nome")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("cargoid");

                    b.ToTable("Membros");
                });

            modelBuilder.Entity("GCGuildManager.Models.Personagem", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("classeid")
                        .HasColumnType("bigint");

                    b.Property<string>("nome")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("classeid");

                    b.ToTable("Personagens");
                });

            modelBuilder.Entity("GCGuildManager.Models.RegistroBatalha", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("defesa")
                        .HasColumnType("int");

                    b.Property<long?>("equipeAtaqueid")
                        .HasColumnType("bigint");

                    b.Property<long?>("equipeDefesaid")
                        .HasColumnType("bigint");

                    b.Property<long?>("membroid")
                        .HasColumnType("bigint");

                    b.Property<int>("primeiroAtaque")
                        .HasColumnType("int");

                    b.Property<int>("segundoAtaque")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("equipeAtaqueid");

                    b.HasIndex("equipeDefesaid");

                    b.HasIndex("membroid");

                    b.ToTable("registro_batalha");
                });

            modelBuilder.Entity("GCGuildManager.Models.RegistroChefe", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("dano")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("membroid")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("membroid");

                    b.ToTable("registro_chefe");
                });

            modelBuilder.Entity("GCGuildManager.Models.RegistroPoder", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("membroid")
                        .HasColumnType("bigint");

                    b.Property<long>("poder")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("membroid");

                    b.ToTable("registro_poder");
                });

            modelBuilder.Entity("GCGuildManager.Models.Equipe", b =>
                {
                    b.HasOne("GCGuildManager.Models.Mascote", "mascote1")
                        .WithMany()
                        .HasForeignKey("mascote1id");

                    b.HasOne("GCGuildManager.Models.Mascote", "mascote2")
                        .WithMany()
                        .HasForeignKey("mascote2id");

                    b.HasOne("GCGuildManager.Models.Personagem", "personagem1")
                        .WithMany()
                        .HasForeignKey("personagem1id");

                    b.HasOne("GCGuildManager.Models.Personagem", "personagem2")
                        .WithMany()
                        .HasForeignKey("personagem2id");

                    b.HasOne("GCGuildManager.Models.Personagem", "personagem3")
                        .WithMany()
                        .HasForeignKey("personagem3id");

                    b.HasOne("GCGuildManager.Models.Personagem", "personagem4")
                        .WithMany()
                        .HasForeignKey("personagem4id");

                    b.HasOne("GCGuildManager.Models.Personagem", "personagem5")
                        .WithMany()
                        .HasForeignKey("personagem5id");

                    b.HasOne("GCGuildManager.Models.Personagem", "personagem6")
                        .WithMany()
                        .HasForeignKey("personagem6id");
                });

            modelBuilder.Entity("GCGuildManager.Models.Membro", b =>
                {
                    b.HasOne("GCGuildManager.Models.Cargo", "cargo")
                        .WithMany()
                        .HasForeignKey("cargoid");
                });

            modelBuilder.Entity("GCGuildManager.Models.Personagem", b =>
                {
                    b.HasOne("GCGuildManager.Models.Classe", "classe")
                        .WithMany()
                        .HasForeignKey("classeid");
                });

            modelBuilder.Entity("GCGuildManager.Models.RegistroBatalha", b =>
                {
                    b.HasOne("GCGuildManager.Models.Equipe", "equipeAtaque")
                        .WithMany()
                        .HasForeignKey("equipeAtaqueid");

                    b.HasOne("GCGuildManager.Models.Equipe", "equipeDefesa")
                        .WithMany()
                        .HasForeignKey("equipeDefesaid");

                    b.HasOne("GCGuildManager.Models.Membro", "membro")
                        .WithMany()
                        .HasForeignKey("membroid");
                });

            modelBuilder.Entity("GCGuildManager.Models.RegistroChefe", b =>
                {
                    b.HasOne("GCGuildManager.Models.Membro", "membro")
                        .WithMany()
                        .HasForeignKey("membroid");
                });

            modelBuilder.Entity("GCGuildManager.Models.RegistroPoder", b =>
                {
                    b.HasOne("GCGuildManager.Models.Membro", "membro")
                        .WithMany()
                        .HasForeignKey("membroid");
                });
#pragma warning restore 612, 618
        }
    }
}
