using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCA.Nucleo.Entidades.Base;

namespace TCA.Nucleo.Entidades.ListaSorteio
{
    public class ItemListaSorteio : Entidade
    {
        public long IdListaSorteio { get; set; }
        public string Descricao { get; set; }
    }
}
