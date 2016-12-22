using LocaCarro.Domain.Entities;
using LocaCarro.Domain.Interfaces.Repositories;
using LocaCarro.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCarro.Domain.Services
{
    public class ClienteService : BaseEntityService<Cliente>, IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
