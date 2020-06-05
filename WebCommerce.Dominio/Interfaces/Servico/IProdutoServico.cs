using Aula09.Comum.NotificationPattern;
using Aula09.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebCommerce.Dominio.Interfaces
{
    public interface IProdutoServico
    {
        Produto ListarUm(int idProduto);

        IEnumerable<Produto> ListarAtivos();
        Task<List<Produto>> ListarTodos();

        NotificationResult Salvar(Produto entidade);
        NotificationResult Excluir(int idProduto);
    }
}
