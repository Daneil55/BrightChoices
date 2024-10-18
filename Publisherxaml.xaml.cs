using BrightChoices.Models;
using Firebase.Database;
using Firebase.Database.Query;

namespace BrightChoices;

public partial class Publisherxaml : ContentPage
{
    private readonly FirebaseClient firebase;
    public Publisherxaml(FirebaseClient fibaseobj)
	{

		InitializeComponent();
        firebase = fibaseobj;
        Profile_Ready();

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        loedImageLinkAsync();
    }

    public void Profile_Ready()
    {
        if (MainPage.ImagePro != null)
        {
            var stream = new MemoryStream(MainPage.ImagePro);
            PostPImage.Source = ImageSource.FromStream(() => stream);
            Name_Holder.Text = MainPage.fullname;
        }
    }


    public void server(int ids, byte[] images, byte[] postimages, string fullnames, string emails, string usernames, string texts, int postids, byte[] audios, byte[] videos, string comments, int likes, int shares)
    {
       

        firebase.Child("PostedModel").PostAsync(new PostedModel
        {
            Id = 0,
            posterName =fullnames,
            posterUsername = usernames,
            posteremail = emails,
            posterImage = images,
            postId = 0,
            posttext = texts,
            postimage = postimages,
            postVideo = video,
            postaudio = video,                   
            like = 5,
            comment = comments,
            share = 5           
        });

        DisplayAlert("Message", "Posted", "ok");
        Navigation.PushAsync(new Forum(firebase));
    }

    public static string Imagelink;
    static PickOptions options;
    public async void loedImageLinkAsync()
    {

        var result = await FilePicker.Default.PickAsync(options);
        if (result != null)
        {
            if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
            {
                using var stream = await result.OpenReadAsync();
                var image = ImageSource.FromStream(() => stream);

                Imagelink = result.FullPath;
                Edit_images.Source = Imagelink;

            }
            else
            {
                Imagelink = "";
                DisplayAlert("Alert", "Incorrect Image format", "Cancel");
            }
        }
    }
    public static byte[] ImageToBinary(string imagePath)
    {
        if (imagePath == null || imagePath == "")
        {
            return null;
        }
        FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
        byte[] buffer = new byte[fileStream.Length];
        fileStream.Read(buffer, 0, (int)fileStream.Length);
        fileStream.Close();
        return buffer;
    }
    byte[] audio = { 000, 000, 000};
    byte[] video = { 000, 000, 000};
    int share = 0;
    private void postbutton_Clicked(object sender, EventArgs e)
    {
        server(1, MainPage.ImagePro, ImageToBinary(Imagelink),MainPage.fullname,MainPage.emails,MainPage.usernames, Post_editor.Text, 1, audio, video," ", 1,share);
    }
}