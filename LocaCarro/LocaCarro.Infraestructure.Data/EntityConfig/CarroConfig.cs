using LocaCarro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCarro.Infraestructure.Data.EntityConfig
{
    public class CarroConfig : EntityTypeConfiguration<Carro>
    {
        public CarroConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Nome)
                .IsRequired();

            HasRequired(x => x.Tipo)
                .WithMany(x => x.Carros);
        }
    }
}
