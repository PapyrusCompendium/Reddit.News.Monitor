using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Reddit_News_Watcher.Models
{
	public class RedditFeed
	{
		public NewsBlock[] NewsStories { get; set; }
		public RedditFeed(string rawHtml)
		{
			var allTitles = GetAllCaptures(rawHtml, "TitleRegex");
			var allvotes = GetAllCaptures(rawHtml, "VotesRegex");
			var allSources = GetAllCaptures(rawHtml, "SourceRegex");

			NewsStories = new NewsBlock[allTitles.Length];
			for (int x = 0; x < allTitles.Length; x++)
			{
				NewsStories[x] = new NewsBlock
				{
					Title = allTitles[x],
					Votes = allvotes[x],
					Source = allSources[x]
				};
			}
		}

		public struct NewsBlock
		{
			public string Title { get; set; }
			public string Votes { get; set; }
			public string Source { get; set; }
		}

		private string[] GetAllCaptures(string rawHtml, string regexName)
		{
			List<string> allMatches = new List<string>();
			foreach(Match match in Regex.Matches(rawHtml, Properties.Resources.ResourceManager.GetString(regexName)))
			{
				if (match.Success)
				{					
					allMatches.Add(HttpUtility.HtmlDecode(match.Groups[1].Value));
				}
			}
			return allMatches.ToArray();
		}
	}
}
