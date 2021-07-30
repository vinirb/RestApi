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
     public class MicroregiaoMap : BaseMapping
    {
        public MicroregiaoMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Microregiao, MicroregiaoPoco>()
                .ForMember(mcr => mcr.DataInclusao, map => map.MapFrom(mcrp => mcrp.datainsert));

                cfg.CreateMap<MicroregiaoPoco, Microregiao>()
                .ForMember(mcr => mcr.datainsert, map => map.MapFrom(mcrp => mcrp.DataInclusao));
            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}
