using Atacado.DAL.Model;
using Atacado.Mapping.Ancestor;
using Atacado.POCO.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Mapping.Geografico
{
    public class UnidadesFederacaoMap : BaseMapping
    {
        public UnidadesFederacaoMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UnidadesFederacao, UnidadesFederacaoPoco>()
                .ForMember(ufs => ufs.DataInclusao, map => map.MapFrom(ufsp => ufsp.datainsert));

                cfg.CreateMap<UnidadesFederacaoPoco, UnidadesFederacao>()
                .ForMember(ufs => ufs.datainsert, map => map.MapFrom(ufsp => ufsp.DataInclusao));

            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}
