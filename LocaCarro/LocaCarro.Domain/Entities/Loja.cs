using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCarro.Domain.Entities
{
    public class Loja : BaseEntity<Guid>
    {
        public string Nome { get; set; }
        public virtual TipoCarro Tipo { get; set; }
        public virtual ICollection<Tarifa> Tarifas { get; set; }
    }
}
