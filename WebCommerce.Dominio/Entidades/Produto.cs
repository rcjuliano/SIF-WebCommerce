using Aula09.Comum;
using System;

namespace Aula09.Dominio
{
    public class Produto
    {

        public Produto()
        {
            DataCadastro = DateTime.Now;
        }

        public int idProduto { get; set; }
        public int? idGrupo { get; set; }
        public int idMarca { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoCusto { get; set; }
        public int Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        public Grupo Grupo { get; set; }

        public Marca Marca { get; set; }

        public bool Caro {
            get {
                return MatematicaUtil.Divisao(PrecoCusto, PrecoVenda) >= 0.8m;
            }
        }

        public static string Cabecalho()
        {
            return "ID\t\tDescrição\t\tPreço de Venda\t\tPreço de custo\t\tEstoque";
        }

        public override string ToString()
        {
            return $"{idProduto}\t\t{Descricao}\t\t{PrecoVenda:C2}\t\t{PrecoCusto:C2}\t\t{Estoque}";
        }

        public override bool Equals(object obj)
        {
            var ent = obj as Produto;

            if (ent == null)
                return false;

            return ent.idProduto == idProduto && ent.DataCadastro == DataCadastro;
        }

        public override int GetHashCode()
        {
            return idProduto.GetHashCode();
        }

    }
}
