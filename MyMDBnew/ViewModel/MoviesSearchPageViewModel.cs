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
    public class MoviesSearchPageViewModel : ViewModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Movie> Result { get; set; } = new ObservableCollection<Movie>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var query = (string)parameter;
            var service = new TmdbService();

            GetResults(query, service);

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        public async void GetResults (string query, TmdbService service)
        {
            var result = await service.GetSearchMovieAsync(query);
            foreach (var item in result.Results)
            {
                Result.Add(item);
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
            NavigateToDetails(selectedMovie.Id);
        }

        /// <summary>
        /// Navigating to the DetailsPage of the selected movie
        /// </summary>
        /// <param name="id">ID of the selected movie.</param>
        public void NavigateToDetails(int id)
        {
            NavigationService.Navigate(typeof(MovieDetailsPage), id);
        }
    }
}
