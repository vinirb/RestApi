using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.POCO.Model
{
    public class SubCategoriaPoco
    {
        public int SubCategoriaID { get; set; }

        public int CategoriaID { get; set; }

        public string Descricao { get; set; }

        public DateTime DataInclusao { get; set; }
    }
}
