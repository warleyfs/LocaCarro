using LocaCarro.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LocaCarro.Infraestructure.Data.EntityConfig
{
    public class TipoCarroConfig : EntityTypeConfiguration<TipoCarro>
    {
        public TipoCarroConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(250);

            Property(x => x.Capacidade)
                .IsRequired();

            HasOptional(x => x.Loja)
                .WithOptionalPrincipal(x => x.Tipo);
        }
    }
}
