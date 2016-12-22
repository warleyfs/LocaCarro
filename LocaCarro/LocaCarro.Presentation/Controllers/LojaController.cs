using LocaCarro.Domain.Entities;
using LocaCarro.Domain.Interfaces.Repositories;
using LocaCarro.Presentation.Models.Loja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocaCarro.Presentation.Controllers
{
    public class LojaController : Controller
    {
        private readonly ICarroRepository _carroRepository;
        private readonly ITipoCarroRepository _tipoCarroRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ILojaRepository _lojaRepository;
        private readonly ITarifaRepository _tarifaRepository;

        public LojaController(ICarroRepository carroRepository,
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
            var lojas = _lojaRepository.GetAll();
            var model = new ListViewModel
            {
                Lojas = lojas.Select(x => new ListViewModel.Shop
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
            model.TipoCarro = _tipoCarroRepository.GetAll()
                .Where(x => x.Loja == null)
                .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Descricao
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateViewModel model)
        {
            var loja = new Loja();
            loja.Nome = model.Nome;
            loja.Tipo = _tipoCarroRepository.GetById(model.TipoCarroId);

            _lojaRepository.Add(loja);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid Id)
        {
            var actual = _lojaRepository.GetById(Id);
            var model = new EditViewModel();

            model.Id = actual.Id;
            model.Nome = actual.Nome;
            model.TipoCarroId = actual.Tipo.Id;

            model.TipoCarro = _tipoCarroRepository.GetAll()
                .Where(x => x.Loja == null)
                .Select(x => new SelectListItem
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
            var loja = _lojaRepository.GetById(model.Id);
            loja.Nome = model.Nome;
            loja.Tipo = _tipoCarroRepository.GetById(model.TipoCarroId);

            _lojaRepository.Update(loja);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid Id)
        {
            var loja = _lojaRepository.GetById(Id);
            var model = new DeleteViewModel();
            model.Id = Id;
            model.Nome = loja.Nome;
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(DeleteViewModel model)
        {
            var loja = _lojaRepository.GetById(model.Id);

            _lojaRepository.Remove(loja);

            return RedirectToAction("Index");
        }
    }
}