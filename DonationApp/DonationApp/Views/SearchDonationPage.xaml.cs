using DonationApp.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DonationApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchDonationPage : ContentPage
	{

        
            
		public SearchDonationPage ()
		{
			InitializeComponent ();
		}

        // when navigated to SearchDonationPage this makes the list appear on the ListView, of all the database entrys. 
        protected override void OnAppearing()
        {
            base.OnAppearing();

           

            using (SQLiteConnection connection = new SQLiteConnection(App.FilePath))
            {
                // creating table
                connection.CreateTable<ItemTable>();
                var itemTable = connection.Table<ItemTable>().ToList();

                // pushes the database itemTable to the ListView
                itemListView.ItemsSource = itemTable;
            
            }
        
        
        }

        // when clicked on the item of the listview, this will open new navigation displaying the details of the selected item.... could not get this to work
        private async void ItemListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushModalAsync(new DetailsPage());
        }
    }
}