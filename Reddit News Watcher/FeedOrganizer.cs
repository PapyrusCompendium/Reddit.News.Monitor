using Reddit_News_Watcher.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Reddit_News_Watcher
{
	public static class FeedOrganizer
	{
		public static void SaveFeeds(RedditFeed feed)
		{
			var date = DateTime.Now.ToLongDateString();
			CreateDirectory(date);

			var stringBuilder = new StringBuilder();
			foreach (var newsFeed in feed.NewsStories)
			{
				stringBuilder.Clear();
				stringBuilder.AppendLine($"Headline: {newsFeed.Title}");
				stringBuilder.AppendLine($"Source: {newsFeed.Source}");
				stringBuilder.AppendLine($"Votes: {newsFeed.Votes}");

				File.WriteAllText(@$"RedditNews\{date}\{NormalizeFileName(newsFeed.Title)}", stringBuilder.ToString());
			}
		}

		private static string NormalizeFileName(string fileName)
		{
			var regexMatches = Regex.Matches(fileName, @"(\w+)");
			List<string> fileNameSegments = new List<string>();

			foreach (Match match in regexMatches)
			{
				if (!match.Success)
				{
					continue;
				}

				fileNameSegments.Add(match.Value);
			}
			return fileNameSegments.Count > 0
				? string.Join("_", fileNameSegments)
				: $"Invalid_Filename_{Guid.NewGuid()}";
		}

		private static void CreateDirectory(string dirName)
		{
			if (!Directory.Exists("RedditNews"))
			{
				Directory.CreateDirectory("RedditNews");
			}

			if (!Directory.Exists(@$"RedditNews\{dirName}"))
			{
				Directory.CreateDirectory(@$"RedditNews\{dirName}");
			}
		}
	}
}