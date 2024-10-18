using Firebase.Database;
using BrightChoices;
using BrightChoices.Models;
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

        private void logInBtn_Clicked(object sender, EventArgs e)
        {
            
            if (login(EmailTx.Text, PasswordTx.Text))
            {
                Navigation.PushAsync(new Forum(firebase));
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
        

        public bool login(string email, string passwords)
        {
            Data_Reader();

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
                            usernames = registrations[i].Username;
                            usernames = registrations[i].Username;
                            usernames = registrations[i].Username;
                            usernames = registrations[i].Username;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

    }

}
