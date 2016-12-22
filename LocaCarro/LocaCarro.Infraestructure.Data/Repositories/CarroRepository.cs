using LocaCarro.Domain.Entities;
using LocaCarro.Domain.Interfaces.Repositories;
using LocaCarro.Infraestructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCarro.Infraestructure.Data.Repositories
{
    public class CarroRepository : BaseRepository<Carro>, ICarroRepository
    {
        public CarroRepository(ILocaCarroDBContext context) : base(context)
        {
        }
    }
}
