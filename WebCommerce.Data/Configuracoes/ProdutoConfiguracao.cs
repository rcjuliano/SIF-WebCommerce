using Aula09.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebCommerce.Dados.Configuracoes
{
    public class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
    {

        public void Configure(EntityTypeBuilder<Produto> builder)
        {

            builder.ToTable("Produto", "dbo");
            builder.HasKey("idProduto");
            builder.Property(f => f.idProduto).HasColumnName("idProduto");
            builder.Property(f => f.idGrupo).HasColumnName("idGrupo");
            builder.Property(f => f.idMarca).HasColumnName("idMarca");
            builder.Property(f => f.PrecoVenda).HasColumnName("PrecoVenda");
            builder.Property(f => f.PrecoCusto).HasColumnName("PrecoCusto");
            builder.Property(f => f.Estoque).HasColumnName("Estoque");
            builder.Property(f => f.DataCadastro).HasColumnName("DataCadastro");

            builder.Property(f => f.Descricao).HasColumnName("Descricao")
                .IsRequired()
                .HasMaxLength(200);

            builder
                .HasOne(d => d.Marca)
                .WithMany()
                .HasForeignKey(f => f.idMarca);

            builder
               .HasOne(d => d.Grupo)
               .WithMany()
               .HasForeignKey(f => f.idGrupo);

        }
    }
}
