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
    /// Serviços de Categoria utilizando Design Patters.
    /// </summary>
    [RoutePrefix("atacado/estoque/categoria")]
    public class CategoriaController : GenericBaseController<CategoriaPoco>
    {
       
        
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public CategoriaController() : base()
        {
            this.servico = new CategoriaService(this.contexto);
        }
        /// <summary>
        /// Obter todos os Registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<CategoriaPoco>))]
        public HttpResponseMessage Get()
        {
            try
            {
                List<CategoriaPoco> lista = this.servico.ObterTodos().ToList();
                return Request.CreateResponse<List<CategoriaPoco>>(HttpStatusCode.OK, lista);
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
        [ResponseType(typeof(CategoriaPoco))]
        public HttpResponseMessage Get([FromUri] int id)
        {
            if(id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                CategoriaPoco poco = this.servico.Obter(id);
                return Request.CreateResponse(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        /// <summary>
        /// Obter subcategorias por id.
        /// </summary>
        /// <param name="catid">chave primaria da categoria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{catid:int}/subcategorias")]
        [ResponseType(typeof(List<SubCategoriaPoco>))]
        public HttpResponseMessage GetSubcategoriaPorID([FromUri]int catid)
        {
            if(catid == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                SubCategoriaService srv = new SubCategoriaService(this.contexto);
                List<SubCategoriaPoco> subcatpoco = srv.ObterTodos().Where(sub => sub.CategoriaID == catid).ToList();

                return Request.CreateResponse<List<SubCategoriaPoco>>(HttpStatusCode.OK, subcatpoco);

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
        [ResponseType(typeof(CategoriaPoco))]
        public HttpResponseMessage Post([FromBody]CategoriaPoco poco)
        {
            try
            {
                this.servico.Incluir(poco);
                return Request.CreateResponse<CategoriaPoco>(HttpStatusCode.OK, poco);
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
        [Route("")]
        [ResponseType(typeof(CategoriaPoco))]
        public HttpResponseMessage Put([FromBody] CategoriaPoco poco)
        {
            try
            {
                this.servico.Atualizar(poco);
                return Request.CreateResponse<CategoriaPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(CategoriaPoco))]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            if(id == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                CategoriaPoco poco = this.servico.Excluir(id);
                return Request.CreateResponse<CategoriaPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


    }
}
