using System;
using System.Collections.Generic;
using SQLite;
using TravelRecord.Model;

using Xamarin.Forms;

namespace TravelRecord
{
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Post post = new Post()
            {
                Experience = experienceEntry.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Insert(post);


                experienceEntry.Text = "";

                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successfully inserted", "OK");
                }
                else
                {
                    DisplayAlert("Failure", "Experience not inserted", "OK");
                }
            }
        }
    }
}
