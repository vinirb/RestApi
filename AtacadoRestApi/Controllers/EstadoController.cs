using Atacado.DAL.Model;
using Atacado.POCO.Model;
using Atacado.Service.Geografico;
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
    /// Serviços para a tabela região
    /// </summary>
    [RoutePrefix("atacado/geografico/estado")]

    public class EstadosController : BaseController
    {
        private UnidadesFederacaoService servico;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public EstadosController() : base()
        {
            this.servico = new UnidadesFederacaoService(this.contexto);
        }
        /// <summary>
        /// Obter todos os registros da tabela.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<UnidadesFederacaoPoco>))]
        public HttpResponseMessage Get()
        {
            try
            {
                List<UnidadesFederacaoPoco> poco = this.servico.ObterTodos().ToList();
                return Request.CreateResponse<List<UnidadesFederacaoPoco>>(HttpStatusCode.OK, poco);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        
        /// <summary>
        /// Obter um registro, baseado na chave primaria.
        /// </summary>
        /// <param name="id">Chave primaria do registro</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(UnidadesFederacaoPoco))]
        public HttpResponseMessage Get(int id)
        {
            if(id==0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                UnidadesFederacaoPoco poco = this.servico.Obter(id);
                return Request.CreateResponse<UnidadesFederacaoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

        }
        /// <summary>
        /// Obter Municipios por estado.
        /// </summary>
        /// <param name="siglaUF">Sigla estado.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{siglaUF}/municipios")]
        [ResponseType(typeof(List<MunicipioPoco>))]
        public HttpResponseMessage GetMunicipiosPorSigla([FromUri] string siglaUF)
        {
            if (string.IsNullOrEmpty(siglaUF)){
                
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "SiglaUF deve ser informada.");
            }
            if (siglaUF.Length != 2)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "SiglaUF deve conter duas letras.");
            }
            try
            {
                string sigla = siglaUF.ToUpper();
                MunicipioService srv = new MunicipioService(this.contexto);
                List<MunicipioPoco> lista = srv.ObterTodos().Where(mun => mun.SiglaUF == siglaUF).ToList();

                return Request.CreateResponse<List<MunicipioPoco>>(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }

        [HttpGet]
        [Route("{ufid:int}/mesoregioes")]
        [ResponseType(typeof(UnidadesFederacaoPoco))]
        public HttpResponseMessage GetMesoreioesPorID([FromUri]int ufid)
        {
            if(ufid == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MesoregiaoService srv = new MesoregiaoService(this.contexto);
                List<MesoregiaoPoco> lista = srv.ObterTodos().Where(mes => mes.UFID == ufid).ToList();

                return Request.CreateResponse<List<MesoregiaoPoco>>(HttpStatusCode.OK, lista); 
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Criar registro na tabela
        /// </summary>
        /// <param name="poco">Objeto que sera incluido na tabela</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(UnidadesFederacaoPoco))]
        public HttpResponseMessage Post([FromBody] UnidadesFederacaoPoco poco)
        {
            try
            {
                this.servico.Incluir(poco);
                return Request.CreateResponse<UnidadesFederacaoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Atualizar registro na tabela
        /// </summary>
        /// <param name="id">Chave primaria do registro</param>
        /// <param name="poco">Objeto que sera atualizado</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        [ResponseType(typeof(UnidadesFederacaoPoco))]
        public HttpResponseMessage Put([FromUri]int id, [FromBody] UnidadesFederacaoPoco poco)
        {
           
            try
            {
                this.servico.Atualizar(poco);
                return Request.CreateResponse<UnidadesFederacaoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Excluir registro da tabela
        /// </summary>
        /// <param name="id">Chave primaria do registro</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(UnidadesFederacaoPoco))]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                UnidadesFederacaoPoco poco = this.servico.Excluir(id);
                return Request.CreateResponse<UnidadesFederacaoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
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
