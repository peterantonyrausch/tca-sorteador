using System.Collections.Generic;
using TCA.Nucleo.CasosDeUso.Base;
using TCA.Nucleo.CasosDeUso.ListaSorteio.AcoesInterfaces;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;
using TCA.Nucleo.DAL.Interfaces.ListaSorteio;

namespace TCA.Nucleo.CasosDeUso.ListaSorteio.Acoes
{
    public class VisualizarListasSorteio : RequisicaoParaVisualizarListasSorteio
    {
        private readonly RepositorioListaSorteio repositorioListaSorteio;

        public VisualizarListasSorteio(RepositorioListaSorteio repositorioListaSorteio)
        {
            this.repositorioListaSorteio = repositorioListaSorteio;
        }

        public void Executar(RespostaRequisicao<DadosSaidaVisualizarListasSorteio> respostaRequisicao)
        {
            var listasSorteio = repositorioListaSorteio.Listar();

            respostaRequisicao.ProcessarResposta(CriarDadosSaida(listasSorteio));
        }

        private static DadosSaidaVisualizarListasSorteio CriarDadosSaida(IEnumerable<Entidades.ListaSorteio.ListaSorteio> listasSorteio)
        {
            return new DadosSaidaVisualizarListasSorteio()
            {
                ListasSorteio = listasSorteio
            };
        }
    }
}