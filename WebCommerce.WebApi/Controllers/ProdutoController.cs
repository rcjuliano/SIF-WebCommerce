using System.Collections.Generic;
using System.Linq;
using Aula09.Comum.NotificationPattern;
using Aula09.Dominio;
using Aula09.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula09.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoServico produtoServico;

        public ProdutoController()
        {
            produtoServico = new ProdutoServico();
        }

        [HttpGet("ativos")]
        public IEnumerable<Produto> Ativos() => produtoServico.ListarAtivos();

        [HttpGet("sem-estoque")]
        public IEnumerable<Produto> ListarTodosComEstoqueZerado() {
            return produtoServico.ListarTodosComEstoqueZerado();
        }

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