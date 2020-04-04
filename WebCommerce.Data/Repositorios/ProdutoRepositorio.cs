using Aula09.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Aula09.Dados
{
    public class ProdutoRepositorio : RepositorioBase<Produto>
    {
        public IEnumerable<Produto> ListarTodosComEstoqueZerado() {
            return Contexto
                .Produto
                //.Include(f => f.Marca)
                .Where(f => f.Estoque == 0);
        }

        public IEnumerable<Produto> ListarAtivos()
        {
            return Contexto
                .Produto
                .Include(f => f.Marca)
                .Include(f => f.Grupo)
                .ToList();
        }
    }
}
