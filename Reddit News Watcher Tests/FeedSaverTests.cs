using Reddit_News_Watcher;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Reddit_News_Watcher_Tests
{
	public class FeedSaverTests
	{
		[Fact]
		public void TestFeedSaver()
		{
			var feed = RedditAPI.RequestNews();
			FeedOrganizer.SaveFeeds(feed);
		}
	}
}
