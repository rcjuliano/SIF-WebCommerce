using Aula09.Comum.NotificationPattern;
using Aula09.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebCommerce.Dominio.Interfaces
{
    public interface IGrupoServico
    {
        Grupo ListarUm(int idGrupo);

        IEnumerable<Grupo> ListarAtivos();
        Task<List<Grupo>> ListarTodos();

        NotificationResult Salvar(Grupo entidade);
        NotificationResult Excluir(int idGrupo);
    }
}
