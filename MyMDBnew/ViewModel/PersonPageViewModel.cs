using MyMDBnew.Model;
using MyMDBnew.Service;
using MyMDBnew.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MyMDBnew.ViewModel
{
    class PersonPageViewModel : ViewModelBase
    {
        /// <summary>
        /// The person
        /// </summary>
        public Person person;
        public Person Person
        {
            get { return person; }
            set
            {
                Set(ref person, value);
            }
        }

        /// <summary>
        /// Cast of the movie
        /// </summary>
        public ObservableCollection<Movie> Cast { get; set; } = new ObservableCollection<Movie>();

        /// <summary>
        /// Crew of the movie
        /// </summary>
        public ObservableCollection<Movie> Crew { get; set; } = new ObservableCollection<Movie>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var personId = (int)parameter;

            var service = new TmdbApi();

            GetPerson(personId, service);
            GetPersonMovieCredits(personId, service);

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        /// <summary>
        /// Get the primary person details by id.
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="service"></param>
        public async void GetPerson(int personId, TmdbApi service)
        {
            Person = await service.GetPersonAsync(personId);
        }

        /// <summary>
        /// Get the movie credits for a person.
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="service"></param>
        public async void GetPersonMovieCredits(int personId, TmdbApi service)
        {
            var credits = await service.GetPersonCredits(personId);
            if (credits != null)
            {
                foreach (var item in credits.Cast)
                {
                    Cast.Add(item);
                }
                foreach (var item in credits.Crew)
                {
                    Crew.Add(item);
                }
            }
            
        }

        /// <summary>
        /// Clicking on a related movie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnRelatedMovieClick(object sender, ItemClickEventArgs e)
        {
            Movie selectedMovie = (Movie)e.ClickedItem;
            NavigationService.Navigate(typeof(MovieDetailsPage), selectedMovie.Id);
        }
    }
}
