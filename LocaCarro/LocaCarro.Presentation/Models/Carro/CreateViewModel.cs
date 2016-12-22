using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocaCarro.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LocaCarro.Presentation.Models.Carro
{
    public class CreateViewModel
    {

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid TipoCarroId { get; set; }

        public List<SelectListItem> TipoCarro { get; set; }
    }
}