using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCarro.Domain.Entities
{
    public class Tarifa : BaseEntity<Guid>
    {
        public double Valor { get; set; }
        public bool DiaUtil { get; set; }
        public bool Fidelizacao { get; set; }
        public virtual Loja Loja { get; set; }
    }
}
