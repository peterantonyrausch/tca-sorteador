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
    public class ItemListaSorteioController : ApiController
    {
        #region [ Post ]
        [HttpPost]
        [Route("itemlistasorteio")]
        public HttpResponseMessage PostItemListaSorteio(Models.ItemListaSorteio itemListaSorteio)
        {
            if (itemListaSorteio == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            try
            {
                var repositorioItemListaSorteio = Utils.ObterUnidadeTrabalhoSorteador().RepositorioItemListaSorteio;
                var cadastrarItemListaSorteio = new CadastrarItemListaSorteio(repositorioItemListaSorteio);

                var respostaRequisicao = new RespostaRequisicaoCadastrarItemListaSorteio();

                cadastrarItemListaSorteio.Executar(ObterDadosEntradaCadastrarItemListaSorteio(itemListaSorteio),
                    respostaRequisicao);

                itemListaSorteio.IdItemListaSorteio = respostaRequisicao.IdItemListaSorteio;

                return Request.CreateResponse(HttpStatusCode.OK, itemListaSorteio);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }

        private DadosEntradaCadastrarItemListaSorteio ObterDadosEntradaCadastrarItemListaSorteio(Models.ItemListaSorteio itemListaSorteio)
        {
            return new DadosEntradaCadastrarItemListaSorteio
            {
                Descricao = itemListaSorteio.Descricao,
                IdListaSorteio = itemListaSorteio.IdListaSorteio
            };
        }
        #endregion [ Post ]
        
        #region [ Get ]

        [Route("itemlistasorteio/{idListaSorteio}")]
        public HttpResponseMessage GetItemListaSorteio(long idListaSorteio)
        {
            if (idListaSorteio <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                var repositorioItemListaSorteio = Utils.ObterUnidadeTrabalhoSorteador().RepositorioItemListaSorteio;
                var visualizarItensSorteio = new VisualizarItensListaSorteio(repositorioItemListaSorteio);

                var respostaRequisicaoVisualizarItensListaSorteio = new RespostaRequisicaoVisualizarItensListaSorteio();

                visualizarItensSorteio.Executar(ObterDadosEntradaVisualizarItensListaSorteio(idListaSorteio),
                    respostaRequisicaoVisualizarItensListaSorteio);

                return Request.CreateResponse(HttpStatusCode.OK,
                    respostaRequisicaoVisualizarItensListaSorteio.ItensListaSorteio);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }

        private DadosEntradaVisualizarItensListaSorteio ObterDadosEntradaVisualizarItensListaSorteio(long idListaSorteio)
        {
            return new DadosEntradaVisualizarItensListaSorteio {IdListaSorteio = idListaSorteio};
        }
        #endregion [ Get ]

        #region [ Patch ]
        [HttpPatch]
        [Route("itemlistasorteio")]
        public HttpResponseMessage PatchItemListaSorteio(Models.ItemListaSorteio itemListaSorteio)
        {
            //PATCH = Partial Update - Utilizado para atualizar parcialmente uma entidade
            //Basicamente só o que é informado é atualizado, o que não foi informado é desconsiderado uma atualização

            if (itemListaSorteio == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            return Request.CreateResponse(HttpStatusCode.OK, itemListaSorteio);
        }
        #endregion [ Patch ]

        #region [ Put ]

        [HttpPut]
        [Route("itemlistasorteio")]
        public HttpResponseMessage PutItemListaSorteio(Models.ListaSorteio itemListaSorteio)
        {
            //PUT = Update completo - Utilizado para atualizar completamente uma entidade
            //Todos os atributos são levados em consideração

            if (itemListaSorteio == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            return Request.CreateResponse(HttpStatusCode.OK, itemListaSorteio);
        }
        #endregion

        #region [ Delete ]

        [HttpDelete]
        [Route("itemlistasorteio/{id}")]
        public HttpResponseMessage DeleteItemListaSorteio(long id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            return Request.CreateResponse(HttpStatusCode.OK, "Item da lista de sorteio excluido.");
        }
        #endregion
    }
}
