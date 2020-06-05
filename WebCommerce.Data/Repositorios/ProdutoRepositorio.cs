using Aula09.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCommerce.Dominio.Interfaces;

namespace WebCommerce.Dados
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio 
    {
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