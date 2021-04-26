using System;
using System.Collections.Generic;
using SQLite;
using TravelRecord.Model;
using Xamarin.Forms;

namespace TravelRecord
{
    public partial class PostDetailPage : ContentPage
    {
        Post selectedPost;
        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();
            this.selectedPost = selectedPost;
            experienceLabel.Text = selectedPost.Experience;
        }

        void UpdateButton_Clicked(System.Object sender, System.EventArgs e)
        {
            selectedPost.Experience = experienceLabel.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedPost);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successfully updated", "OK");
                }
                else
                {
                    DisplayAlert("Failure", "Experience not updated", "OK");
                }
            }
        }

        void DeleteButton_Clicked(System.Object sender, System.EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedPost);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successfully deleted", "OK");
                }
                else
                {
                    DisplayAlert("Failure", "Experience not deleted", "OK");
                }
            }
        }
    }
}
