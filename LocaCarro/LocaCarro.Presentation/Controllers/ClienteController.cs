using LocaCarro.Domain.Entities;
using LocaCarro.Domain.Interfaces.Repositories;
using LocaCarro.Presentation.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocaCarro.Presentation.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ICarroRepository _carroRepository;
        private readonly ITipoCarroRepository _tipoCarroRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ILojaRepository _lojaRepository;
        private readonly ITarifaRepository _tarifaRepository;

        public ClienteController(ICarroRepository carroRepository,
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
            var clientes = _clienteRepository.GetAll();
            var model = new ListViewModel
            {
                Clientes = clientes.Select(x => new ListViewModel.Client
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Fidelidade = x.Fidelidade,
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
            var cliente = new Cliente();
            cliente.Nome = model.Nome;
            cliente.Fidelidade = model.Fidelidade;

            _clienteRepository.Add(cliente);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid Id)
        {
            var actual = _clienteRepository.GetById(Id);
            var model = new EditViewModel();

            model.Id = actual.Id;
            model.Nome = actual.Nome;
            model.Fidelidade = actual.Fidelidade;
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditViewModel model)
        {
            var cliente = _clienteRepository.GetById(model.Id);
            cliente.Nome = model.Nome;
            cliente.Fidelidade = model.Fidelidade;

            _clienteRepository.Update(cliente);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid Id)
        {
            var cliente = _clienteRepository.GetById(Id);
            var model = new DeleteViewModel();
            model.Id = Id;
            model.Nome = cliente.Nome;
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(DeleteViewModel model)
        {
            var cliente = _clienteRepository.GetById(model.Id);

            _clienteRepository.Remove(cliente);

            return RedirectToAction("Index");
        }
    }
}