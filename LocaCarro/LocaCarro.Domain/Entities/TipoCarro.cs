using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCarro.Domain.Entities
{
    public class TipoCarro : BaseEntity<Guid>
    {
        public string Descricao { get; set; }
        public int Capacidade { get; set; }
        public virtual Loja Loja { get; set; }
        public virtual ICollection<Carro> Carros { get; set; }
    }
}
