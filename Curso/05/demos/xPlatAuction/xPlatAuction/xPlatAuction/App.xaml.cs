using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

[assembly: Xamarin.Forms.Xaml.XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Compile)]
namespace xPlatAuction
{
    public partial class App : Application
    {
        private static AuctionService _service;
        static App()
        {
            _service = new AuctionService("https://xPlatAuctionM3.azurewebsites.net/");
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Auctions());
        }

        public static AuctionService GetAuctionService(){
            return _service;
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
