using Aula09.Comum.NotificationPattern;
using Aula09.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public NotificationResult Excluir(int idGrupo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Grupo> ListarAtivos()
        {
            throw new NotImplementedException();
        }

        public Task<List<Grupo>> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Grupo ListarUm(int idGrupo)
        {
            return _grupoRepositorio.ListarUm(idGrupo);
        }

        public NotificationResult Salvar(Grupo entidade)
        {
            throw new NotImplementedException();
        }
    }
}
