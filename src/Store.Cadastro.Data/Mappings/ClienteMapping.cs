using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Cadastro.Domain;

namespace Store.Cadastro.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasColumnName("Nome")
                   .HasColumnType("varchar(100)");

            builder.OwnsOne(c => c.Email, cm =>
            {
                cm.Property(c => c.Endereco)
                  .HasColumnName("Email")
                  .HasColumnType("varchar(200)");
            });

            builder.Property(c => c.Contato)
                   .IsRequired()
                   .HasColumnName("Contato")
                   .HasColumnType("varchar(200)");

            builder.ToTable("Clientes");
        }
    }
}
