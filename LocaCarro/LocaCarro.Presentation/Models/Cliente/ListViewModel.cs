using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocaCarro.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LocaCarro.Presentation.Models.Cliente
{
    public class ListViewModel
    {
        public List<Client> Clientes { get; set; }

        public struct Client
        {
            public Guid Id { get; set; }

            [Display(Name = "Nome")]
            public string Nome { get; set; }

            [Display(Name = "Fidelidade?")]
            public bool Fidelidade { get; set; }

            [Display(Name = "Criado em")]
            public DateTime CriadoEm { get; set; }

            [Display(Name = "Alterado em")]
            public DateTime? AlteradoEm { get; set; }
        }
    }
}