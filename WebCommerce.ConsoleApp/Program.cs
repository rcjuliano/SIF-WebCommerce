using Aula09.Dados;
using Aula09.Dominio;
using Aula09.Servico;
using System;
using System.Linq;

namespace Aula09.ConsoleApp
{
    class Program
    {
        private static ProdutoServico _produtoServico = new ProdutoServico();

        static void Main(string[] args)
        {
            Console.WriteLine("Imprimindo Produtos");
            Console.WriteLine("");

            var produtos = _produtoServico.ListarTodos();

            Console.WriteLine(Produto.Cabecalho());
            foreach (Produto item in produtos) 
                Console.WriteLine(item);


            var produto = new Produto();
            Console.WriteLine(produto.DataCadastro);

            var produtoResultado = _produtoServico.Salvar(produto);

            Console.WriteLine(produtoResultado.Result.DataCadastro);  
            Console.WriteLine(produtoResultado.Message);

            Console.WriteLine("Impressão finalizada");
            Console.ReadKey();
        }
    }
}
