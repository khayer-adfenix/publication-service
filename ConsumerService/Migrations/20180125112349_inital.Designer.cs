﻿// <auto-generated />
using ConsumerService.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ConsumerService.Migrations
{
    [DbContext(typeof(AdFenixDbConext))]
    [Migration("20180125112349_inital")]
    partial class inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("AdFenix.Entities.DomainObject.PublicationOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HostUrl");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PublicationOwners");
                });
#pragma warning restore 612, 618
        }
    }
}
