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
    class MovieDetailsPageViewModel : ViewModelBase
    {
        /// <summary>
        /// The movie
        /// </summary>
        public Movie movie;
        public Movie Movie
        {
            get { return movie; }
            set
            {
                Set(ref movie, value);
            }
        }

        /// <summary>
        /// List of related movies
        /// </summary>
        public ObservableCollection<Movie> Similar { get; set; } = new ObservableCollection<Movie>();

        /*
        /// <summary>
        /// Cast and crew
        /// </summary>
        public Credits credits;
        public Credits Credits
        {
            get { return credits; }
            set
            {
                Set(ref credits, value);
            }
        }
        */

        /// <summary>
        /// Cast of the movie
        /// </summary>
        public ObservableCollection<Cast> Cast { get; set; } = new ObservableCollection<Cast>();

        /// <summary>
        /// Crew of the movie
        /// </summary>
        public ObservableCollection<Crew> Crew { get; set; } = new ObservableCollection<Crew>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            // Getting the ID of the movie from the parameter object
            var movieId = (int)parameter;

            var service = new TmdbApi();
        
            GetMovieDetails(movieId, service);
            GetSimilarMovies(movieId, service);
            GetCredits(movieId, service);

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        /// <summary>
        /// Get the primary information about a movie.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="service"></param>
        public async void GetMovieDetails(int movieId, TmdbApi service)
        {
            Movie = await service.GetMovieAsync(movieId);
        }

        /// <summary>
        /// Get a list of similar movies.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="service"></param>
        public async void GetSimilarMovies(int movieId, TmdbApi service)
        {
            var similar = await service.GetMovieSimilarAsync(movieId);
            if (similar != null)
            {
                foreach (var item in similar.Results)
                {
                    Similar.Add(item);
                } 
            }
        }

        /// <summary>
        /// Get the cast and crew for a movie.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="service"></param>
        public async void GetCredits(int movieId, TmdbApi service)
        {
            var credits = await service.GetMovieCreditsAsync(movieId);
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
        /// Clicking on a similar movie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSimilarMovieClick(object sender, ItemClickEventArgs e)
        {
            Movie selectedMovie = (Movie)e.ClickedItem;
            NavigationService.Navigate(typeof(MovieDetailsPage), selectedMovie.Id);
        }

        /// <summary>
        /// Clicking on a cast or crew member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnCastCrewMemberClick(object sender, ItemClickEventArgs e)
        {
            if(e.ClickedItem is Cast)
            {
                NavigationService.Navigate(typeof(PersonPage), ((Cast)e.ClickedItem).Id);
            }
            else
            {
                NavigationService.Navigate(typeof(PersonPage), ((Crew)e.ClickedItem).Id);
            }
            
        }
    }
}
