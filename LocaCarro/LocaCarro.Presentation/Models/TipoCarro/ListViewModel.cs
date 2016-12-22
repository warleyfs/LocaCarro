using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocaCarro.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LocaCarro.Presentation.Models.TipoCarro
{
    public class ListViewModel
    {
        public List<CarType> Tipos { get; set; }

        public struct CarType
        {
            public Guid Id { get; set; }

            [Display(Name = "Descrição")]
            public string Descricao { get; set; }

            [Display(Name = "Capacidade")]
            public int Capacidade { get; set; }

            [Display(Name = "Criado em")]
            public DateTime CriadoEm { get; set; }

            [Display(Name = "Alterado em")]
            public DateTime? AlteradoEm { get; set; }
        }
    }
}