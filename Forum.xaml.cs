using BrightChoices.Models;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Maui.ApplicationModel.Communication;
using Plugin.Maui.Audio;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using static Microsoft.Maui.ApplicationModel.Permissions;
namespace BrightChoices;

public partial class Forum : ContentPage
{


    private readonly FirebaseClient firebase;
    private readonly IAudioManager audio;

    ObservableCollection<RegistrationModel> DataFromFirebase { get; set; } = new ObservableCollection<RegistrationModel>();
    ObservableCollection<PostedModel> PostFromFirebase { get; set; } = new ObservableCollection<PostedModel>();
    ObservableCollection<PostedModel> likes { get; set; } = new ObservableCollection<PostedModel>();
    public Forum(FirebaseClient fibaseobj, IAudioManager audioManager)
    {
        InitializeComponent();


        BindingContext = this;
        firebase = fibaseobj;
        audio = audioManager;
        DataFromFirebase.Clear();
        PostFromFirebase.Clear();

        if (DataFromFirebase.Count <= 0)
        {
            Data_Reader();
        }

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
        Navigation.PushAsync(new settingsPage());
    }

    private void TapGestureRecognizer_Tapped_4(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new Forum(firebase, audio));   
    }

    private void TapGestureRecognizer_Tapped_5(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new SearchPage());
    }

    private void TapGestureRecognizer_Tapped_6(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new NotificationsPage());
    }

    private void TapGestureRecognizer_Tapped_7(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new MessangerPage(firebase));
    }
    static string likecount;
    static int Ids;
    ObservableCollection<PostedModel> most = new ObservableCollection<PostedModel>();
    public async Task better(string data_pass, string values)
    {
        
    }
    private async void TapGestureRecognizer_Tapped_8(object sender, TappedEventArgs e)
    {
        
        Image likeImage = (Image)sender;

        // Get the parent Frame to access its BindingContext
        Grid parentFrame = (Grid)likeImage.Parent;
        // Adjust this based on your actual UI hierarchy
        Label lable = (Label)parentFrame.Children[1];
        AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("data.mp3")).Play();
        // DisplayAlert("Alert",lable.Text,"ok");
        
       
        await UpdateUserId("Yes", Ids, most, Ids);
        await better(lable.Text, likecount);


    }

    private void TapGestureRecognizer_Tapped_9(object sender, TappedEventArgs e)
    {
        string comment = "comment";
        if (PostFromFirebase != null)
        {
            firebase.Child("LikesModel").PostAsync(new LikesModel
            {
                userlikes = MainPage.usernames

            });
            DisplayAlert("Message", "Saved", "ok");

        }
    }

    private void TapGestureRecognizer_Tapped_10(object sender, TappedEventArgs e)
    {
        string share = "Share";
    }

    private void TapGestureRecognizer_Tapped_11(object sender, TappedEventArgs e)
    {
        string useraccount = "useraccount";
    }
    public static string usernames;
    private void TapGestureRecognizer_Tapped_12(object sender, TappedEventArgs e)
    {
        Frame frame = (Frame)sender;
        Grid grid=(Grid)frame.Parent;
        Label label=(Label)grid.Children[0];
        usernames = label.Text;

        Navigation.PushAsync(new MessangerPage(firebase));
    }


    public async Task UpdateUserByUsernameAsync(string updatedUser)
    {
        // Query to find the user by username
        var users = await firebase
            .Child("PostedModel")
            .OnceAsync<PostedModel>();

        // Find the user with the specified username
        var userToUpdate = users.FirstOrDefault(u => u.Object.posterUsername == MainPage.usernames);

        if (userToUpdate != null)
        {
            // Update the user with the new details
            await firebase
                .Child("PostedModel")
                .Child(userToUpdate.Key) // Using the user ID
                .PutAsync(updatedUser);
        }
        else
        {
            throw new Exception("User not found");
        }
    }

    ObservableCollection<PostedModel> countter = new ObservableCollection<PostedModel>();
    async Task UpdateUserId(string newId, int username, ObservableCollection<PostedModel> data, int date)
    {





        countter.Clear();
        var firebaseClient = firebase;       
        // Get the user with the specified username
        var user = await firebaseClient
            .Child("PostedModel") // Your node where users are stored
            .OrderBy("Id")
            .EqualTo(username)            
            .OnceAsync<PostedModel>();

        await firebaseClient
              .Child("User")
              .PostAsync(data);

        if (user.Any())
        {
            // Assuming there's only one user with that username
            var userToUpdate = user.First();

            // Ensure to keep other properties




            firebase.Child("User").AsObservable<PostedModel>().Subscribe((item) =>
            {




                if (likes != null)
                {
                    likes.Add(item.Object);
                    for (int i = 0; i< likes.Count; i++)
                    {
                        if (likes[i].Id == date)
                        {
                           
                                countter.Add( likes[i]);
                            
                        }
                    }
                }
                likecount = countter.Count.ToString();

                if (PostFromFirebase != null)
                {
                    for (int i = 0; i < PostFromFirebase.Count; i++)
                    {
                        if (PostFromFirebase[i].Id == date )
                        {
                            PostFromFirebase[i].like = likecount;
                            Ids = PostFromFirebase[i].Id;
                            most.Add(PostFromFirebase[i]);
                        }
                    }
                }
            });

            // Update the ID
            await firebaseClient
                .Child("PostedModel")
                .Child(userToUpdate.Key)
                .PutAsync(most); // Ensure to keep other properties
        }
    }

    // UserModel definition
    

}