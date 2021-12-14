using MetaData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaData.Entities
{
    public class Produto : Entity
    {
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public double Estoque { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}
