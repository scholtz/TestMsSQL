
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBTest.Model
{

    /// <summary>
    /// Database context
    /// </summary>
    public class ADBContext : DbContext
    {
        private readonly ILogger<ADBContext> logger;
        private readonly IConfiguration configuration;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        public ADBContext(DbContextOptions<ADBContext> options, ILogger<ADBContext> logger, IConfiguration configuration)
            : base(options)
        {
            this.logger = logger;
            this.configuration = configuration;

            ChangeTracker.AutoDetectChangesEnabled = false;

            logger.LogInformation("ADBContext initialized");
        }



        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                if (optionsBuilder == null) throw new Exception("optionsBuilder is null");
                configuration.GetConnectionString("TestDB");

                switch (configuration.GetValue<string>("DBType"))
                {
                    case "RAM":
                        var rand = new Random();
                        var randnum = rand.Next(1000000000, 2000000000);
                        //Constants.DBType.RAM
                        optionsBuilder.UseInMemoryDatabase($"TestDB-{randnum}");
                        break;
                    default:
                        var cs = configuration.GetConnectionString("TestDB");
                        if (string.IsNullOrEmpty(cs))
                        {
                            optionsBuilder.UseInMemoryDatabase("TestDB");
                        }
                        else
                        {
                            optionsBuilder.UseSqlServer(cs, x => x.MigrationsHistoryTable("__EFMigrationsHistory", "testobj"));
                        }
                        break;
                }
#if DEBUG
                optionsBuilder.EnableSensitiveDataLogging(true);
#endif
            }
            catch (Exception exc)
            {
                logger.LogError("Error while setting up database", exc);
                throw;
            }
        }
        /// <summary>
        /// DB Schema
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.HasDefaultSchema("testobj");

            modelBuilder.Entity<Obj>(
                e =>
                {
                    e.HasKey(c => new { c.Id });
                    e.HasIndex(c => new { c.DateTimeIndex });
                    e.HasIndex(c => new { c.DateTime2Index });
                    e.HasIndex(c => new { c.IntIndex });
                    e.HasIndex(c => new { c.LongIndex });
                    e.HasIndex(c => new { c.FloatIndex });

                    e.ToTable("Obj");
                });

        }
        public DbSet<Obj> Objs { get; set; }

        internal void EnsureCreated()
        {
            try
            {
                if (Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                {
                    Database.Migrate();
                }
            }
            catch (Exception exc)
            {
                logger.LogError(exc.Message, exc);
            }
        }
    }
}
