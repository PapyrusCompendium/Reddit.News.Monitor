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
			NewsStories = ParseRedditHtml(rawHtml);
		}

		private NewsBlock[] ParseRedditHtml(string rawHtml)
		{
			var newsFeeds = new List<NewsBlock>();
			var sourceMatches = Regex.Matches(rawHtml, Properties.Resources.ResourceManager.GetString("SourceRegex"));
			var taglineMatches = Regex.Matches(rawHtml, Properties.Resources.ResourceManager.GetString("TaglineRegex"));
			var domainMatches = Regex.Matches(rawHtml, Properties.Resources.ResourceManager.GetString("DomainRegex"));
			var rankMatches = Regex.Matches(rawHtml, Properties.Resources.ResourceManager.GetString("RankRegex"));
			var titleMatches = Regex.Matches(rawHtml, Properties.Resources.ResourceManager.GetString("TitleRegex"));

			for (int x = 0; x < sourceMatches.Count; x++)
			{
				var sourceCapGroup = sourceMatches[x].Groups;
				var taglineCapGroups = taglineMatches[x].Groups;
				var domainCapgroups = domainMatches[x].Groups;
				var rankCapGroups = rankMatches[x].Groups;
				var titleCapGroups = titleMatches[x].Groups;

				newsFeeds.Add(new NewsBlock()
				{
					Source = sourceCapGroup[1].Value,
					Title = titleCapGroups[1].Value,
					PostDate = taglineCapGroups[1].Value,
					PostAge = taglineCapGroups[2].Value,
					AuthorProfile = taglineCapGroups[3].Value,
					Author = taglineCapGroups[4].Value,
					Domain = domainCapgroups[1].Value,
					Rank = rankCapGroups[1].Value
				});
			}

			newsFeeds.Reverse();
			return newsFeeds.ToArray();
		}

		public struct NewsBlock
		{
			public string Title { get; set; }
			public string Rank { get; set; }
			public string Source { get; set; }
			public string Author { get; set; }
			public string AuthorProfile { get; set; }
			public string PostAge { get; set; }
			public string PostDate { get; set; }
			public string Domain { get; set; }
		}
	}
}
