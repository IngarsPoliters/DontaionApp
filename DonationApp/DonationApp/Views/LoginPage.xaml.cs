using DonationApp.Tables;
using PCLStorage;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DonationApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        async void SignupBtn_Clicked(object sender, EventArgs e)
        {
            // when the signup button is clicked it will redirect you back to the registration page
            await Navigation.PushModalAsync(new RegistrationPage());
        }

        async void LoginBtn_Clicked(object sender, System.EventArgs e)
        {
            var UsernameEntry = EntryUsername.Text;
            var PasswordEntry = EntryPassword.Text;

            // if login button clicked then here it will access the database 
            SQLiteConnection database;
            database = GetConnection();
            // now I will validate wether my database table contains the registered user
            var myquery = database.Table<RegUserTable>().Where(u => u.Username.Equals(UsernameEntry) && u.Password.Equals(PasswordEntry)).FirstOrDefault();

            // if my query is not null, then I will navigate my user to home page
            if (myquery != null)
            {
                App.Current.MainPage = new NavigationPage(new HomePage());
            }
            //else if my query is null then alert will display to tell the user that his login entry is incorrect
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Error", "The Username and or Password is Incorrect", "Yes", "Cancel");

                    if (result)
                        await Navigation.PushModalAsync(new LoginPage());
                    else
                    {
                        await Navigation.PushModalAsync(new LoginPage());
                    }

                });
            }
                

        }

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