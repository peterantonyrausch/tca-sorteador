using System.Collections.Generic;

namespace TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida
{
    public struct DadosSaidaVisualizarListasSorteio : Base.DadosSaida
    {
        public IEnumerable<Entidades.ListaSorteio.ListaSorteio> ListasSorteio;
    }
}