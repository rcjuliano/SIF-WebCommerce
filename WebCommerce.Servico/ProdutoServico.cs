
using Aula09.Comum.NotificationPattern;
using Aula09.Dominio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCommerce.Dominio.Interfaces;

namespace Aula09.Servico
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IEnumerable<Produto> ListarAtivos()
        {
            return _produtoRepositorio.ListarAtivos();
        }

        public Produto ListarUm(int idProduto)
        {
            return _produtoRepositorio.ListarUm(idProduto);
        }

        public NotificationResult Salvar(Produto entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                entidade.DataCadastro = DateTime.Now;

                if (entidade.Estoque < 0) 
                    notificationResult.Add(new NotificationError("Qtde. de produtos no Estoque inválido.", NotificationErrorType.USER));

                if (entidade.PrecoVenda < 0)
                    notificationResult.Add(new NotificationError("Preço de Venda inválido."));

                if (entidade.PrecoCusto < 0)
                    notificationResult.Add(new NotificationError("Preço de Custo inválido."));

                if (notificationResult.IsValid) {

                    if (entidade.idProduto == 0)
                    //if (ListarUm(entidade.idProduto, entidade.idGrupo) == null)
                        _produtoRepositorio.Adicionar(entidade);
                    else
                    {
                        _produtoRepositorio.Atualizar(entidade);
                    }

                    notificationResult.Add("Produto cadastrado com sucesso.");
                }

                notificationResult.Result = entidade;
                
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError("Erro ao executar o método ProdutoServico.Salvar: " + ex.Message));
            }
        }

        

        public NotificationResult Excluir(int idProduto)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (idProduto == 0)
                    return notificationResult.Add(new NotificationError("Código do Produto Inválido"));

                Produto entidade = ListarUm(idProduto);

                if (entidade == null)
                    return notificationResult.Add(new NotificationError("Produto não Encontrado."));

                //var verificarVendaExecutada = vendaServico.VerificarVenda(entidade.idProduto);
                var verificarVendaExecutada = false;

                if (verificarVendaExecutada)
                    notificationResult.Add(new NotificationError("Não é possível remover um produto que já possui venda realizada.", NotificationErrorType.BUSINESS_RULES));

                if (notificationResult.IsValid) {
                    _produtoRepositorio.Remover(entidade);
                    notificationResult.Add("Produto excluído com sucesso.");
                }

                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public Task<List<Produto>> ListarTodos() {
            return _produtoRepositorio.ListarTodosAsync();
        }
    }
}
