﻿using LocaCarro.Domain.Entities;
using LocaCarro.Domain.Interfaces.Repositories;
using LocaCarro.Infraestructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCarro.Infraestructure.Data.Repositories
{
    public class LojaRepository : BaseRepository<Loja>, ILojaRepository
    {
        public LojaRepository(ILocaCarroDBContext context) : base(context)
        {
        }
    }
}
