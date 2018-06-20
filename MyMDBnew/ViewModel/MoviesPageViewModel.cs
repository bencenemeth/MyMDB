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
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace MyMDBnew.ViewModel
{
    class MoviesPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Property of the search textbox
        /// </summary>
        public string query;
        public string Query
        {
            get { return query; }
            set
            {
                if (!string.Equals(query, value))
                {
                    this.query = value;
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

        /// <summary>
        /// Search on pressing enter key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
                Search();
        }

        /// <summary>
        /// Clicking on the search icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSearchClick(object sender, RoutedEventArgs e)
        {
            Search();
        }

        /// <summary>
        /// Searching for movies
        /// </summary>
        public void Search()
        {
            NavigationService.Navigate(typeof(MoviesSearchPage), Query);
        }
    }
}
