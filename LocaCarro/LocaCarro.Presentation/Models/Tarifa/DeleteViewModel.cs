using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocaCarro.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LocaCarro.Presentation.Models.Tarifa
{
    public class DeleteViewModel
    {
        public Guid Id { get; set; }
        public string Loja { get; set; }
        public double Valor { get; set; }
    }
}