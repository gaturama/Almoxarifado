using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using Models;

namespace MyData
{
    public class Context : DbContext
    {
        public DbSet<Models.AlmoxarifadoModels> Almoxarifados {get; set;}
        public DbSet<Models.ProdutoModels> Produtos {get; set;}
        public DbSet<Models.SaldoModels> Saldos {get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;database=almoxarifado;user=root;password=gabriel081234.";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }    
}