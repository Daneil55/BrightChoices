using BrightChoices.Models;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Collections.ObjectModel;

namespace BrightChoices;

public partial class Regis : ContentPage
{
    private readonly FirebaseClient firebase;
    public Regis(FirebaseClient fibaseobj)
    {
        InitializeComponent();
        firebase = fibaseobj;
        indicate.IsRunning = false;
    }

    private static void NewMethod()
    {

    }
    ObservableCollection<RegistrationModel> DataFromFirebase { get; set; } = new ObservableCollection<RegistrationModel>();

    

    static string username;
    public void server(int id, byte[] image, string fullname, string email, string age, string gender, string phone, string password, string bio)
    {
        username = "@" + fullname + email.Substring(4);

        firebase.Child("RegistrationModel").PostAsync(new RegistrationModel
        {
            Id = id,
            profileimage = image,
            FullName = fullname,
            Email = email,
            Age = age,
            Gender = gender,
            Phone = phone,
            Password = password,
            Bio = bio,
            Username = username
        });
        DisplayAlert("Message", "Accout Registerd", "ok");
        Navigation.PushAsync(new MainPage(firebase));
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

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
                ProfileImage.Source = Imagelink;

            }
            else
            {
                Imagelink = "";
                DisplayAlert("Alert", "Incorrect Image format", "Cancel");
            }
        }


    }
    static string datavalidation;
    public void loginPage()
    {
        NameTx.Text = string.Empty;
        Imagelink = "";
        EmailTx.Text = string.Empty;
        AgeTx.Text = string.Empty;
        GenderTx.Text = string.Empty;
        PhoneTx.Text = string.Empty;
        PasswordTx.Text = string.Empty;
        ConpassTx.Text = string.Empty;
        BioTx.Text = string.Empty;
        Navigation.PushAsync(new MainPage(firebase));
    }    
   
    private void logInBtn_Clicked(object sender, EventArgs e)
    {   
        
        if (Validetionpassword() == false)
        {
            DisplayAlert("Alert", datavalidation, "cancel");
        }
        else
        {

            if (validetionpasswordcolor())
            {
                server(1, ImageToBinary(Imagelink), NameTx.Text, EmailTx.Text, AgeTx.Text, GenderTx.Text, PhoneTx.Text, PasswordTx.Text, BioTx.Text);
               
            }
            else
            {
                DisplayAlert("Alert", "Inavlid PassWord A", "Okay");
            }
        }
    }
    public bool Validetionpassword()
    {


            if (NameTx.Text == string.Empty || NameTx.Text.Length < 5)
            {

                
                    datavalidation = "Your name should be more than 5 characters";

                return false;
            }



            else if (EmailTx.Text == string.Empty || !EmailTx.Text.Contains("@"))
            {
                datavalidation = "Email input should not be empty";
                return false;
            }

            else if (AgeTx.Text == string.Empty || int.Parse(AgeTx.Text) < 12)
            {
                datavalidation = "invalide age";
                return false;
            }

            else if (PhoneTx.Text == string.Empty || PhoneTx.Text.Length > 13)
            {
                datavalidation = "invalide phone number";
                return false;
            }

            else if (Imagelink == null || Imagelink == "")
            {
                datavalidation = "Please add an Image";
                return false;
            }

            else if (BioTx.Text == string.Empty || BioTx.Text.Length > 200)
            {
                datavalidation = "Your bio should not eccid 200 charactors";
                return false;
            }
            else {
                return true; 
            }
        
        

       
    }
    public bool validetionpasswordcolor()
    {
        if (PasswordTx.Text != string.Empty && PasswordTx.Text.Length > 5 && ConpassTx.Text.Equals(PasswordTx.Text))
        {

            return true;
        }
        DisplayAlert("Alert", "Encorrect Password", "Close");
        return false;
    }


    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        loedImageLinkAsync();
    }
}