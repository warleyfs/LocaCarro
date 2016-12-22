using LocaCarro.Domain.Entities;
using LocaCarro.Domain.Interfaces.Repositories;
using LocaCarro.Domain.Interfaces.Services;

namespace LocaCarro.Domain.Services
{
    public class TipoCarroService : BaseEntityService<TipoCarro>, ITipoCarroService
    {
        private readonly ITipoCarroRepository _repository;

        public TipoCarroService(ITipoCarroRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
