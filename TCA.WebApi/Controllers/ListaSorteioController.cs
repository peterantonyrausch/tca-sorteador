using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TCA.DAL.EntityFramework.SQL.Repositorios.UnidadeDeTrabalho;
using TCA.Nucleo.CasosDeUso.Base;
using TCA.Nucleo.CasosDeUso.ListaSorteio.Acoes;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosEntrada;
using TCA.Nucleo.CasosDeUso.ListaSorteio.DadosSaida;
using TCA.Nucleo.Entidades.ListaSorteio;

namespace TCA.WebApi.Controllers
{
    [RoutePrefix("api/v1")]
    public class ListaSorteioController : ApiController, RespostaRequisicao<DadosSaidaCadastrarListaSorteio>, RespostaRequisicao<DadosSaidaVisualizarListasSorteio>
    {
        #region [ Post ]
        private long idListaSorteioCadastrada;

        // POST api/ListaSorteio
        [HttpPost]
        [Route("listasorteio")]
        public HttpResponseMessage PostListaSorteio(Models.ListaSorteio listaSorteio)
        {
            //EXEMPLO POST: http://localhost:2400/api/v1/listasorteio
            //HEADERS: Content-Type : application/json

            if (listaSorteio == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            try
            {
                var repositorioListaSorteio = Utils.ObterUnidadeTrabalhoSorteador().RepositorioListaSorteio;
                var cadastrarLista = new CadastrarListaSorteio(repositorioListaSorteio);

                cadastrarLista.Executar(ObterDadosEntradaCadastrarListaSorteio(listaSorteio), this);

                listaSorteio.Id = idListaSorteioCadastrada;

                return Request.CreateResponse(HttpStatusCode.Created, listaSorteio);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }

        private DadosEntradaCadastrarListaSorteio ObterDadosEntradaCadastrarListaSorteio(Models.ListaSorteio listaSorteio)
        {
            return new DadosEntradaCadastrarListaSorteio { Nome = listaSorteio.Nome };
        }

        public void ProcessarResposta(DadosSaidaCadastrarListaSorteio dadosSaida)
        {
            idListaSorteioCadastrada = dadosSaida.IdListaSorteio;
        }
        #endregion [ Post ]

        #region [ Get ]
        [Route("listasorteio/{id}")]
        public HttpResponseMessage GetListaSorteio(long id)
        {
            //EXEMPLO GET: http://localhost:2400/api/v1/listasorteio/1

            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                var repositorioListaSorteio = Utils.ObterUnidadeTrabalhoSorteador().RepositorioListaSorteio;
                var visualizarListas = new VisualizarListasSorteio(repositorioListaSorteio);

                visualizarListas.Executar(this);

                return Request.CreateResponse(HttpStatusCode.OK, ProcessarRetornoGetListaSorteio(id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }

        [Route("listassorteio")]
        public HttpResponseMessage GetListasSorteio()
        {
            //EXEMPLO GET: http://localhost:2400/api/v1/listassorteio/

            try
            {
                var repositorioListaSorteio = Utils.ObterUnidadeTrabalhoSorteador().RepositorioListaSorteio;
                var visualizarListas = new VisualizarListasSorteio(repositorioListaSorteio);

                visualizarListas.Executar(this);

                return Request.CreateResponse(HttpStatusCode.OK, ProcessarRetornoGetListasSorteio());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }

        private List<ListaSorteio> ProcessarRetornoGetListasSorteio()
        {
            return listasSorteioConsultada.ToList();
        }

        private Models.ListaSorteio ProcessarRetornoGetListaSorteio(long id)
        {
            var result = new Models.ListaSorteio();

            if (listasSorteioConsultada != null &&
                listasSorteioConsultada.Any(listaSorteio => listaSorteio.Id == id))
                result = new Models.ListaSorteio(listasSorteioConsultada.FirstOrDefault(listaSorteio => listaSorteio.Id == id));

            return result;
        }

        private IEnumerable<ListaSorteio> listasSorteioConsultada;

        public void ProcessarResposta(DadosSaidaVisualizarListasSorteio dadosSaida)
        {
            listasSorteioConsultada = dadosSaida.ListasSorteio;
        }
        #endregion [ Get ]

        #region [ Patch ]
        [HttpPatch]
        [Route("listasorteio")]
        public HttpResponseMessage PatchListaSorteio(Models.ListaSorteio listaSorteio)
        {
            //PATCH = Partial Update - Utilizado para atualizar parcialmente uma entidade
            //Basicamente só o que é informado é atualizado, o que não foi informado é desconsiderado uma atualização

            if (listaSorteio == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            return Request.CreateResponse(HttpStatusCode.OK, listaSorteio);
        }
        #endregion [ Patch ]

        #region [ Put ]

        [HttpPut]
        [Route("listasorteio")]
        public HttpResponseMessage PutListaSorteio(Models.ListaSorteio listaSorteio)
        {
            //PUT = Update completo - Utilizado para atualizar completamente uma entidade
            //Todos os atributos são levados em consideração

            if (listaSorteio == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            return Request.CreateResponse(HttpStatusCode.OK, listaSorteio);
        }
        #endregion

        #region [ Delete ]

        [HttpDelete]
        [Route("listasorteio/{id}")]
        public HttpResponseMessage DeleteListaSorteio(long id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            return Request.CreateResponse(HttpStatusCode.OK, "Lista de sorteio excluida.");
        }
        #endregion
    }
}
