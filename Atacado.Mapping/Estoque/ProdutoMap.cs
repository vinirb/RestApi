﻿using Atacado.DAL.Model;
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
    public class ProdutoMap : BaseMapping
    {
        public ProdutoMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<produto, ProdutoPoco>()
                .ForMember(dst => dst.ProdutoID, map => map.MapFrom(src => src.produtoid))
                .ForMember(dst => dst.SubCategoriaID, map => map.MapFrom(src => src.subcatid))
                .ForMember(dst => dst.DataInclusao, map => map.MapFrom(src => src.datainsert));


                cfg.CreateMap<ProdutoPoco, produto>()
                .ForMember(dst => dst.produtoid, map => map.MapFrom(src => src.ProdutoID))
                .ForMember(dst => dst.subcatid, map => map.MapFrom(src => src.SubCategoriaID))
                .ForMember(dst => dst.datainsert, map => map.MapFrom(src => src.DataInclusao));

            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}
