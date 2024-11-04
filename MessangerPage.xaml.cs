using BrightChoices.Models;
using Firebase.Database;
using Firebase.Database.Query;
using Plugin.Maui.Audio;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace BrightChoices;

public partial class MessangerPage : ContentPage
{
    private readonly FirebaseClient firebase;

    ObservableCollection<MessageModel> PostFromFirebase { get; set; } = new ObservableCollection<MessageModel>();
    ObservableCollection<PostedModel> likes { get; set; } = new ObservableCollection<PostedModel>();
  
    public MessangerPage(FirebaseClient firebase_)
	{
		InitializeComponent();
        PostFromFirebase.Clear();
        lists.Clear();
        BindingContext = this;
        firebase = firebase_;
        Post_Reader();
        
        MSname.Text = Forum.usernames;
        ListI.ItemsSource = PostFromFirebase;
    }
    ObservableCollection<MessageModel> lists { get; set; } = new ObservableCollection<MessageModel>();

    public void Post_Reader()
    {
        PostFromFirebase.Clear();
        lists.Clear();
        firebase.Child("MessageModel").AsObservable<MessageModel>().Subscribe(async (item) =>
        {
                    lists.Add(item.Object);

        for (int i = 0; i < lists.Count; i++)
        {
                if (lists[i] != null)
                {

                    if (lists[i].Messanger == MainPage.usernames || lists[i].MessageOwner == MainPage.usernames)
                    {
                        if (lists[i].MessageOwner == Forum.usernames || lists[i].Messanger == Forum.usernames)
                        {

                            PostFromFirebase.Add(lists[i]);
                        }
                    }
                }
            }
        });
       
    }


    public async Task server(string message, string username, string messagesender)
    {

       await firebase.Child("MessageModel").PostAsync(new MessageModel
        {
            MessageOwner = username,
            Messages = message,
            Messanger = messagesender
        });
        await DisplayAlert("Message", "Accout Registerd", "ok");
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await server(MessageEntry.Text, MainPage.usernames, Forum.usernames);
        
        MessageEntry.Text = string.Empty;
    }
}