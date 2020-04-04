using System.Collections.Generic;
using System.Linq;

namespace Aula09.Dominio
{
    public class Marca
    {
        public int idMarca { get; set; }
        public string Descricao { get; set; }

        public bool Validar()
        {
            var listaDeMarcasHabilitadas = new[] { "Adidas", "Nike", "Puma" };
            return listaDeMarcasHabilitadas.Contains(Descricao);
        }
    }
}
