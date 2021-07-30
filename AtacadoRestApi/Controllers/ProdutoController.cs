using Atacado.POCO.Model;
using Atacado.Service.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AtacadoRestApi.Controllers
{
    /// <summary>
    /// Serviços de Categoria utilizando Design Patters.
    /// </summary>
    [RoutePrefix("atacado/estoque/produto")]
    public class ProdutoController : BaseController
    {

        private ProdutoService servico;
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public ProdutoController() : base()
        {
            this.servico = new ProdutoService(this.contexto);
        }
        /// <summary>
        /// Obter todos os Registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<ProdutoPoco>))]
        public HttpResponseMessage Get()
        {
            try
            {
                List<ProdutoPoco> lista = this.servico.ObterTodos().ToList();
                return Request.CreateResponse<List<ProdutoPoco>>(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        /// <summary>
        /// Obter registro por chave primaria.
        /// </summary>
        /// <param name="id">chave Primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(ProdutoPoco))]
        public HttpResponseMessage Get(int id)
        {
            if(id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                ProdutoPoco poco = this.servico.Obter(id);
                return Request.CreateResponse<ProdutoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        /// <summary>
        /// Incluir registro por chave primaria.
        /// </summary>
        /// <param name="id">chave Primaria.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(ProdutoPoco))]
        public HttpResponseMessage Post([FromBody]ProdutoPoco poco)
        {
            try
            {
                this.servico.Incluir(poco);
                return Request.CreateResponse<ProdutoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        /// <summary>
        /// Atualizar registro por chave primaria.
        /// </summary>
        /// <param name="id">chave Primaria.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(ProdutoPoco))]
        public HttpResponseMessage Put(int id, [FromBody]ProdutoPoco poco)
        {
          
            try
            {
                this.servico.Atualizar(poco);
                return Request.CreateResponse<ProdutoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        /// <summary>
        /// IDeletar registro por chave primaria.
        /// </summary>
        /// <param name="id">chave Primaria.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(ProdutoPoco))]
        public HttpResponseMessage Delete(int id)
        {
            if(id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                ProdutoPoco poco = this.servico.Excluir(id);
                return Request.CreateResponse<ProdutoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        /// <summary>
        /// Dispose do serviço.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            this.servico = null;
            base.Dispose(disposing);
        }
    }
}
