using LocaCarro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCarro.Infraestructure.Data.Context
{
    public interface ILocaCarroDBContext : IDatabaseContext
    {
        DbSet<Carro> Carro { get; set; }
        DbSet<TipoCarro> TipoCarro { get; set; }
        DbSet<Loja> Loja { get; set; }
        DbSet<Tarifa> Tarifa { get; set; }
        DbSet<Cliente> Cliente { get; set; }
    }
}
