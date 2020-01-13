using DonationApp.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DonationApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationPage : ContentPage
	{
		public RegistrationPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Creating database conditions, in order for me to do that I need to add Sqlite.net pcl package by Frank A. Krueger & PCLStorage
            //Creating one database inside the environmental documents folder on both iOS and Android 
            // and naming the database as UserDatabase.db where all the registered user credentials are stored
            SQLiteConnection database;
            database = GetConnection();


            // now I will create my table which will keep multiple user data
            database.CreateTable<RegUserTable>();
            // whenver user will enter its Username and Password from RegistrationPage UI then these values are going to be stored inside RegUserTable, 
            // Then this table will be authenticated with the database

            var item = new RegUserTable()
            {
                Username = UsernameEntry.Text,
                Password = PasswordEntry.Text
            };
            // now I will insert this Table into my Database
            database.Insert(item);
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Congratulations", "Your Registration was Succesfull", "Yes", "Cancel");

                if (result)
                    await Navigation.PushModalAsync(new LoginPage());

            });


        }
        //creates a connection with SQLite and create the path for database
        public SQLiteConnection GetConnection()
        {
            SQLiteConnection sqlitConnection;
            var sqliteFileName = "UserDatabase.db";
            IFolder folder = FileSystem.Current.LocalStorage;
            string path = PortablePath.Combine(folder.Path.ToString(), sqliteFileName);
            sqlitConnection = new SQLite.SQLiteConnection(path);
            return sqlitConnection;
        }
    }
}