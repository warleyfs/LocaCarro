using LocaCarro.Domain.Entities;
using LocaCarro.Domain.Interfaces.Repositories;
using LocaCarro.Domain.Interfaces.Services;

namespace LocaCarro.Domain.Services
{
    public class TarifaService : BaseEntityService<Tarifa>, ITarifaService
    {
        private readonly ITarifaRepository _repository;

        public TarifaService(ITarifaRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
