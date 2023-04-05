using Tweetinvi;
using Tweetinvi.Models.V2;
using Tweetinvi.Parameters.V2;

namespace GFK.Services
{
    public class TwitterApi
    {
        private readonly ITwitterClient _twitterClient;

        public TwitterApi(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
        {
            _twitterClient = new TwitterClient("uXsW4M7Q4M2zoDddLxRHoAt04", "h104iVd1Y0xnrdaj2B4oYpEpDFrK1iPiNaAqJekbhEOmQxTKIR", "1643370976070057986-LmCYF4ipYyTvhViWY41UwewUvo4QRZ", "5HtXMVhnUFxzQDeIZejHcfcFZXbo7BR8qq0QRwF8XEOpp");
        }

        public async Task<List<TweetV2>> SearchTweetsAsync(string query, bool onlyWithImages)
        {
            var searchParameter = new SearchTweetsV2Parameters(query)
            {
                PageSize = 100
            };

                var searchResponse = await _twitterClient.SearchV2.SearchTweetsAsync(searchParameter);
                var tweets = searchResponse.Tweets.ToList();

                if (onlyWithImages)
                {
                    tweets = tweets.Where(t => t.Attachments != null && t.Attachments.MediaKeys != null && t.Attachments.MediaKeys.Length > 0).ToList();
                }

                return tweets;
        }
    }
}


