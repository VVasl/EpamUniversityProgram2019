namespace Container
{
    public interface IContainer
    {
        T Resolve<T>();
    }
}
