using Atacado.DAL.Model;
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
    /// Serviços para a Tabela Região.
    /// </summary>
    [RoutePrefix("atacado/geografico/regioes")]
    public class RegiaoController : GenericBaseController<RegiaoPoco>
    {
        

        public RegiaoController() : base()
        {
            this.servico = new RegiaoService(this.contexto);
        }
        /// <summary>
        /// Obter todos os registros da tabela.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<RegiaoPoco>))]
        public HttpResponseMessage Get()
        {
            try
            {
                List<RegiaoPoco> lista = this.servico.ObterTodos().ToList();
                return Request.CreateResponse<List<RegiaoPoco>>(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="regiaoid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{regiaoid:int}/estado")]
        [ResponseType(typeof(List<UnidadesFederacaoPoco>))]
        public HttpResponseMessage GetEstadoPorID(int regiaoid)
        {
            if(regiaoid == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                UnidadesFederacaoService srv = new UnidadesFederacaoService(this.contexto);
                List<UnidadesFederacaoPoco> lista = srv.ObterTodos().Where(reg => reg.RegiaoID == regiaoid).ToList();
                return Request.CreateResponse<List<UnidadesFederacaoPoco>>(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }



        /// <summary>
        /// Obter um registro, baseado na chave primária.
        /// </summary>
        /// <param name="id">Chave Primária do registro.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(RegiaoPoco))]
        public HttpResponseMessage Get([FromUri] int id)
        {
            if(id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
               RegiaoPoco poco = this.servico.Obter(id);
                return Request.CreateResponse<RegiaoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }



        /// <summary>
        /// Criar um registro na tabela.
        /// </summary>
        /// <param name="poco">Objeto que será incluído na tabela.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(RegiaoPoco))]
        public HttpResponseMessage Post([FromBody] RegiaoPoco poco)
        {
            try
            {
                this.servico.Incluir(poco);
                return Request.CreateResponse<RegiaoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        /// <summary>
        /// Atualizar um registro na tabela.
        /// </summary>
        /// <param name="id">Chave primária do registro.</param>
        /// <param name="poco">Objeto que será atualizado.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(RegiaoPoco))]
        public HttpResponseMessage Put([FromUri] int id, [FromBody] RegiaoPoco poco)
        {
            try
            {
                this.servico.Atualizar(poco);
                return Request.CreateResponse<RegiaoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
            
        }



        /// <summary>
        /// Excluir um registro da tabela.
        /// </summary>
        /// <param name="id">Chave primária do registro.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(RegiaoPoco))]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            
            try
            {
                RegiaoPoco poco = this.servico.Excluir(id);
                return Request.CreateResponse<RegiaoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        
    }
}
