using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebCommerce.Dominio.Interfaces;

namespace WebCommerce.Dados
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class 
    {
        protected Contexto Contexto { get; }
        private DbSet<T> Entidade { get; }

        public RepositorioBase()
        {
            Contexto = new Contexto();
            Entidade = Contexto.Set<T>();
        }

        public virtual T ListarUm(params object[] keys)
        {
            return Entidade.Find(keys);
        }

        public virtual Task<List<T>> ListarTodosAsync()
        {
            return Contexto
                .Set<T>()
                .ToListAsync();
        }

        public virtual List<T> ListarTodos()
        {
            return Contexto
                .Set<T>()
                .ToList();
        }

        public void Adicionar(T entidade, bool saveChanges = true)
        {
            Entidade.Add(entidade);
            
            if (saveChanges)
                SaveChanges();
        }

        public void Remover(T entidade, bool saveChanges = true)
        {
            Entidade.Remove(entidade);
            
            if (saveChanges)
                SaveChanges();
        }

        public void Atualizar(T entidade, bool saveChanges = true)
        {
            Entidade.Update(entidade);
            
            if (saveChanges)
                SaveChanges();
        }

        public void SaveChanges()
        {
            Contexto.SaveChanges();
        }

    }
}
