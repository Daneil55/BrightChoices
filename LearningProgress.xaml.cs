namespace BrightChoices;

public partial class LearningProgress : ContentPage
{
	public LearningProgress()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		Navigation.PushAsync(new LossonsPage());
    }
}