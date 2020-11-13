using System;
using System.Collections.Generic;
using System.Threading;

namespace Reddit_News_Watcher
{
	class Program
	{
		static void Main(string[] args)
		{
			switch (args.Length > 0 ? args[0] : "")
			{
				case "--realtime":
					WatchRealtimeFeed();
					break;

				case "--save":
					SaveFeedData();
					break;

				default:
					WatchRealtimeFeed();
					break;
			}
		}

		private static void WatchRealtimeFeed()
		{
			List<string> foundHeadlines = new List<string>();
			for(; ; )
			{
				var response = RedditAPI.RequestNews();
				var delayTime = foundHeadlines.Count - response.NewsStories.Length < 0 ? 0 : -1;

				foreach (var newsFeed in response.NewsStories)
				{
					if (!foundHeadlines.Contains(newsFeed.Title))
					{
						Console.WriteLine("New Story!");
						ConsoleWriteColor(newsFeed.Title, ConsoleColor.Red, delayTime);
						ConsoleWriteColor(newsFeed.Source, ConsoleColor.Gray, delayTime);
						ConsoleWriteColor($"Author: {newsFeed.Author} - {newsFeed.AuthorProfile}", ConsoleColor.Gray, delayTime);
						ConsoleWriteColor(newsFeed.PostAge, ConsoleColor.Gray, delayTime);

						Console.Write("Rank: ");

						ConsoleWriteColor($"{newsFeed.Rank}\n", ConsoleColor.Green, delayTime);
						foundHeadlines.Add(newsFeed.Title);
					}
				}

				// Check every 120 seconds for new feeds.
				Thread.Sleep(120 * 1000);
			}
		}

		private static void ConsoleWriteColor(string textData, ConsoleColor consoleColor, int delay)
		{
			var originalColor = Console.ForegroundColor;
			Console.ForegroundColor = consoleColor;

			var rng = new Random();
			foreach (var letter in textData)
			{
				Console.Write(letter);
				Thread.Sleep(delay < 0 ? rng.Next(30, 90) : delay);
			}
			Console.WriteLine();

			Console.ForegroundColor = originalColor;
		}

		private static void SaveFeedData()
		{
			for (; ; )
			{
				Console.WriteLine("Downloading r/worldnews Reddit data");
				var response = RedditAPI.RequestNews();
				FeedOrganizer.SaveFeeds(response);

				// Check every 120 seconds for new feeds.
				Thread.Sleep(120 * 1000);
			}
		}
	}
}