using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
namespace xPlatAuction
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Message.Text = "Lendo itens ...";

            MobileServiceClient client = new MobileServiceClient("http://localhost:57242/");

            var items = await client.GetTable <TodoItem>().ReadAsync();
            var item = items.First();
            Message.Text = item.Text;

            
        


        }
    }
}
