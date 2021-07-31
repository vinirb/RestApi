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
    [RoutePrefix("atacado/geografico/mesoregiao")]
    public class MesoregiaoController : GenericBaseController<MesoregiaoPoco>
    {
       
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public MesoregiaoController()
        {
            this.servico = new MesoregiaoService(this.contexto);
        }
        /// <summary>
        /// Obter todos os Registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<MesoregiaoPoco>))]
        public HttpResponseMessage Get()
        {
            try
            {
                List<MesoregiaoPoco> lista = this.servico.ObterTodos().ToList();
                return Request.CreateResponse<List<MesoregiaoPoco>>(HttpStatusCode.OK, lista);
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
        [ResponseType(typeof(MesoregiaoPoco))]
        public HttpResponseMessage Get(int id)
        {
            if(id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MesoregiaoPoco poco = this.servico.Obter(id);
                return Request.CreateResponse<MesoregiaoPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(MesoregiaoPoco))]
        public HttpResponseMessage Post([FromBody]MesoregiaoPoco poco)
        {
            try
            {
                this.servico.Incluir(poco);
                return Request.CreateResponse<MesoregiaoPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(MesoregiaoPoco))]
        public HttpResponseMessage Put(int id, [FromBody]MesoregiaoPoco poco)
        {
            try
            {
                this.servico.Atualizar(poco);
                return Request.CreateResponse<MesoregiaoPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(MesoregiaoPoco))]
        public HttpResponseMessage Delete(int id)
        {
            if(id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MesoregiaoPoco poco = this.servico.Excluir(id);
                return Request.CreateResponse<MesoregiaoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        
    }
}
