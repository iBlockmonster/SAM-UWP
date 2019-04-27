using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAM.DependencyContainer
{
    public class DependencyContainer : IDependencyContainer
    {
        private object _lock = new object();
        private readonly Dictionary<string, object> _dependencies = new Dictionary<string, object>();

        public void InitComplete()
        {
            lock (_lock)
            {
                _state = DependencyContainerState.Initialized;
            }
            StateChanged?.Invoke(this, DependencyContainerState.Initialized);
        }

        private DependencyContainerState _state = DependencyContainerState.Initializing;
        public DependencyContainerState State
        {
            get
            {
                lock (_lock)
                {
                    return _state;
                }
            }
        }

        public event Action<IDependencyContainer, DependencyContainerState> StateChanged;

        public Task<DependencyContainerState> WaitForInitComplete()
        {
            lock(_lock)
            {
                if(_state == DependencyContainerState.Initialized)
                {
                    return Task.FromResult(_state);
                }
            }

            var completionSource = new TaskCompletionSource<DependencyContainerState>();

            Action<IDependencyContainer, DependencyContainerState> stateChangedHandler = null;
            stateChangedHandler = (IDependencyContainer source, DependencyContainerState state) =>
            {
                if (state != DependencyContainerState.Initializing)
                {
                    source.StateChanged -= stateChangedHandler;
                    completionSource.SetResult(state);
                }
            };
            this.StateChanged += stateChangedHandler;

            return completionSource.Task;
        }

        public void AddDependency<T>(T dependency, string id = null) where T : class
        {
            lock (_lock)
            {
                if (string.IsNullOrEmpty(id))
                {
                    id = typeof(T).Name;
                }
                if (_dependencies.ContainsKey(id))
                {
                    throw new Exception(string.Format("A dependency with id {0} already exists", id));
                }
                _dependencies.Add(id, dependency);
            }
        }

        public T GetDependency<T>(string id = null) where T : class
        {
            lock (_lock)
            {
                if (string.IsNullOrEmpty(id))
                {
                    id = typeof(T).Name;
                }
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
