using DonationApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DonationApp
{
    public partial class App : Application
    {
        public static string FilePath;

        public App()
        {
            InitializeComponent();
            //Forcing RegistrationPage on app MainPage
            MainPage = new HomePage();
        }

        public App(string filePath)
        {
            InitializeComponent();
            //Forcing RegistrationPage on app MainPage
            MainPage = new NavigationPage(new HomePage());

            FilePath = filePath;
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
