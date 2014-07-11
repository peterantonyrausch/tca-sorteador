using TCA.Nucleo.CasosDeUso.Base;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosEntrada;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;

namespace TCA.Nucleo.CasosDeUso.ListaSorteio.AcoesInterfaces
{
    public interface RequisicaoParaCadastrarItemListaSorteio :
        Requisicao<DadosEntradaCadastrarItemListaSorteio, RespostaRequisicao<DadosSaidaCadastrarItemListaSorteio>>
    {
    }
}