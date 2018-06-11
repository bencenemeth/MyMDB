﻿using MyMDBnew.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyMDBnew.Service
{
    public class TmdbApi
    {
        /// <summary>
        /// Server URL
        /// </summary>
        private readonly Uri serverUrl = new Uri("https://api.themoviedb.org/3/");

        /// <summary>
        /// Key for network calls
        /// </summary>
        private readonly string clientKey = "api_key=b99081aad4a5b58ab3c3494ee01a9253";

        /// <summary>
        /// 
        /// </summary>
        private string language = "language=en_US";

        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                // Adding the required headers
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("trakt-api-version", "2");
                //client.DefaultRequestHeaders.Add("trakt-api-key", clientKey);

                // Ignoring null values and missing members from response
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                // Getting the response
                var response = await client.GetAsync(uri);

                // Reading response as string
                var json = await response.Content.ReadAsStringAsync();

                // Deserializing to the appropriate object
                T result = JsonConvert.DeserializeObject<T>(json, settings);
                return result;
            }
        }

        /// <summary>
        /// Get the primary information about a movie.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Movie> GetMovieAsync(int id)
        {
            return await GetAsync<Movie>(new Uri(serverUrl, $"movie/{id}?{clientKey}&{language}"));
        }

        /// <summary>
        /// Get a list of movies in theatres. This is a release type query that looks for all movies that have a release type of 2 or 3 within the specified date range.
        /// </summary>
        /// <returns></returns>
        //public async Task<List<Movie>> GetMovieNowPlayingAsync()
        public async Task<ListResult<Movie>> GetMovieNowPlayingAsync()
        {
            return await GetAsync<ListResult<Movie>>(new Uri(serverUrl, $"movie/now_playing?{clientKey}&{language}"));
        }

        /// <summary>
        /// Get a list of the current popular movies on TMDb. This list updates daily.
        /// </summary>
        /// <returns></returns>
        public async Task<ListResult<Movie>> GetMoviePopularAsync()
        {
            return await GetAsync<ListResult<Movie>>(new Uri(serverUrl, $"movie/popular?{clientKey}&{language}"));
        }

        /// <summary>
        /// Get a list of upcoming movies in theatres. This is a release type query that looks for all movies that have a release type of 2 or 3 within the specified date range.
        /// </summary>
        /// <returns></returns>
        public async Task<ListResult<Movie>> GetMovieUpcomingAsync()
        {
            return await GetAsync<ListResult<Movie>>(new Uri(serverUrl, $"movie/upcoming?{clientKey}&{language}"));
        }

        /// <summary>
        /// Get the top rated movies on TMDb.
        /// </summary>
        /// <returns></returns>
        public async Task<ListResult<Movie>> GetMovieTopRatedAsync()
        {
            return await GetAsync<ListResult<Movie>>(new Uri(serverUrl, $"movie/top_rated?{clientKey}&{language}"));
        }

        /// <summary>
        /// Get a list of similar movies.
        /// </summary>
        /// <returns></returns>
        public async Task<ListResult<Movie>> GetMovieSimilarAsync(int id)
        {
            return await GetAsync<ListResult<Movie>>(new Uri(serverUrl, $"movie/{id}/similar?{clientKey}&{language}"));
        }

        /// <summary>
        /// Get the cast and crew for a movie.
        /// </summary>
        /// <returns></returns>
        public async Task<Credits> GetMovieCreditsAsync(int id)
        {
            return await GetAsync<Credits>(new Uri(serverUrl, $"movie/{id}/credits?{clientKey}&{language}"));
        }

        /// <summary>
        /// Get the primary person details by id.
        /// </summary>
        /// <returns></returns>
        public async Task<Person> GetPersonAsync(int id)
        {
            return await GetAsync<Person>(new Uri(serverUrl, $"person/{id}?{clientKey}&{language}"));
        }

        /// <summary>
        /// Get the movie and TV credits together in a single response.
        /// </summary>
        /// <returns></returns>
        public async Task<PersonCredits> GetPersonCredits(int id)
        {
            return await GetAsync<PersonCredits>(new Uri(serverUrl, $"person/{id}/combined_credits?{clientKey}&{language}"));
        }
    }
}
