using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCarro.Domain.Entities
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AlteradoEm { get; set; }
    }
}
