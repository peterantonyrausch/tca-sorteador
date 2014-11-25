using System.Collections.Generic;
using TCA.Nucleo.Entidades.ListaSorteio;

namespace TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida
{
    public struct DadosSaidaSortearItensListaSorteio : Base.DadosSaida
    {
        public IEnumerable<ItemListaSorteio> ItensListaSorteio { get; set; }
    }
}
