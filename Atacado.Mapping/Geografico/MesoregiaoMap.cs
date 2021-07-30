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
     public class MesoregiaoMap : BaseMapping
    {

        public MesoregiaoMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Mesoregiao, MesoregiaoPoco>()
                .ForMember(msr => msr.DataInclusao, map => map.MapFrom(msrp => msrp.datainsert));

                cfg.CreateMap<MesoregiaoPoco, Mesoregiao>()
                .ForMember(msr => msr.datainsert, map => map.MapFrom(msrp => msrp.DataInclusao));

            });

            this.GetMapper = configuration.CreateMapper();
        }

    }
}
