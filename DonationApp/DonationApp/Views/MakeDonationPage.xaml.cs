using DonationApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using DonationApp.Tables;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Java.IO;
using Android.Graphics;

namespace DonationApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MakeDonationPage : ContentPage
	{
        public MakeDonationPage ()
		{
			InitializeComponent ();
            // all the counties in ireland, added to the picker to select county
            #region Counties
            CountyPicker.SelectedIndex = 0;
            CountyPicker.Items.Add("Antrim");
            CountyPicker.Items.Add("Armagh");
            CountyPicker.Items.Add("Carlow");
            CountyPicker.Items.Add("Cavan");
            CountyPicker.Items.Add("Clare");
            CountyPicker.Items.Add("Cork");

            CountyPicker.Items.Add("Derry");
            CountyPicker.Items.Add("Donegal");
            CountyPicker.Items.Add("Down");
            CountyPicker.Items.Add("Dublin");
            CountyPicker.Items.Add("Fermanagh");
            CountyPicker.Items.Add("Galway");

            CountyPicker.Items.Add("Kerry");
            CountyPicker.Items.Add("Kildare");
            CountyPicker.Items.Add("Kilkenny");
            CountyPicker.Items.Add("Laois");
            CountyPicker.Items.Add("Leitrim");
            CountyPicker.Items.Add("Limerick");

            CountyPicker.Items.Add("Longford");
            CountyPicker.Items.Add("Louth");
            CountyPicker.Items.Add("Mayo");
            CountyPicker.Items.Add("Meath");
            CountyPicker.Items.Add("Monaghan");
            CountyPicker.Items.Add("Offaly");

            CountyPicker.Items.Add("Roscommon");
            CountyPicker.Items.Add("Sligo");
            CountyPicker.Items.Add("Tipperary");
            CountyPicker.Items.Add("Tyrone");
            CountyPicker.Items.Add("Waterford");
            CountyPicker.Items.Add("Westmeath");

            CountyPicker.Items.Add("Wexford");
            CountyPicker.Items.Add("Wicklow");
            #endregion
        }
        // if image button is clicked, user can choose the image from gallery and then is displays the selected image below, 
        // couldnt get this to function properly as I cant seem to store the image in database, or couldnt save the image locally and store the destination in database.
        async void ImageBtn_Clicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if(stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
            }

    
            (sender as Button).IsEnabled = true;
        }

        // When dontation button is clicked, sends all the entrys to "ItemTable.cs" in tables folder and assigns each value.
        private void DonateBtn_Clicked(object sender, EventArgs e)
        {


            ItemTable itemTable = new ItemTable()
            {
                OrganizationName = EntryOrganisation.Text,
                Description = EntryDescription.Text,
                contactInformation = EntryContact.Text,
                county = (string)CountyPicker.SelectedItem
            };
            // establishes connection with SQlite and finds the path, which is declared in App.xaml.cs
            using (SQLiteConnection connection = new SQLiteConnection(App.FilePath))
            {
                //creates the table and inserts the itemTable to the database.
                connection.CreateTable<ItemTable>();
                connection.Insert(itemTable);
            }

        }
    }
}