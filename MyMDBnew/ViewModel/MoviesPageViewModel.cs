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
    class MoviesPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Property of the search textbox
        /// </summary>
        public string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (!string.Equals(searchText, value))
                {
                    this.searchText = value;
                    // Notify UI elements that the data has changed.
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Movie lists shown in the page
        /// </summary>
        public ObservableCollection<Movie> NowPlaying { get; set; } = new ObservableCollection<Movie>();
        public ObservableCollection<Movie> Popular { get; set; } = new ObservableCollection<Movie>();
        public ObservableCollection<Movie> Upcoming { get; set; } = new ObservableCollection<Movie>();
        public ObservableCollection<Movie> TopRated { get; set; } = new ObservableCollection<Movie>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var service = new TmdbService();

            GetNowPlaying(service);
            GetPopular(service);
            GetUpcoming(service);
            GetTopRated(service);

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        public async void GetNowPlaying(TmdbService service)
        {
            var nowPlaying = await service.GetMovieNowPlayingAsync();
            if(nowPlaying.Results.Count != 0)
            {
                foreach(var item in nowPlaying.Results)
                {
                    NowPlaying.Add(item);
                }
            }
        }

        public async void GetPopular(TmdbService service)
        {
            var popular = await service.GetMoviePopularAsync();
            if (popular.Results.Count != 0)
            {
                foreach (var item in popular.Results)
                {
                    Popular.Add(item);
                }
            }
        }

        public async void GetUpcoming(TmdbService service)
        {
            var upcoming = await service.GetMovieUpcomingAsync();
            if (upcoming.Results.Count != 0)
            {
                foreach (var item in upcoming.Results)
                {
                    Upcoming.Add(item);
                }
            }
        }

        public async void GetTopRated(TmdbService service)
        {
            var topRated = await service.GetMovieTopRatedAsync();
            if (topRated.Results.Count != 0)
            {
                foreach (var item in topRated.Results)
                {
                    TopRated.Add(item);
                }
            }
        }

        /// <summary>
        /// Clicking on a list item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnListItemClick(object sender, ItemClickEventArgs e)
        {
            Movie selectedMovie = (Movie)e.ClickedItem;
            NavigationService.Navigate(typeof(MovieDetailsPage), selectedMovie.Id);
        }
    }
}
