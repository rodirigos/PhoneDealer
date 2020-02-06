using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneDealer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaAjuda : ContentPage
    {
        public PaginaAjuda()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.navigationPage.PopAsync();
        }
    }
}