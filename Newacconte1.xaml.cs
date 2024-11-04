using Firebase.Database;
using Plugin.Maui.Audio;
using System.Security.Cryptography.X509Certificates;

namespace BrightChoices;

public partial class Newacconte1 : ContentPage
{
    private readonly FirebaseClient firebase;
    public Newacconte1()
	{
		InitializeComponent();
	}
	public static string image;
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		if(MediaPicker.Default.IsCaptureSupported)
		{
			FileResult photo=await MediaPicker.Default.CapturePhotoAsync();
			if (photo != null)
			{
				string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
				using Stream sourceStream = await photo.OpenReadAsync();
				using FileStream localFileStream = File.OpenWrite(localFilePath);
				image = localFilePath;
				imageFile.Source = photo.FullPath;
				image = photo.FullPath;

				await sourceStream.CopyToAsync(localFileStream);
			}

		}
		
    }

    private readonly IAudioManager audio;

    private void Save_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Forum(firebase, audio));
    }
}