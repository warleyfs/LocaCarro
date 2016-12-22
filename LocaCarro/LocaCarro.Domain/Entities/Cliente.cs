using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCarro.Domain.Entities
{
    public class Cliente : BaseEntity<Guid>
    {
        public string Nome { get; set; }
        public bool Fidelidade { get; set; }
    }
}
