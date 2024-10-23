namespace BrightChoices;

public partial class videotest : ContentPage
{
	public videotest()
	{
		InitializeComponent();
		

    }



    public static string Imagelink;
    static PickOptions options;
    public async void loedImageLinkAsync()
    {

        var result = await FilePicker.Default.PickAsync(options);
        if (result != null)
        {
            if (result.FileName.EndsWith("mp4", StringComparison.OrdinalIgnoreCase))
                
            {
                using var stream = await result.OpenReadAsync();
                var image = ImageSource.FromStream(() => stream);

                Imagelink = result.FullPath;
                media.Source = Imagelink;

            }
            else
            {
                Imagelink = "";
                DisplayAlert("Alert", "Incorrect Image format", "Cancel");
            }
        }


    }

    private void play_Clicked(object sender, EventArgs e)
    {
        loedImageLinkAsync();
    }
}