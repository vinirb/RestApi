using Atacado.POCO.Model;
using Atacado.Service.Estoque;
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
    /// Servicos de SubCategoria usando Design Patters
    /// </summary>
    [RoutePrefix ("atacado/estoque/subcategoria")]
    public class SubCategoriaController : GenericBaseController<SubCategoriaPoco>
    {

        
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public SubCategoriaController() : base()
        {
            this.servico = new SubCategoriaService(this.contexto);
        }
        /// <summary>
        /// Obter todos os Registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<SubCategoriaPoco>))]
        public HttpResponseMessage Get()
        {
            try
            {
                List<SubCategoriaPoco> lista = this.servico.ObterTodos().ToList();
                return Request.CreateResponse<List<SubCategoriaPoco>>(HttpStatusCode.OK, lista);
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
        [HttpGet][Route("{id:int}")]
        [ResponseType(typeof(SubCategoriaPoco))]
        public HttpResponseMessage Get([FromUri]int id)
        {
            if(id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                SubCategoriaPoco poco = this.servico.Obter(id);
                return Request.CreateResponse<SubCategoriaPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(SubCategoriaPoco))]
        public HttpResponseMessage Post([FromBody]SubCategoriaPoco poco)
        {
            try
            {
                this.servico.Incluir(poco);
                return Request.CreateResponse<SubCategoriaPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(SubCategoriaPoco))]
        public HttpResponseMessage Put([FromUri]int id, [FromBody]SubCategoriaPoco poco)
        {   
           
            try
            {
                this.servico.Atualizar(poco);
                return Request.CreateResponse<SubCategoriaPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(SubCategoriaPoco))]
        public HttpResponseMessage Delete([FromUri]int id)
        {
            if(id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                SubCategoriaPoco poco = this.servico.Excluir(id);
                return Request.CreateResponse<SubCategoriaPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
       
    }
}
