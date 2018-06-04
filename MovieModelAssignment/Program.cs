using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieModelAssignment
{
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

		private static double CalculateRating(Movie movie,Random randomReview)
		{
			for(int i = 0; i < 100; i++)
			{
				movie.review.Add(randomReview.Next(1,100));
			}
			return movie.review.Average();
		}

		private static void Main(string[] args)
		{
			Random randomReview = new Random();

			Movie IronMan = new Movie()
			{
				Title = "Ironman",
				TicketReceipts = 585.2
			};

			IronMan.Rating = CalculateRating(IronMan,randomReview);

			IronMan.actors.AddRange(new string[] { "actor1","actor2","actor3" });

			Console.WriteLine("Title = {0}\nTicketReceipts= {1}\nActors = {2}\nRating = {3}",IronMan.Title,IronMan.TicketReceipts,IronMan.actors,IronMan.Rating);
		}
	}
}

#endregion Private Methods
