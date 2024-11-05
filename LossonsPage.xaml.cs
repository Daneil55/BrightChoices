using BrightChoices.Models;
using CommunityToolkit.Maui.Views;
using Firebase.Database;
using Firebase.Database.Query;
using Plugin.Maui.Audio;

namespace BrightChoices;

public partial class LossonsPage : ContentPage
{
    private readonly FirebaseClient firebase;
    private readonly IAudioManager audio;
    public LossonsPage(FirebaseClient firebase_)
	{
		InitializeComponent();
        firebase = firebase_;
        Profile_Ready();
       
        //video.Source = MediaSource.FromResource("Images/brightv.mp4");
    }
    public async void Profile_Ready()
    {
        if (MainPage.ImagePro != null)
        {
            var stream = new MemoryStream(MainPage.ImagePro);
            profilepx1.Source = ImageSource.FromStream(() => stream);
            profilename.Text = MainPage.fullname;
        }
       // FileSystem.OpenAppPackageFileAsync("brightv.mp4");

    }
    public bool QuestionOneMethod()
    {
        if (QuestionOne.IsChecked == true && QuestionTwo.IsChecked == true) { 
        
            return true;
        
        }
        return false;

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Forum(firebase, audio));
    }

    private void Scrow_Scrolled(object sender, ScrolledEventArgs e)
    {        
        video.Pause();
    }
    public bool QuestionTwoMethod()
    {
        if (QuastionThree.IsChecked == true && QuastionFour.IsChecked == true)
        {

            return true;

        }
        return false;

    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        if (QuestionOneMethod())
        {


            firebase.Child("LearningPrograssTrack").PostAsync(new LearningPrograssTrack
            {
                username = MainPage.usernames,
                prograsses = 1

            });
            DisplayAlert("Message", "Congratulation...", "ok");
            ButOne.IsVisible = false;

        }
        else { DisplayAlert("Message", "You failed...", "ok"); }
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        if (QuestionTwoMethod())
        {

            firebase.Child("LearningPrograssTrack").PostAsync(new LearningPrograssTrack
            {
                username = MainPage.usernames,
                prograsses = 2

            });
            DisplayAlert("Message", "Congratulation...", "ok");
            ButTwo.IsVisible = false;

        }
        else { DisplayAlert("Message", "You failed...", "ok"); }

    }
    public bool QuestionThreeMethod()
    {
        if (QuestionFive.IsChecked == true && QuestionSix.IsChecked == true)
        {

            return true;

        }
        return false;

    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        if (QuestionThreeMethod())
        {

            firebase.Child("LearningPrograssTrack").PostAsync(new LearningPrograssTrack
            {
                username = MainPage.usernames,
                prograsses = 3

            });
            DisplayAlert("Message", "Congratulation...", "ok");
            ButThree.IsVisible= false;

        }
        else { DisplayAlert("Message", "You failed...", "ok"); }
    }
}