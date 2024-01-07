using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Google.Apis.YouTube.v3.Data;
using Translator.youtube;
using YoutubeSubs.data;

namespace YoutubeSubs;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel = new();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = _viewModel;
        _viewModel.Auth();
        Activate();
        // Topmost = true;
        // Topmost = false;
        Focus();
        // CheckLanguages();
    }

    private async void CheckLanguages()
    {
        var language = await _viewModel.GetSupportedLanguages();
        Console.WriteLine(String.Join(", ", language.Select(w => w.Snippet.Name)));
        Console.WriteLine(String.Join(", ", language.Select(w => w.Snippet.Hl)));
        var hls = language.Select(w => w.Snippet.Hl).ToList();
        
        Console.WriteLine(Parts.Countries.All(w => hls.Contains(w)));
        foreach (var cou in Parts.Countries)
        {
            if (!hls.Contains(cou))
            {
                Console.WriteLine(cou);
            }
        }
    }

    private void AuthOnClick(object sender, RoutedEventArgs e)
    {
        _viewModel.ReAuth();
    }

    private void LoadVideosClick(object sender, RoutedEventArgs e)
    {
        _viewModel.UpdateVideosList();
    }

    private void VideosSelected(object sender, SelectionChangedEventArgs e)
    {
        var selectedItems = e.AddedItems.Cast<PlaylistItem>();
        _viewModel.SelectVideo(selectedItems?.FirstOrDefault());
    }

    private void LoadCaptions(object sender, RoutedEventArgs e)
    {
        _viewModel.LoadCaptions();
    }
    
    private void DownloadCaption(object sender, RoutedEventArgs e)
    {
        _viewModel.DownloadCaption();
    }
    
        
    private void TranslateAll(object sender, RoutedEventArgs e)
    {
        _viewModel.TranslateAllCaptions();
    }

    private void DeleteAllCaptions(object sender, RoutedEventArgs e)
    {
        _viewModel.DeleteAllCaptions();
    }
    
    private void OpenVideo(object sender, RoutedEventArgs e)
    {
        _viewModel.OpenVideo();
    }
    
    private void CaptionSelected(object sender, SelectionChangedEventArgs e)
    {
        var selectedItems = e.AddedItems.Cast<Caption>();
        _viewModel.SelectCaption(selectedItems?.FirstOrDefault());
    }
    
    private void LoadLocalizations(object sender, RoutedEventArgs e)
    {
        _viewModel.LoadLocalizations();
    }
    
    private void TranslateLocalizations(object sender, RoutedEventArgs e)
    {
        _viewModel.TranslateLocalizations();
    }
    
    private void TranslateLocalizationsForced(object sender, RoutedEventArgs e)
    {
        _viewModel.TranslateLocalizations(true);
    }
}