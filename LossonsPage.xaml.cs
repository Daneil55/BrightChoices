using CommunityToolkit.Maui.Views;
using Firebase.Database;
using Plugin.Maui.Audio;

namespace BrightChoices;

public partial class LossonsPage : ContentPage
{
    private readonly FirebaseClient firebase;
    private readonly IAudioManager audio;
    public LossonsPage()
	{
		InitializeComponent();
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

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Forum(firebase, audio));
    }

    private void Scrow_Scrolled(object sender, ScrolledEventArgs e)
    {        
        video.Pause();
    }
}