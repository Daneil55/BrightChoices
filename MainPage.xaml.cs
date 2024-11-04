using Firebase.Database;
using BrightChoices;
using BrightChoices.Models;
using Plugin.Maui.Audio;
namespace BrightChoices
{

    public partial class MainPage : ContentPage
    {
      
        private readonly FirebaseClient firebase;


        public MainPage(FirebaseClient fibaseobj)
        {
            
            InitializeComponent();
            registrations.Clear();
            firebase = fibaseobj;
            Data_Reader();
        }
        List<RegistrationModel> registrations = new List<RegistrationModel>();

        private void OnCounterClicked(object sender, EventArgs e)
        {
          
                        
        }
        private readonly IAudioManager audio;

        private void logInBtn_Clicked(object sender, EventArgs e)
        {
            
            if (login(EmailTx.Text, PasswordTx.Text))
            {
                Navigation.PushAsync(new Forum(firebase, audio));
            }
            else
            {
                if (datacheck == 1)
                {

                }
                else
                {
                    DisplayAlert("Alert", "Account Not Found", "Cancel");
                }
            }
        
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            Navigation.PushAsync(new Regis(firebase));
        }

        public void Data_Reader()
        {

            firebase.Child("RegistrationModel").AsObservable<RegistrationModel>().Subscribe((item) =>
            {
                registrations.Add(item.Object);
            });
           
        }

        public static byte[] ImagePro;
        public static string usernames;
        public static string bio;
        public static string fullname;
        public static string emails;

        int datacheck = 0;

        public bool login(string email, string passwords)
        {           

            if (registrations.Count > 0)
            {
                for (int i = 0; i < registrations.Count; i++)
                {
                    if (registrations[i] != null)
                    {
                        if (registrations[i].Email == email && registrations[i].Password == passwords)
                        {
                            ImagePro = registrations[i].profileimage;
                            usernames = registrations[i].Username;
                            fullname = registrations[i].FullName;
                            bio = registrations[i].Bio;
                            emails = registrations[i].Email;
                            return true;
                        }
                    }
                }
            }
            else
            {
                DisplayAlert("Alert", "Low internet connection try again letter", "Cancel");
                datacheck = 1;
            }
            return false;
        }

    }

}
