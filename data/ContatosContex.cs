using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.IO;

namespace AgendaContatos.Data
{
    public class ContatosContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            options.UseMySql(config.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 21)));
        }
    }
}
