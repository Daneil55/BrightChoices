using BrightChoices.Models;
using Firebase.Database;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BrightChoices;

public partial class LearningProgress : ContentPage
{
    private readonly FirebaseClient firebase;
	public LearningProgress(FirebaseClient firebase_)
	{
		InitializeComponent();
		firebase = firebase_;
        Data_Reader();



    }
    ObservableCollection<LearningPrograssTrack> postedModelsList { get; set; } = new ObservableCollection<LearningPrograssTrack>();
    ObservableCollection<LearningPrograssTrack> list { get; set; } = new ObservableCollection<LearningPrograssTrack>();
    
    public void Data_Reader()
    {
        postedModelsList.Clear();
        list.Clear();

        firebase.Child("LearningPrograssTrack")
            .AsObservable<LearningPrograssTrack>()
            .Subscribe(async (item) =>
            {
                list.Add(item.Object);

                for (int i = 0; i < list.Count; i++)
                {
                    if(list[i] != null)
                    if (list[i].username == MainPage.usernames)
                    {
                        if (list[i].prograsses == 1)
                            CourseProgress.Progress = 0.2;
                        else if (list[i].prograsses == 2)
                            CourseProgress.Progress = 0.5;
                        else if (list[i].prograsses == 3)
                            CourseProgress.Progress = 0.9;
                        else if (list[i] == null)
                            CourseProgress.Progress = 0;
                        else {
                            CourseProgress.Progress = 1;
                        }



                    }
                    else
                            CourseProgress.Progress = 0;
                }

            });
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		Navigation.PushAsync(new LossonsPage(firebase));
    }
}