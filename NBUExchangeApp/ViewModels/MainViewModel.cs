using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NBUExchangeApp.Models;
using NBUExchangeApp.Services;

namespace NBUExchangeApp.ViewModels;

public partial class MainViewModel : ViewModelBase

{

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LoadCommand))]
    [NotifyCanExecuteChangedFor(nameof(OpenCommand))]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private bool _isBusy;
    
    
    private bool CanLoadOrOpen() => !_isBusy;
    private bool CanSave() => !_isBusy && Readings is not null;
    
    
    [ObservableProperty]
    private string _status = "Натисніть «Завантажити з інтернету»";

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private List<ExchangeReading>? _readings;

    [RelayCommand]
    private async Task LoadAsync()
    {
        Status = "Завантаження…";
        Readings = null;
        IsBusy = true;
        
        try
        {
            List<ExchangeReading> result = await ExchangeApiService.LoadExchangeDataAsync();
            Readings = result;
            Status = result.Count == 0 ? "Нічого не знайдено" : $"Дані отримано: {result.Count}";
        }
        catch (Exception)
        {
            Status = "Не вдалося отримати дані";
        }
        finally
        {
            IsBusy = false;
        }
    }
    


    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task SaveAsync()
    {
        if (_readings is null)
        {
            Status =
                "Спочатку завантажте або відкрийте дані.";
            return;
        }
        
        
        /// Current work 
        
        // var topLevel = TopLevel.GetTopLevel();
        // var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions()
        // {
        //     Title = "Зберегти дані про обмін валют",
        //     SuggestedFileName = $"exchange-{DateTime.Now:yyyy-MM-dd}.json",
        //     DefaultExtension = "json",
        //     FileTypeChoices = new[]
        //     {
        //         new FilePickerFileType("JSON files") { Patterns = new[] {"*.json"}}
        //     }
        // });
        //
        // if (file is null)
        // {
        //     Status = "Збережуння скасовано.";
        //     return;
        // }
        //
        // string path = file.Path.LocalPath;
        
        
        
        // if (dialog.ShowDialog() != DialogResult.OK)
        // {
        //     statusLabel.Text = "Збереження скасовано.";
        //     return;
        // }
        // SetBusy(true);
        // statusLabel.Text = "Збереження файла…";
        // try
        // {
        //     WeatherSnapshot snapshot = new()
        //     {
        //         DataSource = WeatherService.SourceName,
        //         SourceUrl = WeatherService.SourceUrl,
        //         SavedAt = DateTimeOffset.Now,
        //         Reading = _currentReading
        //     };
        //     await JsonFileService.SaveAsync(
        //         dialog.FileName,
        //         snapshot);
        //     statusLabel.Text =
        //         $"Файл збережено: {Path.GetFileName(dialog.FileName)}";
        // }
        // catch (UnauthorizedAccessException)
        // {
        //     statusLabel.Text =
        //         "Немає дозволу на запис у вибране місце.";
        // }
        // catch (IOException)
        // {
        //     statusLabel.Text =
        //         "Не вдалося записати файл. Можливо, він уже відкритий.";
        // }
        // catch (Exception ex)
        // {
        //     statusLabel.Text = "Не вдалося зберегти файл.";
        //     System.Diagnostics.Debug.WriteLine(ex);
        // }
        // finally
        // {
        //     SetBusy(false);
        // }
        
    }
    
    
    [RelayCommand(CanExecute = nameof(CanLoadOrOpen))]
    private async Task OpenAsync(){}
}