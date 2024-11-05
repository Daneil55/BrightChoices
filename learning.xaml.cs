using Firebase.Database;
using Plugin.Maui.Audio;
using System.Xml.Linq;

namespace BrightChoices;

public partial class learning : ContentPage
{
    private readonly FirebaseClient firebase;
    private readonly IAudioManager audio;
    public learning(FirebaseClient firebase)
	{
		InitializeComponent();
        this.firebase = firebase;
        Profile_Ready();
    }

    private void CardBtn1_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new LearningProgress(firebase));
    }
    public void Profile_Ready()
    {
        if (MainPage.ImagePro != null)
        {
            var stream = new MemoryStream(MainPage.ImagePro);
            profilepx10.Source = ImageSource.FromStream(() => stream);
            prifilepxz.Source = ImageSource.FromStream(() => stream);
        }
    }
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Forum(firebase, audio));
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Forum(firebase, audio));

    }
}
