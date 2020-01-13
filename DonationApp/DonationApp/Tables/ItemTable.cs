using Android.Provider;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DonationApp.Tables
{
    class ItemTable
    {
        // Item table for the database 
        [PrimaryKey, AutoIncrement]
        public int ItemId { get; set; }

        public string OrganizationName { get; set; }
        public string Description { get; set; }
        public string contactInformation { get; set; }
        public string county { get; set; }
        public string imageStr { get; set; }

    }
}
