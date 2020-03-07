using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTCC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageApp : ContentPage
    {
        public MainPageApp()
        {
            InitializeComponent();
        }
        public void HomeClick(object sender, EventArgs e)
        {
            var page = new HomePage();
            MainView.Content = page.Content;

        }

        public async void GoogleClick(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://scholar.google.com/", BrowserLaunchMode.SystemPreferred);
        }

        public void NovaNotaClick(object sender, EventArgs e)
        {
            var page = new NovaNota();
            MainView.Content = page.Content;

        }

        public void SearchClick(object sender, EventArgs e)
        {
            var page = new Buscar();
            MainView.Content = page.Content;
        }

        private void ConfigClick(object sender, EventArgs e)
        {
            var page = new Configuracoes();
            MainView.Content = page.Content;
        }
    }
}