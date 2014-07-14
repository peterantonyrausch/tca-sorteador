using System.Collections.Generic;
using TCA.Nucleo.Entidades.Base;

namespace TCA.Nucleo.Entidades.ListaSorteio
{
    public class ListaSorteio : Entidade
    {
        public string Nome { get; set; }

        public virtual ICollection<ItemListaSorteio> ItensListaSorteio { get; set; }
    }
}