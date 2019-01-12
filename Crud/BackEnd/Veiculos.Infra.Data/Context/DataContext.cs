using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyHome.Infra.Data.Configurations;
using System.IO;

namespace MyHome.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration(new EmpreendimentoConfig());
            modelBuilder.ApplyConfiguration(new PlantaConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json")
                             .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnectionHmg"));
        }

        public DbSet<Empreendimento> Empreendimentos { get; set; }
        public DbSet<RecursoGrafico> RecursosGraficos { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        


    }
}
