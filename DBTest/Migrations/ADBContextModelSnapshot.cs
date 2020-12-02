﻿// <auto-generated />
using System;
using DBTest.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBTest.Migrations
{
    [DbContext(typeof(ADBContext))]
    partial class ADBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("testobj")
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DBTest.Model.Obj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("DateTime2Index")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateTime2Value")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("DateTimeIndex")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeValue")
                        .HasColumnType("datetime2");

                    b.Property<float>("FloatIndex")
                        .HasColumnType("real");

                    b.Property<float>("FloatValue")
                        .HasColumnType("real");

                    b.Property<int>("IntIndex")
                        .HasColumnType("int");

                    b.Property<int>("IntValue")
                        .HasColumnType("int");

                    b.Property<long>("LongIndex")
                        .HasColumnType("bigint");

                    b.Property<long>("LongValue")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DateTime2Index");

                    b.HasIndex("DateTimeIndex");

                    b.HasIndex("FloatIndex");

                    b.HasIndex("IntIndex");

                    b.HasIndex("LongIndex");

                    b.ToTable("Obj");
                });
#pragma warning restore 612, 618
        }
    }
}