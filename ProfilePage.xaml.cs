using BrightChoices.Models;
using Microsoft.Maui.Storage;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BrightChoices;

public partial class ProfilePage : ContentPage
{
    ObservableCollection<PostedModel> PostFromFirebase { get; set; } = new ObservableCollection<PostedModel>();

    public ProfilePage()
    {
		InitializeComponent();
        Profile_Ready();
    }

    public void Profile_Ready()
    {
        if (MainPage.ImagePro != null)
        {
            var stream = new MemoryStream(MainPage.ImagePro);
            ProfilePC.Source = ImageSource.FromStream(() => stream);
            fullName.Text = MainPage.fullname;
            bio.Text = MainPage.bio;
        }
    }

        private void Frame_Loaded(object sender, EventArgs e)
         {
        Frame frame = (Frame)sender;
        var dark = Color.FromRgba(0, 0, 0, 0.5);
        
    }
}