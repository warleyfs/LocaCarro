using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocaCarro.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LocaCarro.Presentation.Models.TipoCarro
{
    public class CreateViewModel
    {
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Descricao { get; set; }

        [Display(Name = "Capacidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int Capacidade { get; set; }
    }
}