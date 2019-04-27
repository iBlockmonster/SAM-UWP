using System;
using System.Threading.Tasks;

namespace SAM.DependencyContainer
{
    public enum DependencyContainerState { Initializing, Initialized }

    public interface IDependencyContainer
    {
        DependencyContainerState State { get; }
        event Action<IDependencyContainer, DependencyContainerState> StateChanged;
        Task<DependencyContainerState> WaitForInitComplete();
        void AddDependency<T>(T dependency, string id = null) where T : class;
        T GetDependency<T>(string id = null) where T : class;
    }
}
