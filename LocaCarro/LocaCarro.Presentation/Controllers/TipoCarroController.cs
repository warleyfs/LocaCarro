using LocaCarro.Domain.Entities;
using LocaCarro.Domain.Interfaces.Repositories;
using LocaCarro.Presentation.Models.TipoCarro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocaCarro.Presentation.Controllers
{
    public class TipoCarroController : Controller
    {
        private readonly ICarroRepository _carroRepository;
        private readonly ITipoCarroRepository _tipoCarroRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ILojaRepository _lojaRepository;
        private readonly ITarifaRepository _tarifaRepository;

        public TipoCarroController(ICarroRepository carroRepository,
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
            var tpcarros = _tipoCarroRepository.GetAll();
            var model = new ListViewModel
            {
                Tipos = tpcarros.Select(x => new ListViewModel.CarType
                {
                    Id = x.Id,
                    Capacidade = x.Capacidade,
                    Descricao = x.Descricao,
                    CriadoEm = x.CriadoEm,
                    AlteradoEm = x.AlteradoEm
                }).ToList()
            };
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new CreateViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateViewModel model)
        {
            var tpcarro = new TipoCarro();
            tpcarro.Descricao = model.Descricao;
            tpcarro.Capacidade = model.Capacidade;

            _tipoCarroRepository.Add(tpcarro);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid Id)
        {
            var actual = _tipoCarroRepository.GetById(Id);
            var model = new EditViewModel();

            model.Id = actual.Id;
            model.Descricao = actual.Descricao;
            model.Capacidade = actual.Capacidade;
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {
            var tpcarro = _tipoCarroRepository.GetById(model.Id);
            tpcarro.Descricao = model.Descricao;
            tpcarro.Capacidade = model.Capacidade;

            _tipoCarroRepository.Update(tpcarro);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid Id)
        {
            var tpcarro = _tipoCarroRepository.GetById(Id);
            var model = new DeleteViewModel();
            model.Id = Id;
            model.Descricao = tpcarro.Descricao;
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(DeleteViewModel model)
        {
            var tpcarro = _tipoCarroRepository.GetById(model.Id);

            _tipoCarroRepository.Remove(tpcarro);

            return RedirectToAction("Index");
        }
    }
}