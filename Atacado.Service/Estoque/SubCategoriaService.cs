using Atacado.DAL.Model;
using Atacado.Mapping.Estoque;
using Atacado.POCO.Model;
using Atacado.Repository.Estoque;
using Atacado.Service.Ancestor;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Estoque
{
    public class SubCategoriaService : IService<SubCategoriaPoco>
    {
        private SubCategoriaRepository repositorio;

        private SubCategoriaMap mapa;

        public SubCategoriaService(DbContext contexto)
        {
            this.repositorio = new SubCategoriaRepository(contexto);
            this.mapa = new SubCategoriaMap();
        }

        public IEnumerable<SubCategoriaPoco> ObterTodos()
        {
            List<subcategoria> lista  = this.repositorio.Browse().ToList();
            List<SubCategoriaPoco> listaPoco = this.mapa.GetMapper.Map<List<SubCategoriaPoco>>(lista);

            return listaPoco;
        }

        public SubCategoriaPoco Obter(int id)
        {
            subcategoria dominio = this.repositorio.Read(sub => sub.subcatid == id);
            SubCategoriaPoco poco = this.mapa.GetMapper.Map<SubCategoriaPoco>(dominio);

            return poco;
        }

        public SubCategoriaPoco Atualizar(SubCategoriaPoco poco)
        {
            subcategoria subcat = this.mapa.GetMapper.Map<subcategoria>(poco);
            subcategoria atualizada = this.repositorio.Edit(subcat);
            SubCategoriaPoco NovoPoco = this.mapa.GetMapper.Map<SubCategoriaPoco>(atualizada);

            return NovoPoco;
        }

       
        public SubCategoriaPoco Incluir(SubCategoriaPoco poco)
        {
            subcategoria subcat = this.mapa.GetMapper.Map<subcategoria>(poco);
            subcategoria adicionada = this.repositorio.Add(subcat);
            SubCategoriaPoco NovoPoco = this.mapa.GetMapper.Map<SubCategoriaPoco>(adicionada);

            return NovoPoco;
        }

        public SubCategoriaPoco Excluir(int id)
        {
            subcategoria subcat = this.repositorio.Read(sub => sub.catid == id);
            subcategoria excluida = this.repositorio.Delete(subcat);
            SubCategoriaPoco NovoPoco = this.mapa.GetMapper.Map<SubCategoriaPoco>(excluida);

            return NovoPoco;
        }


    }
}
