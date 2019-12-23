using PhoneDealer.Services;
using PhoneDealer.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneDealer
{
    public partial class App : Application
    {
        public static NavigationPage navigationPage;
        public App()
        {
            InitializeComponent();
            InicializarInterfaces();
            navigationPage = new NavigationPage(new PaginaListaTelefones());
            MainPage = navigationPage;
        }

        void InicializarInterfaces()
        {
            DependencyService.Register<IArmazenamentoService, ArmazenamentoService>();
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
