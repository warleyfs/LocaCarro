using LocaCarro.Domain.Entities;
using LocaCarro.Domain.Interfaces.Repositories;
using LocaCarro.Domain.Interfaces.Services;

namespace LocaCarro.Domain.Services
{
    public class CarroService : BaseEntityService<Carro>, ICarroService
    {
        private readonly ICarroRepository _repository;

        public CarroService(ICarroRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
