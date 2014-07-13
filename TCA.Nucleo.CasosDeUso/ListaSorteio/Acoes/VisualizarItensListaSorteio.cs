using System.Collections.Generic;
using TCA.Nucleo.CasosDeUso.Base;
using TCA.Nucleo.CasosDeUso.ListaSorteio.AcoesInterfaces;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosEntrada;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;
using TCA.Nucleo.DAL.Interfaces.ListaSorteio;
using TCA.Nucleo.Entidades.ListaSorteio;

namespace TCA.Nucleo.CasosDeUso.ListaSorteio.Acoes
{
    public class VisualizarItensListaSorteio : RequisicaoParaVisualizarItensListaSorteio
    {
        private readonly RepositorioItemListaSorteio repositorioItemListaSorteio;

        public VisualizarItensListaSorteio(RepositorioItemListaSorteio repositorioItemListaSorteio)
        {
            this.repositorioItemListaSorteio = repositorioItemListaSorteio;
        }

        public void Executar(DadosEntradaVisualizarItensListaSorteio dadosEntrada,
            RespostaRequisicao<DadosSaidaVisualizarItensListaSorteio> respostaRequisicao)
        {
            var itensListaSorteio = repositorioItemListaSorteio.ListarPorListaSorteio(dadosEntrada.IdListaSorteio);

            respostaRequisicao.ProcessarResposta(CriarDadosSaida(dadosEntrada.IdListaSorteio, itensListaSorteio));
        }

        private static DadosSaidaVisualizarItensListaSorteio CriarDadosSaida(long idListaSorteio, IEnumerable<ItemListaSorteio> itensListaSorteio)
        {
            return new DadosSaidaVisualizarItensListaSorteio()
            {
                IdListaSorteio = idListaSorteio,
                ItensListaSorteio = itensListaSorteio
            };
        }
    }
}