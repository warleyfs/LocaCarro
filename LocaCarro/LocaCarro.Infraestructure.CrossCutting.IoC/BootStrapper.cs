using LocaCarro.Domain.Interfaces.Repositories;
using LocaCarro.Domain.Interfaces.Services;
using LocaCarro.Domain.Services;
using LocaCarro.Infraestructure.Data.Context;
using LocaCarro.Infraestructure.Data.Repositories;
using SimpleInjector;

namespace LocaCarro.Infraestructure.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Contexto da Aplicação
            container.Register<ILocaCarroDBContext, LocaCarroDBContext>(Lifestyle.Scoped);

            // Injeção de dependências para as classes das outras camadas da aplicação
            // Serviços de entidades da camada de domínio
            container.Register<ICarroService, CarroService>();
            container.Register<ITipoCarroService, TipoCarroService>();
            container.Register<IClienteService, ClienteService>();
            container.Register<ILojaService, LojaService>();
            container.Register<ITarifaService, TarifaService>(Lifestyle.Scoped);

            // Repositórios
            container.Register<ICarroRepository, CarroRepository>(Lifestyle.Scoped);
            container.Register<ITipoCarroRepository, TipoCarroRepository>(Lifestyle.Scoped);
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<ILojaRepository, LojaRepository>(Lifestyle.Scoped);
            container.Register<ITarifaRepository, TarifaRepository>(Lifestyle.Scoped);
        }
    }
}
