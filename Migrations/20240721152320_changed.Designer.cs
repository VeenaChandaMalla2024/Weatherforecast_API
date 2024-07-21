﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherForecast.WeatherEntities;

#nullable disable

namespace WeatherForecast.Migrations
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20240721152320_changed")]
    partial class changed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WeatherForecast.WeatherEntities.TblWeatherforecast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ForecastDate")
                        .HasColumnType("datetime")
                        .HasColumnName("forecast_date");

                    b.Property<string>("ForecastSummary")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("forecast_summary");

                    b.Property<int?>("ForecastTemperature")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("forecast_temperature");

                    b.HasKey("Id");

                    b.ToTable("tbl_weatherforecast", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
