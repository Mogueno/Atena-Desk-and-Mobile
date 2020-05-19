using MobileTCC.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileTCC
{
    public partial class App : Application
    {
        public static String BancoDados;
        public static String Caminho;
        public App(string Caminho, string BancoDados)
        {
            InitializeComponent();
            App.BancoDados = BancoDados;
            App.Caminho = Caminho;

            MainPage = new NavigationPage(new LoginPage());
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
