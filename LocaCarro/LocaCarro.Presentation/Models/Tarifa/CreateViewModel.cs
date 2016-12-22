using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocaCarro.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LocaCarro.Presentation.Models.Tarifa
{
    public class CreateViewModel
    {
        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public double Valor { get; set; }

        [Display(Name = "Tarifa de dia útil?")]
        public bool DiaUtil { get; set; }

        [Display(Name = "Fidelização?")]
        public bool Fidelizacao { get; set; }

        [Display(Name = "Loja")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid LojaId { get; set; }

        public List<SelectListItem> Loja { get; set; }
    }
}