using LocaCarro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCarro.Infraestructure.Data.EntityConfig
{
    public class LojaConfig : EntityTypeConfiguration<Loja>
    {
        public LojaConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Nome)
                .IsRequired();

            HasOptional(x => x.Tipo)
                .WithOptionalDependent(x => x.Loja);
        }
    }
}
