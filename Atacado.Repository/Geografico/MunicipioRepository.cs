﻿using Atacado.DAL.Model;
using Atacado.Repository.Ancestor;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repository.Geografico
{
    public class MunicipioRepository : GenericRepository<DbContext,Municipio>
    {
        public MunicipioRepository(DbContext contexto) : base(contexto)
        { }
    }
}
