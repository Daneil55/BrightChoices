using BrightChoices.Models;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Maui.Storage;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BrightChoices;

public partial class ProfilePage : ContentPage
{
    private readonly FirebaseClient firebase;
    ObservableCollection<PostedModel> postedModelsList { get; set; } = new ObservableCollection<PostedModel>();
    public ProfilePage(FirebaseClient firebase_)
    {
		InitializeComponent();
        BindingContext = this;
        firebase = firebase_;
        postedModelsList.Clear();
        Profile_Ready();
        Data_Reader();
        
        //ListV.ItemsSource = list;
        ListV.ItemsSource = postedModelsList;
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

    public void Data_Reader()
    {
        postedModelsList.Clear();
        list.Clear();

        firebase.Child("PostedModel")
            .AsObservable<PostedModel>()
            .Subscribe(async (item) =>
        {
            list.Add(item.Object);
           
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].posterUsername == MainPage.usernames)
                {
                    postedModelsList.Add(list[i]);
                }
            }
                    
        });
       
    }

    ObservableCollection<PostedModel> list { get; set; } = new ObservableCollection<PostedModel>();

    
    private void Frame_Loaded(object sender, EventArgs e)
    {
            
    }

    private void ColorFrame_Loaded(object sender, EventArgs e)
    {
        Frame frame = (Frame)sender;
        var dark = Color.FromRgba(0, 0, 0, 0.4);
        frame.BackgroundColor = dark;

    }

    private void CommentForm_Loaded(object sender, EventArgs e)
    {
        Frame frame = (Frame)sender;
        var dark = Color.FromRgba(0, 0, 0, 0.4);
        frame.BackgroundColor = dark;
    }
}