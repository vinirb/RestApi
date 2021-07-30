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
    [RoutePrefix("atacado/geografico/municipio")]

    public class MunicipioController : BaseController
    {

        private MunicipioService servico;

        /// <summary>
        /// Chamado do controlador base
        /// </summary>

        public MunicipioController() : base()
        {
            this.servico = new MunicipioService(this.contexto);
        }
        /// <summary>
        /// Obter todos os registros da tabela.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{siglaUF}")]
        [ResponseType(typeof(List<MunicipioPoco>))]

        public HttpResponseMessage Get([FromUri] string siglaUF)
        {
            if (string.IsNullOrEmpty(siglaUF))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "SiglaUF deve ser informada.");
            }
            if(siglaUF.Length != 2)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "SiglaUF deve conter duas letras.");
            }
            try
            {
                MunicipioService msv = new MunicipioService(this.contexto);
                List<MunicipioPoco> lista = msv.ObterTodos().Where(mun => mun.SiglaUF == siglaUF).ToList();
                return Request.CreateResponse<List<MunicipioPoco>>(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter um registro, baseado na chave primaria.
        /// </summary>
        /// <param name="id">Chave primaria do registro</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(MunicipioPoco))]
        public HttpResponseMessage Get([FromUri] int id)
        {
            if(id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MunicipioPoco poco = this.servico.Obter(id);
                return Request.CreateResponse<MunicipioPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(MunicipioPoco))]
        public HttpResponseMessage Post([FromBody] MunicipioPoco poco)
        {
            try
            {
                this.servico.Incluir(poco);
                return Request.CreateResponse<MunicipioPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(MunicipioPoco))]
        public HttpResponseMessage Put([FromUri] int id, [FromBody] MunicipioPoco poco)
        {
            try
            {
                this.servico.Incluir(poco);
                return Request.CreateResponse<MunicipioPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(MunicipioPoco))]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            if(id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MunicipioPoco poco = this.servico.Excluir(id);
                return Request.CreateResponse<MunicipioPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }
        /// <summary>
        /// Dispose do Serviço.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            this.servico = null;
            base.Dispose(disposing);
        }
    }
}
