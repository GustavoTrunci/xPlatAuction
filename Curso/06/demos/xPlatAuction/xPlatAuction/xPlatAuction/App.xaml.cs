
using Xamarin.Forms;
using xPlatAuction.Models;

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

            //force login first
            MainPage = new Login();

            //wait for indication that login completed
            MessagingCenter.Subscribe<AuctionService, LoginResult>(this, Constants.MSG_LOGIN_COMPLETE, LoginComplete);

        }

        public void LoginComplete(AuctionService svc, LoginResult result)
        {
            //was the login successful
            if (result.Succeeded)
            {

                Device.BeginInvokeOnMainThread(() =>
                    //login succeeded so we'll go to the main page now
                    MainPage = new NavigationPage(new Auctions())
                    );



                //stop listening for login result messages after success
                MessagingCenter.Unsubscribe<AuctionService>(this, Constants.MSG_LOGIN_COMPLETE);
            }
            
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
