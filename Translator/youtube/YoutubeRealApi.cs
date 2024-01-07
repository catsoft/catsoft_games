using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace Translator.youtube;

public class YoutubeRealApi
{
    private static readonly string _channel_id = "UC_RrxVQHnIdQ_x9HtHXepNA";

    private YouTubeService YouTubeService { get; set; }

    public async Task Auth()
    {
        UserCredential credential = null;

        var auth = YoutubeAuth.GetSix();

        try
        {
            var clientSecrets = new ClientSecrets
            {
                ClientId = auth.CliendId,
                ClientSecret = auth.ClientSecret
            };

            var dataStorage = new FileDataStore(GetType().ToString());


            credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                clientSecrets,
                new[]
                {
                    YouTubeService.Scope.Youtube, YouTubeService.Scope.YoutubeChannelMembershipsCreator,
                    YouTubeService.Scope.YoutubeForceSsl, YouTubeService.Scope.YoutubeReadonly,
                    YouTubeService.Scope.YoutubeUpload, YouTubeService.Scope.Youtubepartner
                },
                "Youtube auto transaltor",
                CancellationToken.None,
                dataStorage
            );
        }
        catch (Exception ex)
        {
            //todo show error
            //// MessageBox.Show(ex.Message);
        }

        YouTubeService = new YouTubeService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApiKey = auth.ApiKey,
            ApplicationName = GetType().ToString()
        });
    }

    public async Task ReAuth()
    {
        var a = new FileDataStore(GetType().ToString());
        await a.ClearAsync();

        await Auth();
    }

    public async Task<List<I18nLanguage>> GetSupportedLanguages()
    {
        return (await YouTubeService.I18nLanguages.List(Parts.Languages).ExecuteAsync()).Items.ToList();
    }


    public async Task<List<SearchResult>> Search(string query)
    {
        var searchListRequest = YouTubeService.Search.List("snippet");
        searchListRequest.Q = query;
        searchListRequest.MaxResults = 50;

        var searchListResponse = await searchListRequest.ExecuteAsync();
        return searchListResponse.Items.ToList();
    }

    public async Task<List<PlaylistItem>> GetVideos()
    {
        var allItems = new List<PlaylistItem>();
        YouTubeService.Videos.List("");

        var channelsListRequest = YouTubeService.Channels.List("contentDetails");
        channelsListRequest.Id = _channel_id;

        // Retrieve the contentDetails part of the channel resource for the authenticated user's channel.
        try
        {
            var channelsListResponse = await channelsListRequest.ExecuteAsync();

            foreach (var channel in channelsListResponse.Items)
            {
                // From the API response, extract the playlist ID that identifies the list
                // of videos uploaded to the authenticated user's channel.
                var uploadsListId = channel.ContentDetails.RelatedPlaylists.Uploads;

                var nextPageToken = "";
                while (nextPageToken != null)
                {
                    var playlistItemsListRequest = YouTubeService.PlaylistItems.List(Parts.Video);
                    playlistItemsListRequest.PlaylistId = uploadsListId;
                    playlistItemsListRequest.MaxResults = 50;
                    playlistItemsListRequest.PageToken = nextPageToken;

                    // Retrieve the list of videos uploaded to the authenticated user's channel.
                    var playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();

                    allItems.AddRange(playlistItemsListResponse.Items);

                    nextPageToken = playlistItemsListResponse.NextPageToken;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return allItems;
    }

    public async Task<Video> GetVideoWithLocalizationsById(string videoId)
    {
        var request = YouTubeService.Videos.List(Parts.VideoLocalization);
        request.Id = videoId;
        var response = await request.ExecuteAsync();
        return response.Items.First();
    }
    
    public async Task UpdateVideoWithLocalizationsById(Video video)
    {
        var request = YouTubeService.Videos.Update(video, Parts.VideoUpdateLocalization);
        await request.ExecuteAsync();
    }
    
    public async Task<List<Caption>> GetCaptionsForVideo(string videoId)
    {
        var request = YouTubeService.Captions.List(Parts.Caption, videoId);
        var response = await request.ExecuteAsync();
        return response.Items.ToList();
    }

    public async Task<string> DownloadCaption(string captionId)
    {
        var request = YouTubeService.Captions.Download(captionId);
        var response = await request.ExecuteAsync();
        return response;
    }

    public async Task DeleteCaption(string captionId)
    {
        var request = YouTubeService.Captions.Delete(captionId);
        await request.ExecuteAsync();
    }
    
    public async Task InsertAndUpload(
        string videoId,
        string language,
        string caption)
    {
        var snippet = new CaptionSnippet
        {
            Language = language,
            VideoId = videoId,
            Name = "",
            IsDraft = false
        };
        var captionBody = new Caption
        {
            Snippet = snippet
        };

        var stream = new MemoryStream(Encoding.UTF8.GetByteCount(caption));
        var writer = new StreamWriter(stream, Encoding.UTF8, 512, true);
        writer.Write(caption);
        writer.Flush();
        stream.Position = 0;

        var request = YouTubeService.Captions.Insert(captionBody, Parts.Caption, stream, "");
        await request.UploadAsync();
    }
}