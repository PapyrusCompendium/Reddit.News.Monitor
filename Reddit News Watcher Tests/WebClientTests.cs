using Reddit_News_Watcher;
using System;
using Xunit;

namespace Reddit_News_Watcher_Tests
{
	public class WebClientTests
	{
		[Fact]
		public void TestRegex()
		{
			var response = RedditAPI.RequestNews();
			Console.WriteLine(response.NewsStories.Length);
		}
	}
}