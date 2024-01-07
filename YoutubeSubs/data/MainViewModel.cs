using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Google.Apis.YouTube.v3.Data;
using Translator.gpt;
using Translator.models;
using Translator.youtube;

namespace YoutubeSubs.data;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly GPTRealApi _gptApi = new();
    private readonly YoutubeRealApi _youtubeApi = new();

    public List<PlaylistItem> Videos { get; set; }

    public PlaylistItem SelectedVideo { get; set; }

    public List<Caption> Captions { get; set; }

    public List<QueueItem> LoadQueue { get; set; }
    
    public Caption SelectedCaption { get; set; }
    
    public Video VideoWithLocalizations { get; set; }

    public string SelectedCaptionText { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public async Task<List<I18nLanguage>> GetSupportedLanguages()
    {
        return await _youtubeApi.GetSupportedLanguages();
    }
    
    public async void UpdateVideosList()
    {
        var list = await _youtubeApi.GetVideos();
        Videos = list;
    }

    public async void SelectVideo(PlaylistItem? item)
    {
        if (item == null) return;

        SelectedVideo = item;
    }

    public async void LoadCaptions()
    {
        Captions = await _youtubeApi.GetCaptionsForVideo(SelectedVideo.Snippet.ResourceId.VideoId);
    }
    
    public void SelectCaption(Caption? caption)
    {
        if (caption == null) return;
        SelectedCaption = caption;
    }

    public async void DownloadCaption()
    {
        SelectedCaptionText = await _youtubeApi.DownloadCaption(SelectedCaption.Id);
    }

    public async void DeleteAllCaptions()
    {
        var existedCaptions = Captions.Where(w => w.Snippet.Language != "ru");
        foreach (var existedCaption in existedCaptions)
        {
            await _youtubeApi.DeleteCaption(existedCaption.Id);
        }
    }

    public async void LoadLocalizations()
    {
        VideoWithLocalizations = await _youtubeApi.GetVideoWithLocalizationsById(SelectedVideo.Snippet.ResourceId.VideoId);
    }

    public async void TranslateLocalizations(Boolean forced = false)
    {
        var localizationMap = VideoWithLocalizations.Localizations;
        if (!localizationMap.ContainsKey("ru"))
        {
            MessageBox.Show("No original caption exist");
            return;
        }

        if (forced)
        {
            var localization = VideoWithLocalizations.Localizations;
            foreach (var keyValuePair in localization.Where(w => w.Key != "ru"))
            {
                localization.Remove(keyValuePair.Key);
            }

            VideoWithLocalizations.Localizations = localization;
            await _youtubeApi.UpdateVideoWithLocalizationsById(VideoWithLocalizations);
            VideoWithLocalizations = await _youtubeApi.GetVideoWithLocalizationsById(SelectedVideo.Snippet.ResourceId.VideoId);
        }
        

        var title = VideoWithLocalizations.Snippet.Title;
        var description = VideoWithLocalizations.Snippet.Description;

        if (String.IsNullOrEmpty(description.Trim()))
        {
            description = await _gptApi.GenerateHashtags(title);
            VideoWithLocalizations.Snippet.Description = description;
            localizationMap["ru"].Description = description;
        }
        
        try
        {
            LoadQueue = Parts.LanguageMap.Keys.Select(w => new QueueItem()
            {
                Language = w,
                Status = "Waiting for translation"
            }).ToList();

            var translatedCountries = VideoWithLocalizations.Localizations.Select(w => w.Key).ToList();
            foreach (var translatedCountry in translatedCountries)
            {
                SetStatus(translatedCountry, forced ? "Forced" : "Skipped");
            }

            var notTranslatedCountries = Parts.Countries.Where(w => forced || !translatedCountries.Contains(w));

            await Task.WhenAll(notTranslatedCountries.Where(w => w != "ru").ToList()
                .Select(async w => localizationMap[w] = await TranslateLocalization(w, title, description)));
            
            foreach (var countryCode in notTranslatedCountries)
            {
                SetStatus(countryCode, "Done");
            }

            VideoWithLocalizations.Localizations = localizationMap;
            await _youtubeApi.UpdateVideoWithLocalizationsById(VideoWithLocalizations);
        }
        catch (Exception ee)
        {
            MessageBox.Show(ee.Message);
            throw;
        }
    }
    
    public async void TranslateAllCaptions()
    {
        
        try
        {
            var existedCaptions = Captions;
            
            var originalCaption = existedCaptions.FirstOrDefault(i => i.Snippet.Language == "ru");
            if (originalCaption == null)
            {
                MessageBox.Show("No original caption exist");
                return;
            }
            
            LoadQueue = Parts.LanguageMap.Keys.Select(w => new QueueItem()
            {
                Language = w,
                Status = "Waiting for caption"
            }).ToList();

            var originalCaptionText = await _youtubeApi.DownloadCaption(originalCaption.Id);

            var subs = _gptApi.GenerateSubs(originalCaptionText);
            var rawText = String.Join("\n", subs.Select(w => w.Content));
            
            var translatedCountries = Captions.Select(w => w.Snippet.Language).ToList();
            foreach (var translatedCountry in translatedCountries)
            {
                SetStatus(translatedCountry, "Skipped");
            }

            var notTranslatedCountries = Parts.Countries.Where(w => !translatedCountries.Contains(w));
             
            foreach (var countryCode in notTranslatedCountries)
            {
                TranslateCaption(countryCode, rawText, subs);
            }
        }
        catch (Exception ee)
        {
            MessageBox.Show(ee.Message);
            throw;
        }
    }

    private async Task<VideoLocalization> TranslateLocalization(string countryCode, string title, string description)
    {
        var language = Parts.LanguageMap[countryCode];

        SetStatus(countryCode, "Translating");
        
        var translatedTitle = await _gptApi.Translate(language, title);
        var translatedDescription = await _gptApi.Translate(language, description);
        Console.WriteLine(translatedTitle);
        Console.WriteLine(translatedDescription);
        SetStatus(countryCode, "Translated");

        return new VideoLocalization()
        {
            Title = translatedTitle,
            Description = translatedDescription
        };
    }
    
    private async void TranslateCaption(string countryCode, string originalRawText, List<SubtitleModel> subs)
    {
        var language = Parts.LanguageMap[countryCode];

        SetStatus(countryCode, "Translating");
        
        var translatedCaptionText = await _gptApi.TranslateSubs(language, originalRawText, subs);
        SetStatus(countryCode, "Translated");
        
        if (Captions.Any(i => i.Snippet.Language == countryCode))
            await _youtubeApi.InsertAndUpload(SelectedVideo.Snippet.ResourceId.VideoId, countryCode,
                translatedCaptionText);
        else
            await _youtubeApi.InsertAndUpload(SelectedVideo.Snippet.ResourceId.VideoId, countryCode,
                translatedCaptionText);
        
        SetStatus(countryCode, "Done");
    }

    private void SetStatus(string countryCode, string status)
    {
        LoadQueue.FirstOrDefault(w => w.Language == countryCode)!.Status = status;
        LoadQueue = LoadQueue.ToList();
    }

    public async void OpenVideo()
    {
        var url = "https://www.youtube.com/watch?v=" + SelectedVideo?.Snippet.ResourceId.VideoId;

        // Open the URL in the default browser
        Process.Start(url);
    }

    public async void Auth()
    {
        await _youtubeApi.Auth();
    }

    public async void ReAuth()
    {
        await _youtubeApi.ReAuth();
    }
}