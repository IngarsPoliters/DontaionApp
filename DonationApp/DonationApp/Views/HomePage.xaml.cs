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
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
                        
        }
        // each button opens new navigation
        private void SearchBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SearchDonationPage());
        }

        private void DonateBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MakeDonationPage());
        }
    }
}