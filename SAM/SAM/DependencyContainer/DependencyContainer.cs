using System;
using System.Collections.Generic;

namespace SAM.DependencyContainer
{
    public class DependencyContainer : IDependencyContainer
    {
        private object _lock = new object();
        private readonly Dictionary<string, object> _dependencies = new Dictionary<string, object>();

        public void AddDependency<T>(string id, T dependency) where T : class
        {
            lock (_lock)
            {
                if (_dependencies.ContainsKey(id))
                {
                    throw new Exception(string.Format("A dependency with id {0} already exists", id));
                }
                _dependencies.Add(id, dependency);
            }
        }

        public T GetDependency<T>(string id) where T : class
        {
            lock (_lock)
            {
                if (!_dependencies.ContainsKey(id))
                {
                    return null;
                }
                var d = _dependencies[id];
                if (d is T retVal)
                {
                    return retVal;
                }
                else
                {
                    throw new Exception(string.Format("A dependency with id {0} exists but is of type {1} not {2}", id, d.GetType().ToString(), typeof(T).ToString()));
                }
            }
        }
    }
}
