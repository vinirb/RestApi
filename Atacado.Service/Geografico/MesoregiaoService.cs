using Atacado.DAL.Model;
using Atacado.Mapping.Geografico;
using Atacado.POCO.Model;
using Atacado.Repository.Geografico;
using Atacado.Service.Ancestor;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Geografico
{
    public class MesoregiaoService : GenericService<DbContext, Mesoregiao, CategoriaPoco>, IService<MesoregiaoPoco>
    {
       

        public MesoregiaoService(DbContext contexto)
        {
            this.repositorio = new MesoregiaoRepository(contexto);
            this.mapa = new MesoregiaoMap();
        }

        public IEnumerable<MesoregiaoPoco> ObterTodos()
        {
            List<Mesoregiao> lista = this.repositorio.Browse().ToList();
            List<MesoregiaoPoco> listaPoco = this.mapa.GetMapper.Map<List<MesoregiaoPoco>>(lista);

            return listaPoco;
        }

        public MesoregiaoPoco Obter(int id)
        {
            Mesoregiao mes = this.repositorio.Read(ms => ms.MesoregiaoID == id);
            MesoregiaoPoco novoPoco = this.mapa.GetMapper.Map<MesoregiaoPoco>(mes);

            return novoPoco;
        }

        public MesoregiaoPoco Incluir(MesoregiaoPoco poco)
        {
            Mesoregiao mes = this.mapa.GetMapper.Map<Mesoregiao>(poco);
            Mesoregiao adicionada = this.repositorio.Add(mes);
            MesoregiaoPoco novoPoco = this.mapa.GetMapper.Map<MesoregiaoPoco>(adicionada);

            return novoPoco;
        }


        public MesoregiaoPoco Atualizar(MesoregiaoPoco poco)
        {
            Mesoregiao mes = this.mapa.GetMapper.Map<Mesoregiao>(poco);
            Mesoregiao atualizada = this.repositorio.Edit(mes);
            MesoregiaoPoco  novoPoco = this.mapa.GetMapper.Map<MesoregiaoPoco>(atualizada);

            return novoPoco;
        }

        public MesoregiaoPoco Excluir(int id)
        {
            Mesoregiao mes = this.repositorio.Read(ms => ms.MesoregiaoID == id);
            Mesoregiao excluida = this.repositorio.Delete(mes);
            MesoregiaoPoco novoPoco = this.mapa.GetMapper.Map<MesoregiaoPoco>(excluida);

            return novoPoco;
        }
       
    }
}
