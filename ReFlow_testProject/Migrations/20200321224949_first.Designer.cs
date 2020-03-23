﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReFlow_testProject.Models;

namespace ReFlow_testProject.Migrations
{
    [DbContext(typeof(ReFlow_testProjectContext))]
    [Migration("20200321224949_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReFlow_testProject.Models.Company", b =>
                {
                    b.Property<int>("companyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Phone");

                    b.HasKey("companyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("ReFlow_testProject.Models.Owner", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cID");

                    b.Property<string>("cOwner");

                    b.HasKey("id");

                    b.HasIndex("cID");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("ReFlow_testProject.Models.Owner", b =>
                {
                    b.HasOne("ReFlow_testProject.Models.Company", "Company")
                        .WithMany("Owner")
                        .HasForeignKey("cID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}