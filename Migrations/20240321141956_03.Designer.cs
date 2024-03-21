﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sharpcoder2_TechLife_Coinnecta_Backend.Domain;

#nullable disable

namespace sharpcoder2_TechLife_Coinnecta_Backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240321141956_03")]
    partial class _03
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("sharpcoder2_TechLife_Coinnecta_Backend.Domain.Model.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroConta")
                        .HasColumnType("TEXT");

                    b.Property<double>("Saldo")
                        .HasColumnType("REAL");

                    b.Property<int>("StatusConta")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoConta")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Conta");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Conta");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("sharpcoder2_TechLife_Coinnecta_Backend.Domain.Model.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cep")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade")
                        .HasColumnType("TEXT");

                    b.Property<string>("Complemento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Logradouro")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PontoRef")
                        .HasColumnType("TEXT");

                    b.Property<string>("Uf")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("sharpcoder2_TechLife_Coinnecta_Backend.Domain.Model.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContaDestinoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContaOrigemId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataHoraTrasacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("DescricaoTrasacao")
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoTransacao")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ContaDestinoId");

                    b.HasIndex("ContaOrigemId");

                    b.ToTable("Transacaos");
                });

            modelBuilder.Entity("sharpcoder2_TechLife_Coinnecta_Backend.Domain.Model.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cnpj")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ddd")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("DiaNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoPessoa")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("sharpcoder2_TechLife_Coinnecta_Backend.Domain.Model.ContaCorrente", b =>
                {
                    b.HasBaseType("sharpcoder2_TechLife_Coinnecta_Backend.Domain.Model.Conta");

                    b.Property<int>("TempoDeAberturaConta")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("UsuarioId");

                    b.HasDiscriminator().HasValue("ContaCorrente");
                });

            modelBuilder.Entity("sharpcoder2_TechLife_Coinnecta_Backend.Domain.Model.ContaPoupanca", b =>
                {
                    b.HasBaseType("sharpcoder2_TechLife_Coinnecta_Backend.Domain.Model.Conta");

                    b.Property<double>("LimiteCredito")
                        .HasColumnType("REAL");

                    b.HasDiscriminator().HasValue("ContaPoupanca");
                });

            modelBuilder.Entity("sharpcoder2_TechLife_Coinnecta_Backend.Domain.Model.Transacao", b =>
                {
                    b.HasOne("sharpcoder2_TechLife_Coinnecta_Backend.Domain.Model.Conta", "ContaDestino")
                        .WithMany()
                        .HasForeignKey("ContaDestinoId");

                    b.HasOne("sharpcoder2_TechLife_Coinnecta_Backend.Domain.Model.Conta", "ContaOrigem")
                        .WithMany()
                        .HasForeignKey("ContaOrigemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContaDestino");

                    b.Navigation("ContaOrigem");
                });

            modelBuilder.Entity("sharpcoder2_TechLife_Coinnecta_Backend.Domain.Model.Usuario", b =>
                {
                    b.HasOne("sharpcoder2_TechLife_Coinnecta_Backend.Domain.Model.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("sharpcoder2_TechLife_Coinnecta_Backend.Domain.Model.ContaCorrente", b =>
                {
                    b.HasOne("sharpcoder2_TechLife_Coinnecta_Backend.Domain.Model.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
