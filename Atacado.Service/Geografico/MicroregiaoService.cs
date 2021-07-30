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
    public class MicroregiaoService : IService<MicroregiaoPoco>
    {
        private MicroregiaoRepository repositorio;

        private MicroregiaoMap mapa;

        public MicroregiaoService(DbContext contexto)
        {
            this.repositorio = new MicroregiaoRepository(contexto);
            this.mapa = new MicroregiaoMap();
        }
        public IEnumerable<MicroregiaoPoco> ObterTodos()
        {
            List<Microregiao> lista = this.repositorio.Browse().ToList();
            List<MicroregiaoPoco> listaPoco = this.mapa.GetMapper.Map<List<MicroregiaoPoco>>(lista);

            return listaPoco;
        }

        public MicroregiaoPoco Obter(int id)
        {
            Microregiao mic = this.repositorio.Read(mc => mc.MicroregiaoID == id);
            MicroregiaoPoco novoPoco = this.mapa.GetMapper.Map<MicroregiaoPoco>(mic);

            return novoPoco;

        }

        public MicroregiaoPoco Incluir(MicroregiaoPoco poco)
        {
            Microregiao mic = this.mapa.GetMapper.Map<Microregiao>(poco);
            Microregiao adicionada = this.repositorio.Add(mic);
            MicroregiaoPoco novoPoco = this.mapa.GetMapper.Map<MicroregiaoPoco>(adicionada);

            return novoPoco;
        }

        public MicroregiaoPoco Atualizar(MicroregiaoPoco poco)
        {
            Microregiao mic = this.mapa.GetMapper.Map<Microregiao>(poco);
            Microregiao atualizada = this.repositorio.Edit(mic);
            MicroregiaoPoco novoPoco = this.mapa.GetMapper.Map<MicroregiaoPoco>(atualizada);

            return novoPoco;
        }

        public MicroregiaoPoco Excluir(int id)
        {
            Microregiao mic = this.repositorio.Read(mc => mc.MicroregiaoID == id);
            Microregiao excluida = this.repositorio.Delete(mic);
            MicroregiaoPoco novoPoco = this.mapa.GetMapper.Map<MicroregiaoPoco>(excluida);

            return novoPoco;
        }


    }
}
