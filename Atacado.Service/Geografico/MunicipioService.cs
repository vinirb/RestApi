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
    public class MunicipioService : IService<MunicipioPoco>
    {
        private MunicipioRepository repositorio;

        private MunicipioMap mapa;

        public MunicipioService(DbContext contexto)
        {
            this.repositorio = new MunicipioRepository(contexto);
            this.mapa = new MunicipioMap();
        }

        public IEnumerable<MunicipioPoco> ObterTodos()
        {
            List<Municipio> lista = this.repositorio.Browse().ToList();
            List<MunicipioPoco> listaPoco = this.mapa.GetMapper.Map<List<MunicipioPoco>>(lista);

            return listaPoco;
        }
        public MunicipioPoco Obter(int id)
        {
            Municipio dominio = this.repositorio.Read(mun => mun.UFID == id);
            MunicipioPoco novoPoco = this.mapa.GetMapper.Map<MunicipioPoco>(dominio);

            return novoPoco;
        }
        public MunicipioPoco Incluir(MunicipioPoco poco)
        {
            Municipio mun = this.mapa.GetMapper.Map<Municipio>(poco);
            Municipio nova = this.repositorio.Add(mun);
            MunicipioPoco novoPoco = this.mapa.GetMapper.Map<MunicipioPoco>(nova);

            return novoPoco;
        }

        public MunicipioPoco Atualizar(MunicipioPoco poco)
        {
            Municipio mun = this.mapa.GetMapper.Map<Municipio>(poco);
            Municipio alterada = this.repositorio.Edit(mun);
            MunicipioPoco novoPoco = this.mapa.GetMapper.Map<MunicipioPoco>(alterada);

            return novoPoco;
        }

        public MunicipioPoco Excluir(int id)
        {
            Municipio mun = this.repositorio.Read(mn => mn.UFID == id);
            Municipio excluida = this.repositorio.Delete(mun);
            MunicipioPoco novoPoco = this.mapa.GetMapper.Map<MunicipioPoco>(excluida);

            return novoPoco;
        }

    }
}
