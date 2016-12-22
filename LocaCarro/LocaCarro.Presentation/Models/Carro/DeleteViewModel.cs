using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocaCarro.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LocaCarro.Presentation.Models.Carro
{
    public class DeleteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}