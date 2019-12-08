namespace Container
{
    public interface IContainerGenerator : IContainerRegistration
    {
        Container GenerateContainer();
    }
}
