using LocaCarro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCarro.Infraestructure.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Nome)
                .IsRequired();

            Property(x => x.Fidelidade)
                .IsRequired();
        }
    }
}
