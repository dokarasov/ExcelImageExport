namespace ExcelImageExport.Presenter.Common
{
    public interface IContainer
    {
        void RegisterView<TService, TImplementation>() where TImplementation : TService;
        void Register<TService, TImplementation>() where TImplementation : TService;
        void Register<TService>();
        void RegisterInstance<T>(T instance);
        TService Resolve<TService>();
        bool IsRegistered<TService>();
    }
}