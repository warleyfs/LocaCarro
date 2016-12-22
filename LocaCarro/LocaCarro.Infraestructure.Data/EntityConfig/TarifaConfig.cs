using LocaCarro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCarro.Infraestructure.Data.EntityConfig
{
    public class TarifaConfig : EntityTypeConfiguration<Tarifa>
    {
        public TarifaConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.DiaUtil)
                .IsRequired();

            Property(x => x.Fidelizacao)
                .IsRequired();

            Property(x => x.Valor)
                .IsRequired();
            
            HasRequired(x => x.Loja)
                .WithMany(x => x.Tarifas);
        }
    }
}
