using MobileTCC.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileTCC
{
    public partial class Application : Xamarin.Forms.Application
    {
        public static String BancoDados;
        public static String Caminho;
        public Application(string Caminho, string BancoDados)
        {
            InitializeComponent();
            Application.BancoDados = BancoDados;
            Application.Caminho = Caminho;

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
