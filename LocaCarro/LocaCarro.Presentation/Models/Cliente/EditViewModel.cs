using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocaCarro.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LocaCarro.Presentation.Models.Cliente
{
    public class EditViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Fidelidade?")]
        public bool Fidelidade { get; set; }
    }
}