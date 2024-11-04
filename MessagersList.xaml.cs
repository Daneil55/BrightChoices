using BrightChoices.Models;
using Firebase.Database;
using Microsoft.Maui.Storage;
using Plugin.Maui.Audio;
using System.Collections.ObjectModel;

namespace BrightChoices;

public partial class MessagersList : ContentPage
{
    private readonly FirebaseClient firebase;
    private readonly IAudioManager audio;

    ObservableCollection<MessageModel> PostFromFirebase { get; set; } = new ObservableCollection<MessageModel>();
    ObservableCollection<PostedModel> likes { get; set; } = new ObservableCollection<PostedModel>();
    public MessagersList(FirebaseClient firebase_)
	{
		InitializeComponent();
        Post_Reader();
        firebase = firebase_;
        ListI.ItemsSource = PostFromFirebase;
    }
    public void Post_Reader()
    {

        firebase.Child("MessageModel").AsObservable<MessageModel>().Subscribe((item) =>
        {
            if (PostFromFirebase != null)
            {
                PostFromFirebase.Add(item.Object);
            }
        });
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {

    }
}