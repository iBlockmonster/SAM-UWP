using System;

namespace SAM.DependencyContainer
{
    public enum DependencyContainerState { Initializing, Initialized }

    public interface IDependencyContainer
    {
        DependencyContainerState State { get; }
        event Action<IDependencyContainer, DependencyContainerState> StateChanged;
        void AddDependency<T>(T dependency, string id = null) where T : class;
        T GetDependency<T>(string id = null) where T : class;
    }
}
