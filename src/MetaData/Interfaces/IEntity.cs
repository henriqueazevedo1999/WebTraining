using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaData.Interfaces
{
    internal interface IEntity
    {
        public int ID { get; set; }
        public DateTime TimeCreated { get; set; }
        public bool Ativo { get; set; }
    }
}
