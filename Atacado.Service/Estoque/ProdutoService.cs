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
    public class ProdutoService : IService<ProdutoPoco>
    {
        private ProdutoRepository repositorio;

        private ProdutoMap mapa;

        public ProdutoService(DbContext contexto)
        {
            this.repositorio = new ProdutoRepository(contexto);
            this.mapa = new ProdutoMap();
        }

        public IEnumerable<ProdutoPoco> ObterTodos()
        {
            List<produto> lista = this.repositorio.Browse().ToList();
            List<ProdutoPoco> listaPoco = this.mapa.GetMapper.Map<List<ProdutoPoco>>(lista);
            
            return listaPoco;
        }

        public ProdutoPoco Obter(int id)
        {
            produto dominio = this.repositorio.Read(prod => prod.produtoid == id);
            ProdutoPoco novoPoco = this.mapa.GetMapper.Map<ProdutoPoco>(dominio);

            return novoPoco;
        }

         public ProdutoPoco Incluir(ProdutoPoco poco)
        {
            produto prod = this.mapa.GetMapper.Map<produto>(poco);
            produto adicionada = this.repositorio.Add(prod);
            ProdutoPoco novoPoco = this.mapa.GetMapper.Map<ProdutoPoco>(adicionada);

            return novoPoco;
        }

        public ProdutoPoco Atualizar(ProdutoPoco poco)
        {
            produto prod = this.mapa.GetMapper.Map<produto>(poco);
            produto atualizada = this.repositorio.Edit(prod);
            ProdutoPoco novoPoco = this.mapa.GetMapper.Map<ProdutoPoco>(atualizada);

                return novoPoco;
        }

        public ProdutoPoco Excluir(int id)
        {
            produto prod = this.repositorio.Read(pd => pd.produtoid == id);
            produto excluida = this.repositorio.Delete(prod);
            ProdutoPoco novoPoco = this.mapa.GetMapper.Map<ProdutoPoco>(excluida);

            return novoPoco;
        }

        
    }
}
