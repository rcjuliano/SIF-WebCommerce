using Aula09.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aula09.Dados.Configuracoes
{
    public class DepartamentoConfiguracao :
        IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamento");
            builder.HasKey("idDepartamento");
            builder.Property(f => f.idDepartamento).HasColumnName("idDepartamento");
            builder.Property(f => f.Descricao).HasColumnName("Descricao")
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
