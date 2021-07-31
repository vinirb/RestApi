using Atacado.POCO.Model;
using Atacado.Service.Geografico;
using AtacadoRestApi.Ancestor;
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
    [RoutePrefix("atacado/geografico/microregiao")]
    public class MicroregiaoController : GenericBaseController<MicroregiaoPoco>
    {
        
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public MicroregiaoController() : base()
        {
            this.servico = new MicroregiaoService(this.contexto);
        }
        /// <summary>
        /// Obter todos os Registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<MicroregiaoPoco>))]
        public HttpResponseMessage Get()
        {
            try
            {
                List<MicroregiaoPoco> lista = this.servico.ObterTodos().ToList();
                return Request.CreateResponse<List<MicroregiaoPoco>>(HttpStatusCode.OK, lista);
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
        [ResponseType(typeof(MicroregiaoPoco))]
        public HttpResponseMessage Get(int id)
        {
            if(id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MicroregiaoPoco poco = this.servico.Obter(id);
                return Request.CreateResponse<MicroregiaoPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(MicroregiaoPoco))]
        public HttpResponseMessage Post([FromBody]MicroregiaoPoco poco)
        {
            try
            {
                this.servico.Incluir(poco);
                return Request.CreateResponse<MicroregiaoPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(MicroregiaoPoco))]
        public HttpResponseMessage Put(int id, [FromBody]MicroregiaoPoco poco)
        {
            try
            {
                this.servico.Atualizar(poco);
                return Request.CreateResponse<MicroregiaoPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(MicroregiaoPoco))]
        public HttpResponseMessage Delete(int id)
        {
            if(id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MicroregiaoPoco poco = this.servico.Excluir(id);
                return Request.CreateResponse<MicroregiaoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        
    }
}
