using Aula09.Dominio;
using Microsoft.EntityFrameworkCore;
using WebCommerce.Dados.Configuracoes;

namespace WebCommerce.Dados
{
    public class Contexto : DbContext {

        //1. CLASSES - ENTIDADES - TABELAS
        //1. INICIO
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Marca> Marca { get; set; }
        //public DbSet<Departamento> Departamento { get; set; }
        //1. FIM

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=10.107.176.41;database=dbEcommerce;user id=visualstudio;password=visualstudio;");
        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //2. DEFINIÇÃO DAS CONFIGURAÇÕES DAS CLASSES
            //2. INICIO
            modelBuilder.ApplyConfiguration(new ProdutoConfiguracao());
            modelBuilder.ApplyConfiguration(new GrupoConfiguracao());
            modelBuilder.ApplyConfiguration(new MarcaConfiguracao());
            //modelBuilder.ApplyConfiguration(new DepartamentoConfiguracao());
            //2. FIM
        }

    }
}
