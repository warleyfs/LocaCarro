using LocaCarro.Domain.Interfaces.Repositories;
using LocaCarro.Presentation.Models.Home;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocaCarro.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarroRepository _carroRepository;
        private readonly ITipoCarroRepository _tipoCarroRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ILojaRepository _lojaRepository;
        private readonly ITarifaRepository _tarifaRepository;

        public HomeController(ICarroRepository carroRepository,
                              ITipoCarroRepository tipoCarroRepository,
                              IClienteRepository clienteRepository,
                              ILojaRepository lojaRepository,
                              ITarifaRepository tarifaRepository)
        {
            _carroRepository = carroRepository;
            _tipoCarroRepository = tipoCarroRepository;
            _clienteRepository = clienteRepository;
            _lojaRepository = lojaRepository;
            _tarifaRepository = tarifaRepository;
        }

        public ActionResult Index()
        {
            var model = new IndexViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Retorno = new List<IndexViewModel.Return>();

            var reader = new StreamReader(model.Entrada.InputStream);

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var valores = line.Split(':');

                var tpCarro = valores[0];

                var tipo = _tipoCarroRepository.GetAll()
                    .Where(x => x.Descricao.ToUpper() == tpCarro.ToUpper())
                    .FirstOrDefault();

                var ocupacao = int.Parse(valores[1]);

                var loja = _lojaRepository.GetAll()
                    .Where(x => x.Tipo.Id == tipo.Id && ocupacao <= x.Tipo.Capacidade)
                    .FirstOrDefault();

                if (tipo != null && loja != null)
                {
                    var datas = valores[2].Split(',');

                    var dataInicial = DateTime.Parse(datas[0].Substring(0, 9));
                    var dataFinal = DateTime.Parse(datas[1].Substring(0, 9));
                    var totalDias = (dataFinal - dataInicial).TotalDays;

                    var diaAtual = dataInicial;

                    var precoFinal = 0.00;

                    for (int i = 1; i <= totalDias; i++)
                    {
                        var diaUtil = false;

                        if (diaAtual.DayOfWeek != DayOfWeek.Saturday && diaAtual.DayOfWeek != DayOfWeek.Sunday)
                        {
                            diaUtil = true;
                        }

                        var tarifaDoDia = _tarifaRepository.GetAll()
                            .Where(x => x.DiaUtil == diaUtil
                                     && x.Fidelizacao == model.Fidelidade
                                     && x.Loja.Id == loja.Id)
                            .OrderBy(x => x.Valor)
                            .FirstOrDefault();

                        if (tarifaDoDia != null && tarifaDoDia.Valor > 0)
                        {
                            precoFinal += tarifaDoDia.Valor;
                        }
                        
                        diaAtual.AddDays(i);
                    }

                    model.Retorno.Add(new IndexViewModel.Return { Carro = tipo.Carros.FirstOrDefault().Nome, Loja = loja.Nome });
                }
            }

            return View(model);
        }
    }
}