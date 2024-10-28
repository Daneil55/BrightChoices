namespace BrightChoices;

public partial class learning : ContentPage
{
	public learning()
	{
		InitializeComponent();
	}

    private void CardBtn1_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new LearningProgress());
    }
}
