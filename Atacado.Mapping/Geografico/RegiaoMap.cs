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
     public class RegiaoMap : BaseMapping
    {
        public RegiaoMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Regiao, RegiaoPoco>()
                .ForMember(reg => reg.DataInclusao , map => map.MapFrom(rgp => rgp.datainsert));

                cfg.CreateMap<RegiaoPoco, Regiao>()
                .ForMember(reg => reg.datainsert, map => map.MapFrom(rgp => rgp.DataInclusao));
            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}
