using BrightChoices.Models;
using Firebase.Database;
using System;
using System.Collections.ObjectModel;
namespace BrightChoices;

public partial class Forum : ContentPage
{


    private readonly FirebaseClient firebase;
    ObservableCollection<RegistrationModel> DataFromFirebase { get; set; } = new ObservableCollection<RegistrationModel>();
    ObservableCollection<PostedModel> PostFromFirebase { get; set; } = new ObservableCollection<PostedModel>();
    public Forum(FirebaseClient fibaseobj)
    {
        InitializeComponent();


        BindingContext = this;
        firebase = fibaseobj;
        DataFromFirebase.Clear();
        PostFromFirebase.Clear();

        Data_Reader();
        Post_Reader();
        Profile_Ready();

        ListVs.ItemsSource = DataFromFirebase;
        ListV.ItemsSource = PostFromFirebase;

    }

    public void Profile_Ready()
    {
        if (MainPage.ImagePro != null) { 
        var stream = new MemoryStream(MainPage.ImagePro);
        profileTx.Source = ImageSource.FromStream(() => stream);
        userTx.Text = MainPage.fullname;
    } 
    }
        


    
    public void Data_Reader(){
        
        firebase.Child("RegistrationModel").AsObservable<RegistrationModel>().Subscribe((item) =>
        {
            if (DataFromFirebase != null)
            {
                DataFromFirebase.Add(item.Object);
            }
        });
    }

    public void Post_Reader()
    {

        firebase.Child("PostedModel").AsObservable<PostedModel>().Subscribe((item) =>
        {
            if (PostFromFirebase != null)
            {
                PostFromFirebase.Add(item.Object);
            }
        });
    }
    public static void Colours()
    {
        var lightBlue = Color.FromRgba(173, 216, 230, 0.3); // Light Blue
        var softLavender = Color.FromRgba(230, 230, 250, 0.3); // Soft Lavender
        var palePeach = Color.FromRgba(255, 218, 185, 0.3); // Pale Peach
        var mintGreen = Color.FromRgba(152, 255, 152, 0.3); // Mint Green
        var lightYellow = Color.FromRgba(255, 255, 224, 0.3); // Light Yellow
        var powderPink = Color.FromRgba(255, 182, 193, 0.3); // Powder Pink
        var skyBlue = Color.FromRgba(135, 206, 235, 0.3); // Sky Blue
        var lavenderBlush = Color.FromRgba(255, 240, 245, 0.3); // Lavender Blush
        var lightGray = Color.FromRgba(211, 211, 211, 0.3); // Light Gray
        var softCoral = Color.FromRgba(240, 128, 128, 0.3); // Soft Coral
        var frame = new Frame
        {
            BackgroundColor = lightBlue,
        };

       
       

    }

    private void ColorFrame_Loaded(object sender, EventArgs e)
    {
        var lightGray = Color.FromRgba(0, 0, 0, 0.4); // Light Gray
        var frame = new Frame
        {
            BackgroundColor = lightGray,
        };

        Frame n = (Frame)sender;
        n.BackgroundColor= lightGray;

    }

    private void CommentForm_Loaded(object sender, EventArgs e)
    {
        Frame frame = (Frame)sender;
        var dark = Color.FromRgba(0, 0, 0, 0.3);
        frame.BackgroundColor = dark;


    }

    private void BottomMenu_Loaded(object sender, EventArgs e)
    {
        Frame frame = (Frame)sender;
        var dark = Color.FromRgba(135, 206, 235, 0.5);
      
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Publisherxaml(firebase));
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ProfilePage(firebase));
    }

    private void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new learning());
    }

    private void TapGestureRecognizer_Tapped_3(object sender, TappedEventArgs e)
    {

    }
}