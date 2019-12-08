namespace Container
{
    public interface IContainerRegistration
    {
        bool Register<Interface, Implementation>();
        bool Register<Interface, Implementation>(ServiceLifetime lifeStyle);
    }
}
