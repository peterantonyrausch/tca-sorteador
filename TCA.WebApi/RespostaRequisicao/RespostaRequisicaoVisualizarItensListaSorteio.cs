using System.Collections.Generic;
using System.Linq;
using TCA.Nucleo.CasosDeUso.Base;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;
using TCA.WebApi.Models;

namespace TCA.WebApi.RespostaRequisicao
{
    public class RespostaRequisicaoVisualizarItensListaSorteio : RespostaRequisicao<DadosSaidaVisualizarItensListaSorteio>
    {
        public long IdListaSorteio { get; set; }

        public IEnumerable<ItemListaSorteio> ItensListaSorteio { get; set; }


        public void ProcessarResposta(DadosSaidaVisualizarItensListaSorteio dadosSaida)
        {
            IdListaSorteio = dadosSaida.IdListaSorteio;
            ItensListaSorteio = Utils.ConverterParaItensListaSorteio(dadosSaida.ItensListaSorteio);
        }

        
    }
}