using PhoneDealer.Models;
using PhoneDealer.Services;
using PhoneDealer.View;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace PhoneDealer
{
    public partial class App : Application
    {
        public static NavigationPage navigationPage;
        public App()
        {
            InitializeComponent();
            InicializarInterfaces();
            Permissoes();
            navigationPage = new NavigationPage(new PaginaListaTelefones());
            MainPage = navigationPage;
        }

        void InicializarInterfaces()
        {
            DependencyService.Register<IArmazenamentoService, ArmazenamentoService>();
            DependencyService.Register<ILeitorQrService, LeitorQrService>();
            //DependencyService.Register<IRepository<Emprestador>, Repository<Emprestador>>();
            //DependencyService.Register<IEmprestimoDaoRepository, Repository<ItemEmprestimoDao>>();
            //DependencyService.Register<IRepository<ItemEmprestimo>, Repository<ItemEmprestimo>>();

        }

        async void Permissoes()
        {
            var status = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Storage });
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
