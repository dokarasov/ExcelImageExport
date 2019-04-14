using DryIoc;

namespace ExcelImageExport.Features
{
    public class DryIocAdapter : ExcelImageExport.Presenter.Common.IContainer
    {
        private readonly IContainer _container = new Container();

        public void RegisterView<TService, TImplementation>() where TImplementation : TService
        {
            _container.Register<TService, TImplementation>(setup: Setup.With(allowDisposableTransient: true));
        }

        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            _container.Register<TService, TImplementation>();
        }

        public void Register<TService>()
        {
            _container.Register<TService>();
        }

        public void RegisterInstance<T>(T instance)
        {
            _container.UseInstance(instance);
        }

        public TService Resolve<TService>()
        {
            return _container.Resolve<TService>();
        }

        public bool IsRegistered<TService>()
        {
            return _container.IsRegistered<TService>();
        }
    }
}