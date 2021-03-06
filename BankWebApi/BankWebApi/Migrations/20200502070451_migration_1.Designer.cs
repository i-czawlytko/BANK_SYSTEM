﻿// <auto-generated />
using System;
using BankWebApi.ContextFolder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BankWebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200502070451_migration_1")]
    partial class migration_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankWebApi.Entitys.CompanyClients", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("company_name");

                    b.Property<DateTime>("create_date");

                    b.Property<int>("parent_id");

                    b.HasKey("id");

                    b.ToTable("CompanyClients");
                });

            modelBuilder.Entity("BankWebApi.Entitys.Credits", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("amount");

                    b.Property<DateTime>("create_date");

                    b.Property<int>("owner_id");

                    b.Property<string>("owner_type");

                    b.Property<int>("percent");

                    b.HasKey("id");

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("BankWebApi.Entitys.Deposit", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("amount");

                    b.Property<bool>("cap");

                    b.Property<DateTime>("create_date");

                    b.Property<int>("owner_id");

                    b.Property<string>("owner_type");

                    b.Property<int>("percent");

                    b.HasKey("id");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("BankWebApi.Entitys.Giros", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("amount");

                    b.Property<DateTime>("create_date");

                    b.Property<int>("owner_id");

                    b.Property<string>("owner_type");

                    b.HasKey("id");

                    b.ToTable("Giros");
                });

            modelBuilder.Entity("BankWebApi.Entitys.PhysClients", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("birth_date");

                    b.Property<string>("client_name");

                    b.HasKey("id");

                    b.ToTable("PhysClients");
                });
#pragma warning restore 612, 618
        }
    }
}
