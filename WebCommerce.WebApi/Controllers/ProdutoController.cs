using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula09.Comum.NotificationPattern;
using Aula09.Dominio;
using Aula09.Servico;
using Microsoft.AspNetCore.Mvc;

namespace WebCommerce.WebApi.Controllers
{
    /// <summary>
    /// Operações relacionadas ao processo de CRUD dos produtos
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoServico produtoServico;

        /// <summary>
        /// Método Construtor do Controller Produto
        /// </summary>
        public ProdutoController()
        {
            produtoServico = new ProdutoServico();
        }

        /// <summary>
        /// Listar Todos os Produtos
        /// </summary>
        /// <returns>
        /// Retorna uma lista de produtos do tipo "Produto"
        /// </returns>
        [HttpGet("todos")]
        public Task<List<Produto>> Todos() {
             return produtoServico.ListarTodos();
        }

        /// <summary>
        /// Lista de Todos os Produtos Ativos
        /// </summary>
        /// <returns></returns>
        [HttpGet("ativos")]
        
        public IEnumerable<Produto> Ativos() => produtoServico.ListarAtivos().Where(f => f.DataCadastro == DateTime.Now);

        [HttpGet("sem-estoque")]
        public IEnumerable<Produto> ListarTodosComEstoqueZerado() {
            return produtoServico.ListarTodosComEstoqueZerado();
        }

        /// <summary>
        /// Evento responsável pelo cadastro de Produtos
        /// </summary>
        /// <param name="entidade">
        ///     
        /// </param>
        /// <remarks>
        ///     {
        ///        "idProduto": 1,
        ///        "Nome": "Item1",
        ///        "PrecoCusto": 10.0
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPost("salvar")]
        public NotificationResult Salvar(Produto entidade)
        {
            return produtoServico.Salvar(entidade);
        }

        [HttpDelete("excluir")]
        public NotificationResult Excluir(int idProduto)
        {
            return produtoServico.Excluir(idProduto);
        }

    }
}