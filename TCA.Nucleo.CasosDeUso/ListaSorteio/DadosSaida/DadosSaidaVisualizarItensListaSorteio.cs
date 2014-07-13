using System.Collections.Generic;
using TCA.Nucleo.Entidades.ListaSorteio;

namespace TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida
{
    public struct DadosSaidaVisualizarItensListaSorteio : Base.DadosSaida
    {
        public long IdListaSorteio;
        public IEnumerable<ItemListaSorteio> ItensListaSorteio;
    }
}