using TCA.Nucleo.CasosDeUso.Base;
using TCA.Nucleo.CasosDeUso.ListaSorteio.AcoesInterfaces;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosEntrada;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;
using TCA.Nucleo.CasosDeUso.ListaSorteio.Excecoes;
using TCA.Nucleo.DAL.Interfaces.ListaSorteio;
using TCA.Nucleo.Entidades.ListaSorteio;

namespace TCA.Nucleo.CasosDeUso.ListaSorteio.Acoes
{
    public class CadastrarItemListaSorteio : RequisicaoParaCadastrarItemListaSorteio
    {
        private readonly RepositorioItemListaSorteio repositorioItemLista;

        public CadastrarItemListaSorteio(RepositorioItemListaSorteio repositorioItemLista)
        {
            this.repositorioItemLista = repositorioItemLista;
        }

        public void Executar(DadosEntradaCadastrarItemListaSorteio dadosEntrada, RespostaRequisicao<DadosSaidaCadastrarItemListaSorteio> respostaRequisicao)
        {
            ValidarDadosEntrada(dadosEntrada);

            var itemLista = ConstruirItemListaSorteio(dadosEntrada);

            repositorioItemLista.Inserir(itemLista);

            respostaRequisicao.ProcessarResposta(CriarDadosSaida(itemLista));
        }

        private static void ValidarDadosEntrada(DadosEntradaCadastrarItemListaSorteio dadosEntrada)
        {
            if (dadosEntrada.IdListaSorteio == 0)
                throw new ItemListaSorteioSemReferenciaParaListaException();

            if (string.IsNullOrWhiteSpace(dadosEntrada.Descricao))
                throw new ItemListaSorteioSemDescricaoException();
        }

        private static DadosSaidaCadastrarItemListaSorteio CriarDadosSaida(ItemListaSorteio itemLista)
        {
            return new DadosSaidaCadastrarItemListaSorteio()
            {
                IdItemListaSorteio = itemLista.Id
            };
        }

        private static ItemListaSorteio ConstruirItemListaSorteio(DadosEntradaCadastrarItemListaSorteio dadosEntrada)
        {
            return new ItemListaSorteio()
            {
                IdListaSorteio = dadosEntrada.IdListaSorteio,
                Descricao = dadosEntrada.Descricao
            };
        }
    }
}