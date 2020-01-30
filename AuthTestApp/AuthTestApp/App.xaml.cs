using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AuthTestApp.Services;
using AuthTestApp.Views;

namespace AuthTestApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
