using System.Collections.Generic;
using TCA.Nucleo.CasosDeUso.Base;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;
using TCA.WebApi.Models;

namespace TCA.WebApi.RespostaRequisicao
{
    public class RespostaRequisicaoSortearItensListaSorteio : RespostaRequisicao<DadosSaidaSortearItensListaSorteio>
    {
        public IEnumerable<ItemListaSorteio> ItensListaSorteio { get; set; }
        
        public void ProcessarResposta(DadosSaidaSortearItensListaSorteio dadosSaida)
        {
            ItensListaSorteio = Utils.ConverterParaItensListaSorteio(dadosSaida.ItensListaSorteio);
        }
    }
}