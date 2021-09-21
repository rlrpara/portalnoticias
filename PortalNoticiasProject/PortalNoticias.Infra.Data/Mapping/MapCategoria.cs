﻿using PortalNoticias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalNoticias.Infra.Data.Mapping
{
    public class MapCategoria : DommelEntityMap<Categoria>
    {
        public MapCategoria()
        {
            ToTable("CATEGORIA");
            Map(x => x.Codigo).ToColumn("ID").IsKey();
            Map(x => x.CodigoMunicipio).ToColumn("DS_CATEGORIA");
            Map(x => x.Nome).ToColumn("DS_NOME");
            Map(x => x.Removido).ToColumn("REMOVIDO");
            Map(x => x.DataCadastro).ToColumn("DATA_CADASTRO");
            Map(x => x.DataAtualizacao).ToColumn("DATA_ATUALIZACAO");
        }
    }
}
