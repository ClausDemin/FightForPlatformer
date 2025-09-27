using System.Collections.Generic;

namespace Assets.Codebase.GameLogic.Infrastructure.Repositories.Interface
{
    public interface IRepository<T>
    {
        public IEnumerable<T> Entities { get; }

        public void Add(T entity);

        public void Remove(T entity);
    }
}
