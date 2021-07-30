using Atacado.DAL.Model;
using Atacado.Mapping.Ancestor;
using Atacado.POCO.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Mapping.Estoque
{
    public class SubCategoriaMap : BaseMapping
    {
        public SubCategoriaMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<subcategoria, SubCategoriaPoco>()
                .ForMember(dst => dst.CategoriaID, map => map.MapFrom(src => src.catid))
                .ForMember(dst => dst.SubCategoriaID, map => map.MapFrom(src => src.subcatid))
                .ForMember(dst => dst.DataInclusao, map => map.MapFrom(src => src.datainsert));

            cfg.CreateMap<SubCategoriaPoco, subcategoria>()
            .ForMember(dst => dst.catid, map => map.MapFrom(src => src.CategoriaID))
            .ForMember(dst => dst.subcatid, map => map.MapFrom(src => src.SubCategoriaID))
            .ForMember(dst => dst.datainsert, map => map.MapFrom(src => src.DataInclusao));

            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}
