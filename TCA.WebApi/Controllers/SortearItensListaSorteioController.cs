using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCA.Nucleo.CasosDeUso.ListaSorteio.Acoes;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosEntrada;
using TCA.WebApi.RespostaRequisicao;

namespace TCA.WebApi.Controllers
{
    [RoutePrefix("api/v1")]
    public class SortearItensListaSorteioController : ApiController
    {
        #region [ Get ]

        [Route("sortearitenslistasorteio/{idListaSorteio}")]
        public HttpResponseMessage GetItemListaSorteio(long idListaSorteio)
        {
            if (idListaSorteio <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                var repositorioItemListaSorteio = Utils.ObterUnidadeTrabalhoSorteador().RepositorioItemListaSorteio;
                var sortearItensListarSorteio = new SortearItensListaSorteio(repositorioItemListaSorteio);

                var respostaRequisicaoSortearItensListaSorteio = new RespostaRequisicaoSortearItensListaSorteio();

                sortearItensListarSorteio.Executar(ObterDadosEntradaSortearItensListaSorteio(idListaSorteio), respostaRequisicaoSortearItensListaSorteio);

                return Request.CreateResponse(HttpStatusCode.OK, respostaRequisicaoSortearItensListaSorteio.ItensListaSorteio);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }

        private DadosEntradaSortearItensListaSorteio ObterDadosEntradaSortearItensListaSorteio(long idListaSorteio)
        {
            return new DadosEntradaSortearItensListaSorteio { IdListaSorteio = idListaSorteio };
        }
        #endregion [ Get ]
    }
}
