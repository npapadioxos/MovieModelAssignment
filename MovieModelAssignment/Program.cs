using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieModelAssignment
{
	/// <summary>
	/// Crating the Movie Class
	/// </summary>
	public class Movie
	{
		#region Public Properties

		public List<string> actors = new List<string>();
		public List<int> review = new List<int>();
		public double Rating { get; set; }
		public double TicketReceipts { get; set; }
		public string Title { get; set; }

		#endregion Public Properties
	}

	internal class MovieModelAssignment
	{
		#region Private Methods

		/// <summary>
		/// Calculates the overall rating of the movie, based on user reviews
		/// </summary>
		/// <param name="movie"></param>
		/// <param name="randomReview"></param>
		/// <returns>double</returns>
		private static double CalculateRating(Movie movie,Random randomReview)
		{
			for(int i = 0; i < 100; i++)
			{
				movie.review.Add(randomReview.Next(1,100));
			}
			return movie.review.Average();
		}

		/// <summary>
		/// Creates the List of Movies
		/// </summary>
		/// <param name="moviesTitleList"></param>
		/// <param name="moviesActorsList"></param>
		/// <returns>Lists of Movies</returns>
		private static List<Movie> CreateMovieList(List<string> moviesTitleList,List<string> moviesActorsList)
		{
			int index = 0;
			Random random = new Random();
			List<Movie> movieList = new List<Movie>();

			foreach(string movieTitle in moviesTitleList)
			{
				Movie movie = new Movie()
				{
					Title = movieTitle,
					TicketReceipts = random.Next(1,1000)
				};

				for(int i = 0; i < 3; i++)
				{
					index = random.Next(moviesActorsList.Count);
					if(!movie.actors.Contains(moviesActorsList[index]))
					{
						movie.actors.Add(moviesActorsList[index]);
					}
				}

				movie.Rating = CalculateRating(movie,random);

				movieList.Add(movie);
			}

			return movieList;
		}

		private static void Main(string[] args)
		{
			List<string> moviesTitleList = new List<string>();
			moviesTitleList.AddRange(new string[] { "Blue Skyes","The Red Valley","Beyond Truth","The Dark Spade","Lonely Trip","The Ancestors","Protesters","The Rise Of The Last Empire","2099: The Final Call","Work Junkies","The Man Without Ego: Me","Identity: Graves Decorator","The Woman Who Did Not Exist","The Unknowners","Nicknamer: A Biography","Escape From Penthouse","The Life Of An Ant" });

			List<string> moviesActorsList = new List<string>();
			moviesActorsList.AddRange(new string[] { "Jonathan Clay","Antony Bayman","Marianna Johnson","Patrick Long","Tamara May","Ray Lean","Tim Tom","Eugene Fox","Eric Ericson","Lenny Linux","Scala Johansson","Mona Liza HardDrive","William Windows","Scotty Man","Bernard Cook","Yolanda Pearson","Steve Papas","Gus G" });

			List<Movie> movieList = new List<Movie>();
			movieList = CreateMovieList(moviesTitleList,moviesActorsList);

			PrintMovies(movieList);
		}

		/// <summary>
		/// Prints TOP 10 movies based on users reviews
		/// </summary>
		/// <param name="movieList"></param>
		private static void PrintMovies(List<Movie> movieList)
		{
			Console.WriteLine("MovieModelAssignment 06/2018\n\n*** Top 10 Movies Based on User Reviews ***");

			//Sorting the movieList based on the Rating (Descending order - best rating appears 1st)
			List<Movie> SortedList = movieList.OrderByDescending(s => s.Rating).ToList();

			//Keep only the first 10 elements of the SortedList for presentation
			IEnumerable<Movie> FinalList = SortedList.Take(10);

			foreach(Movie movie in FinalList)
			{
				Console.WriteLine("\n\nTitle = {0}\nRating = {1} %\nTicketReceipts = {2} (million USD)",movie.Title,movie.Rating,movie.TicketReceipts);

				Console.Write("Actors = ");

				foreach(String actor in movie.actors)
				{
					Console.Write(actor + " \t ");
				}
			}
		}
	}
}

#endregion Private Methods
