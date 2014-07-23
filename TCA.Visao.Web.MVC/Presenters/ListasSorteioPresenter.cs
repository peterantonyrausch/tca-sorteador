using System.Collections.Generic;
using System.Linq;
using TCA.Nucleo.CasosDeUso.Base;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;
using TCA.Nucleo.Entidades.ListaSorteio;
using TCA.Visao.Web.MVC.Models;

namespace TCA.Visao.Web.MVC.Presenters
{
    public class ListasSorteioPresenter :
        RespostaRequisicao<DadosSaidaVisualizarListasSorteio>,
        RespostaRequisicao<DadosSaidaCadastrarListaSorteio>
    {
        public IEnumerable<ListaSorteioViewModel> ListasSorteio { get; private set; }

        public long IdListaSorteioCadastrada { get; private set; }

        public void ProcessarResposta(DadosSaidaCadastrarListaSorteio dadosSaida)
        {
            IdListaSorteioCadastrada = dadosSaida.IdListaSorteio;
        }

        public void ProcessarResposta(DadosSaidaVisualizarListasSorteio dadosSaida)
        {
            ListasSorteio = ConverterParaViewModel(dadosSaida.ListasSorteio);
        }

        private static IEnumerable<ListaSorteioViewModel> ConverterParaViewModel(IEnumerable<ListaSorteio> listasSorteio)
        {
            return listasSorteio.Select(listaSorteio =>
                new ListaSorteioViewModel
                {
                    IdListaSorteio = listaSorteio.Id,
                    Nome = listaSorteio.Nome
                });
        }
    }
}