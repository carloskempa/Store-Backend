using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Cadastro.Domain;

namespace Store.Cadastro.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasColumnName("Nome")
                   .HasColumnType("varchar(100)");

            builder.Property(c => c.Login)
                   .IsRequired()
                   .HasColumnName("Login")
                   .HasColumnType("varchar(50)");

            builder.Property(c => c.IsAdministrador)
                   .IsRequired()
                   .HasColumnName("IsAdministrador")
                   .HasColumnType("bit");

            builder.Property(c => c.Senha)
                   .IsRequired()
                   .HasColumnName("Senha")
                   .HasColumnType("varbinary(max)");

            builder.Property(c => c.RefleshToken)
                   .HasColumnName("RefleshToken")
                   .HasColumnType("varchar(100)");

            builder.HasOne(c => c.Cliente)
                  .WithMany(c => c.Usuarios)
                  .HasForeignKey(c => c.ClienteId);

            builder.ToTable("Usuarios");
        }
    }
}
