using TCA.Nucleo.CasosDeUso.Base;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;

namespace TCA.WebApi.RespostaRequisicao
{
    public class RespostaRequisicaoCadastrarItemListaSorteio : RespostaRequisicao<DadosSaidaCadastrarItemListaSorteio>
    {
        public long IdItemListaSorteio { get; set; }

        public void ProcessarResposta(DadosSaidaCadastrarItemListaSorteio dadosSaida)
        {
            IdItemListaSorteio = dadosSaida.IdItemListaSorteio;
        }
    }
}