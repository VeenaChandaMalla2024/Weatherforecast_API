using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace WeatherForecast.WeatherEntities
{
    public partial class WeatherContext : DbContext
    {
        public WeatherContext()
        {
        }

        public WeatherContext(DbContextOptions<WeatherContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblWeatherforecast> TblWeatherforecasts { get; set; } = null!;


       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("ForeCastDatabase"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<TblWeatherforecast>(entity =>
            {
                entity.ToTable("tbl_weatherforecast");

                entity.Property(e => e.ForecastDate)
                    .HasColumnType("datetime")
                    .HasColumnName("forecast_date");

                entity.Property(e => e.ForecastSummary)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("forecast_summary");

                entity.Property(e => e.ForecastTemperature)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("forecast_temperature");
            });

           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
