using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocaCarro.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LocaCarro.Presentation.Models.Carro
{
    public class ListViewModel
    {
        public List<Car> Carros { get; set; }

        public struct Car
        {
            public Guid Id { get; set; }

            [Display(Name = "Nome")]
            public string Nome { get; set; }

            [Display(Name = "Tipo")]
            public string Tipo { get; set; }

            [Display(Name = "Criado em")]
            public DateTime CriadoEm { get; set; }

            [Display(Name = "Alterado em")]
            public DateTime? AlteradoEm { get; set; }
        }
    }
}