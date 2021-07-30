using Atacado.DAL.Model;
using Atacado.Repository.Ancestor;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.Estoque
{
    public class SubCategoriaRepository : GenericRepository<DbContext,subcategoria>
    {
        public SubCategoriaRepository(DbContext contexto) : base(contexto)
        { }
    }
}
