using Assets.Codebase.GameLogic.Infrastructure.Repositories.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Codebase.GameLogic.Infrastructure.Repositories
{
    public class MonoBehaviorRepository<T> : IRepository<T>
        where T : MonoBehaviour
    {
        private readonly HashSet<T> _entities = new();

        public IEnumerable<T> Entities => _entities;

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }
    }
}
