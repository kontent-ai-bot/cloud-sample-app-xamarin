using KenticoCloud.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamFormsSample;

namespace XamarinDelivery
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            DeliveryClient client = new DeliveryClient("975bf280-fd91-488c-994c-2f04416e5ee3");

            try
            {
                var response = await client.GetItemsAsync<Article>(
                    new EqualsFilter("system.type", "article"),
                    new DepthParameter(0),
                    new OrderParameter("elements.post_date")
                );

                lstView.ItemsSource = response.Items;
            }
            catch (Exception e)
            {
                lblText.Text = e.Message;
                throw;
            }
        }
    }
}
