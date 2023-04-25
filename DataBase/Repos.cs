using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using Models;

namespace MyData
{
    public class Context : DbContext
    {
        public DbSet<Models.AlmoxarifadoModels> Almoxarifados {get; set;}
        public DbSet<Models.Produto> Produtos {get; set;}
        public DbSet<Models.Saldo> Saldos {get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;database=almoxarifado;user=root;password=Wheniparkmyrr_1234";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }    
}