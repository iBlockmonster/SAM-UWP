namespace SAM.DependencyContainer
{
    public interface IDependencyContainer
    {
        void AddDependency<T>(string id, T dependency) where T : class;
        T GetDependency<T>(string id) where T : class;
    }
}
