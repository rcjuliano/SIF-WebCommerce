using Aula09.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebCommerce.Dados.Configuracoes
{
    public class GrupoConfiguracao :
        IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.ToTable("Grupo");
            builder.HasKey("idGrupo");
            builder.Property(f => f.idGrupo).HasColumnName("idGrupo");
            builder.Property(f => f.idDepartamento).HasColumnName("idDepartamento");
            builder.Property(f => f.Descricao).HasColumnName("Descricao")
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}