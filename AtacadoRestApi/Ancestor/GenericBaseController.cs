using Atacado.DAL.Model;
using Atacado.Service.Ancestor;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AtacadoRestApi.Ancestor
{   
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract  class GenericBaseController<T> : ApiController
        where T : class 
    {
        /// <summary>
        /// 
        /// </summary>
        protected DbContext contexto;

        /// <summary>
        /// 
        /// </summary>
        protected IService<T> servico;

        /// <summary>
        /// 
        /// </summary>
        public GenericBaseController()
        {
            this.contexto = new AtacadoModel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            this.contexto.Dispose();
            base.Dispose(disposing);
        }
    }
}