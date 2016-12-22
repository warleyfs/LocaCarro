using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocaCarro.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LocaCarro.Presentation.Models.Tarifa
{
    public class ListViewModel
    {
        public List<Tax> Tarifas { get; set; }

        public struct Tax
        {
            public Guid Id { get; set; }

            [Display(Name = "Valor")]
            public double Valor { get; set; }

            [Display(Name = "Tarifa de dia útil?")]
            public bool DiaUtil { get; set; }

            [Display(Name = "Fidelização?")]
            public bool Fidelizacao { get; set; }

            [Display(Name = "Loja")]
            public string Loja { get; set; }

            [Display(Name = "Criado em")]
            public DateTime CriadoEm { get; set; }

            [Display(Name = "Alterado em")]
            public DateTime? AlteradoEm { get; set; }
        }
    }
}