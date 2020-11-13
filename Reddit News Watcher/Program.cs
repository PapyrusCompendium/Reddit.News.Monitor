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
				foreach(var newsFeed in response.NewsStories)
				{
					if (!foundHeadlines.Contains(newsFeed.Title))
					{
						Console.WriteLine("New Story!");
						ConsoleWriteColor(newsFeed.Title, ConsoleColor.Red);
						ConsoleWriteColor(newsFeed.Source, ConsoleColor.Gray);
						Console.Write("Upvotes:");
						ConsoleWriteColor($" +{newsFeed.Votes}\n", ConsoleColor.Green);
						foundHeadlines.Add(newsFeed.Title);
					}
				}

				// Check every 120 seconds for new feeds.
				Thread.Sleep(120 * 1000);
			}
		}

		private static void ConsoleWriteColor(string textData, ConsoleColor consoleColor)
		{
			var originalColor = Console.ForegroundColor;
			Console.ForegroundColor = consoleColor;
			Console.WriteLine(textData);
			Console.ForegroundColor = originalColor;
		}

		private static void SaveFeedData()
		{
			Console.WriteLine("Downloading r/worldnews Reddit data");
			var response = RedditAPI.RequestNews();
			FeedOrganizer.SaveFeeds(response);
		}
	}
}