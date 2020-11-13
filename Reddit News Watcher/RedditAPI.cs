using Reddit_News_Watcher.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Reddit_News_Watcher
{
	public static class RedditAPI
	{
		private const string RedditUrl = "https://old.reddit.com/r/worldnews/new/";
		public static RedditFeed RequestNews()
		{
			var client = new HttpClient();
			var responseData = client.GetAsync(RedditUrl).GetAwaiter().GetResult();

			if (!responseData.IsSuccessStatusCode)
			{
				throw new Exception("Error when trying to download reddit data.");
			}
			
			string rawHtml = responseData.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			return new RedditFeed(rawHtml);
		}
	}
}
