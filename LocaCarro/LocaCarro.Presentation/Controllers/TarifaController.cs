using LocaCarro.Domain.Entities;
using LocaCarro.Domain.Interfaces.Repositories;
using LocaCarro.Presentation.Models.Tarifa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocaCarro.Presentation.Controllers
{
    public class TarifaController : Controller
    {
        private readonly ICarroRepository _carroRepository;
        private readonly ITipoCarroRepository _tipoCarroRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ILojaRepository _lojaRepository;
        private readonly ITarifaRepository _tarifaRepository;

        public TarifaController(ICarroRepository carroRepository,
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
            var tarifas = _tarifaRepository.GetAll();
            var model = new ListViewModel
            {
                Tarifas = tarifas.Select(x => new ListViewModel.Tax
                {
                    Id = x.Id,
                    Valor = x.Valor,
                    DiaUtil = x.DiaUtil,
                    Fidelizacao = x.Fidelizacao,
                    Loja = x.Loja.Nome,
                    CriadoEm = x.CriadoEm,
                    AlteradoEm = x.AlteradoEm
                }).ToList()
            };
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new CreateViewModel();
            
            model.Loja = _lojaRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nome
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateViewModel model)
        {
            var tarifa = new Tarifa();
            tarifa.Valor = model.Valor;
            tarifa.DiaUtil = model.DiaUtil;
            tarifa.Fidelizacao = model.Fidelizacao;
            tarifa.Loja = _lojaRepository.GetById(model.LojaId);

            _tarifaRepository.Add(tarifa);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid Id)
        {
            var actual = _tarifaRepository.GetById(Id);
            var model = new EditViewModel();

            model.Id = actual.Id;
            model.Valor = actual.Valor;
            model.DiaUtil = actual.DiaUtil;
            model.Fidelizacao = actual.Fidelizacao;
            model.LojaId = actual.Loja.Id;
            
            model.Loja = _lojaRepository.GetAll().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nome,
                Selected = x.Id == actual.Loja.Id
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {
            var tarifa = _tarifaRepository.GetById(model.Id);
            tarifa.Valor = model.Valor;
            tarifa.DiaUtil = model.DiaUtil;
            tarifa.Fidelizacao = model.Fidelizacao;
            tarifa.Loja = _lojaRepository.GetById(model.LojaId);

            _tarifaRepository.Update(tarifa);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid Id)
        {
            var tarifa = _tarifaRepository.GetById(Id);
            var model = new DeleteViewModel();
            model.Id = Id;
            model.Loja = tarifa.Loja.Nome;
            model.Valor = tarifa.Valor;

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(DeleteViewModel model)
        {
            var tarifa = _tarifaRepository.GetById(model.Id);

            _tarifaRepository.Remove(tarifa);

            return RedirectToAction("Index");
        }
    }
}