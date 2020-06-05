using Aula09.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using WebCommerce.Dominio.Interfaces;

namespace WebCommerce.Servico
{
    public class GrupoServico : IGrupoServico
    {
        private readonly IGrupoRepositorio _grupoRepositorio;

        public GrupoServico(IGrupoRepositorio grupoRepositorio)
        {
            _grupoRepositorio = grupoRepositorio;
        }

        public Grupo ListarUm(int idGrupo)
        {
            return _grupoRepositorio.ListarUm(idGrupo);
        }

    }
}
