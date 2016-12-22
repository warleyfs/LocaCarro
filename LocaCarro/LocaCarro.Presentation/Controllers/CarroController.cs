using LocaCarro.Domain.Entities;
using LocaCarro.Domain.Interfaces.Repositories;
using LocaCarro.Presentation.Models.Carro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocaCarro.Presentation.Controllers
{
    public class CarroController : Controller
    {
        private readonly ICarroRepository _carroRepository;
        private readonly ITipoCarroRepository _tipoCarroRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ILojaRepository _lojaRepository;
        private readonly ITarifaRepository _tarifaRepository;

        public CarroController(ICarroRepository carroRepository,
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
            var carros = _carroRepository.GetAll();
            var model = new ListViewModel
            {
                Carros = carros.Select(x => new ListViewModel.Car
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Tipo = x.Tipo.Descricao,
                    CriadoEm = x.CriadoEm,
                    AlteradoEm = x.AlteradoEm
                }).ToList()
            };
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new CreateViewModel();
            model.TipoCarro = _tipoCarroRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Descricao
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateViewModel model)
        {
            var carro = new Carro();
            carro.Nome = model.Nome;
            carro.Tipo = _tipoCarroRepository.GetById(model.TipoCarroId);

            _carroRepository.Add(carro);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid Id)
        {
            var actual = _carroRepository.GetById(Id);
            var model = new EditViewModel();

            model.Id = actual.Id;
            model.Nome = actual.Nome;
            model.TipoCarroId = actual.Tipo.Id;

            model.TipoCarro = _tipoCarroRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Descricao,
                Selected = (x.Id == actual.Tipo.Id)
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {
            var carro = _carroRepository.GetById(model.Id);
            carro.Nome = model.Nome;
            carro.Tipo = _tipoCarroRepository.GetById(model.TipoCarroId);

            _carroRepository.Update(carro);
            
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid Id)
        {
            var carro = _carroRepository.GetById(Id);
            var model = new DeleteViewModel();
            model.Id = Id;
            model.Nome = carro.Nome;
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(DeleteViewModel model)
        {
            var carro = _carroRepository.GetById(model.Id);

            _carroRepository.Remove(carro);

            return RedirectToAction("Index");
        }
    }
}