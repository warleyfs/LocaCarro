using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocaCarro.Presentation.Models.Home
{
    public class IndexViewModel
    {
        [Display(Name = "Possui cartão fidelidade?")]
        public bool Fidelidade { get; set; }

        [Required(ErrorMessage = "É obrigatório fornecer um arquivo.")]
        public HttpPostedFileBase Entrada { get; set; }
        
        public List<Return> Retorno { get; set; }

        public struct Return
        {
            public string Carro { get; set; }
            public string Loja { get; set; }
        }
    }
}