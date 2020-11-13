using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace Reddit_News_Watcher
{
	public static class GoogleImages
	{
		public static string GetFirstImage(string searchTerm)
		{
			string imagesHtml = GetImages(searchTerm);

			var regexMatch = Regex.Match(imagesHtml, Properties.Resources.ResourceManager.GetString("GoogleImageRegex"));

			return regexMatch.Success
				? regexMatch.Groups[1].Value
				: "";
		}

		private static string GetImages(string searchTerm)
		{
			var searchURL = $"https://www.google.com/search?q={searchTerm}&tbm=isch";
			var client = new HttpClient();
			var responseData = client.GetAsync(searchURL).GetAwaiter().GetResult();

			if (!responseData.IsSuccessStatusCode)
			{
				throw new Exception("Error when trying to download google data.");
			}

			string rawHtml = responseData.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			return rawHtml;
		}
	}
}
