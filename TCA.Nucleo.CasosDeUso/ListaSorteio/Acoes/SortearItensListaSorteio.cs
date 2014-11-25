using System;
using System.Collections.Generic;
using System.Linq;
using TCA.Nucleo.CasosDeUso.ListaSorteio.AcoesInterfaces;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;
using TCA.Nucleo.CasosDeUso.ListaSorteio.Excecoes;
using TCA.Nucleo.DAL.Interfaces.ListaSorteio;
using TCA.Nucleo.Utils;

namespace TCA.Nucleo.CasosDeUso.ListaSorteio.Acoes
{
    public class SortearItensListaSorteio : RequisicaoParaSortearItensListaSorteio
    {
        private readonly RepositorioItemListaSorteio repositorioItemListaSorteio;

        public SortearItensListaSorteio(RepositorioItemListaSorteio repositorioItemListaSorteio)
        {
            this.repositorioItemListaSorteio = repositorioItemListaSorteio;
        }

        public void Executar(DadosEntrada.DadosEntradaSortearItensListaSorteio dadosEntrada, Base.RespostaRequisicao<DadosSaida.DadosSaidaSortearItensListaSorteio> respostaRequisicao)
        {
            ValidarDadosEntrada(dadosEntrada);

            respostaRequisicao.ProcessarResposta(SortearItensDaListaDeSorteio(dadosEntrada.IdListaSorteio));
        }

        private void ValidarDadosEntrada(DadosEntrada.DadosEntradaSortearItensListaSorteio dadosEntrada)
        {
            if (!repositorioItemListaSorteio.ListarPorListaSorteio(dadosEntrada.IdListaSorteio).Any())
                throw new ListaSorteioSemItensException();
        }

        private DadosSaida.DadosSaidaSortearItensListaSorteio SortearItensDaListaDeSorteio(long idListaSorteio)
        {
            var itens = repositorioItemListaSorteio.ListarPorListaSorteio(idListaSorteio);

            var itensSorteados = itens.ToList();
            
            itensSorteados.Shuffle();

            return new DadosSaidaSortearItensListaSorteio()
            {
                ItensListaSorteio = itensSorteados
            };
        }

        
    }
}
