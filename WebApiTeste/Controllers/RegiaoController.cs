using Atacado.DAL.Model;
using Atacado.POCO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApiTeste.Controllers
{
    /// <summary>
    /// Serviços API para Tabela Região.
    /// </summary>
    [RoutePrefix("WebApiTeste")]
    public class RegiaoController : ApiController
    {
        /// <summary>
        /// Obtém todos os registros da tabela.
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(List<RegiaoPoco>))]
        [Route("GET")]
        public List<RegiaoPoco> Get()
        {
            AtacadoModel contexto = new AtacadoModel();
            List<RegiaoPoco> regioesPoco = contexto.Regioes.Select(
                item => new RegiaoPoco()
                {
                    RegiaoID = item.RegiaoID,
                    Descricao = item.Descricao,
                    SiglaRegiao = item.SiglaRegiao,
                    DataInclusao = item.datainsert
                }).ToList();
            return regioesPoco;
        }
    }
}
