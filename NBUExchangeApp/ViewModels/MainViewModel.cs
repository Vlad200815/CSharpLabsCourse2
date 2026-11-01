using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
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
    
    private readonly TopLevel? _topLevel;

    public MainViewModel() {}

    public MainViewModel(TopLevel topLevel)
    {
        _topLevel = topLevel;
    }
    
    [ObservableProperty] private ExchangeSnapshot? _localSnapshot;
    [ObservableProperty] private bool _showRestoreOffer;   
    [ObservableProperty] private bool _isLocalData;        

    public async Task InitializeAsync() => await LoadCommand.ExecuteAsync(null);

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
    
    
    private async Task OfferLocalRestoreAsync()
    {
        LocalSnapshot = await LocalStateService.TryLoadAsync();
        ShowRestoreOffer = LocalSnapshot is not null;
    }

    [RelayCommand(CanExecute = nameof(CanLoadOrOpen))]
    private async Task LoadAsync()
    {
        Status = "Завантаження…";
        Readings = null;
        IsBusy = true;
        
        IsLocalData = false;       
        ShowRestoreOffer = false;
        
        try
        {
            ExchangeSnapshot result = await ExchangeApiService.LoadExchangeDataAsync();
            Readings = result.Readings;
            
            await LocalStateService.SaveAsync(result);
            
            Status = result.Readings.Count == 0 ?
                "Нічого не знайдено" : $"Джерело: {result.DataSource}\n" +
                                       $"Отримано з інтернету о {result.SavedAt}\n" +
                                       $"Отримано елементів: {result.Readings.Count}";
        }
        catch (HttpRequestException)
        {
            Status = "Не вдалося з’єднатися із сервером.";
            await OfferLocalRestoreAsync();
        }
        catch (TaskCanceledException)
        {
            Status = "Сервер не відповів за відведений час.";
            await OfferLocalRestoreAsync();
        }
        catch (JsonException)
        {
            Status = "Сервер повернув дані неочікуваного формату.";
        }
        catch (Exception ex)
        {
            Status = "Сталася непередбачена помилка.";
            System.Diagnostics.Debug.WriteLine(ex);
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
        
        
        var file = await _topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Зберегти дані про погоду",
            SuggestedFileName = $"exchange-rate-{DateTime.Now:yyyy-MM-dd}.json",
            DefaultExtension = "json",
            FileTypeChoices = new[]
            {
                new FilePickerFileType("JSON files") { Patterns = new[] { "*.json" } }
            }
        });

        if (file is null)
        {
            Status = "Збереження скасовано.";
            return;
        }

        string path = file.Path.LocalPath;

        IsBusy = true;
        Status = "Збереження файла…";
        
        
        try
        {
            ExchangeSnapshot snapshot = new()
            {  
                DataSource = ExchangeApiService.SourceName,
                SourceUrl = ExchangeApiService.SourceUrl,
                SavedAt = DateTimeOffset.Now,
                Readings = _readings
            };
            
            await JsonFileService.SaveAsync(path, snapshot);
            Status = $"Файл збережено: {Path.GetFileName(path)}";
        }
        catch (UnauthorizedAccessException)
        {
            Status =
                "Немає дозволу на запис у вибране місце.";
        }
        catch (IOException)
        {
            Status =
                "Не вдалося записати файл. Можливо, він уже відкритий.";
        }
        catch (Exception ex)
        {
            Status = "Не вдалося зберегти файл.";
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }
        
    }


    [RelayCommand(CanExecute = nameof(CanLoadOrOpen))]
    private async Task OpenAsync()
    {
        IsLocalData = false;
        ShowRestoreOffer = false;
        
        if (_topLevel is null)
        {
            Status = "Немає доступу до вікна.";
            return;
        }

        var files = await _topLevel.StorageProvider.
            OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Відкрити курси валют",
            AllowMultiple = false,
            FileTypeFilter = new[]
            {
                new FilePickerFileType("JSON files") { Patterns = new[] { "*.json" } }
            }
        });

        if (files.Count == 0)
        {
            Status = "Відкриття скасовано.";
            return;
        }

        string path = files[0].Path.LocalPath;
        

        IsBusy = true;
        Status = "Збереження файла…";
        
        
        try
        {
            ExchangeSnapshot snapshot =
                await JsonFileService.LoadAsync<ExchangeSnapshot>(
                    path);
            
            List<ExchangeReading>? readings = snapshot.Readings;
            Readings = readings ?? throw new JsonException(
                "У файлі відсутній об’єкт reading.");
           
            string localSavedTime = snapshot.SavedAt
                .ToLocalTime()
                .ToString("g");
            Status =
                $"Джерело: {Path.GetFileName(path)}\n" +
                $"Збережено: {localSavedTime}.";
        }
        catch (JsonException)
        {
            Status =
                "Файл не є коректним файлом даних цього застосунку.";
        }
        catch (UnauthorizedAccessException)
        {
            Status =
                "Немає дозволу на читання вибраного файла.";
        }
        catch (IOException)
        {
            Status = "Не вдалося прочитати файл.";
        }
        catch (Exception ex)
        {
            Status = "Не вдалося відкрити файл.";
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }
    
    
    [RelayCommand]
    private void RestoreLocal()
    {
        if (LocalSnapshot is null) return;
        Readings = LocalSnapshot.Readings;
        IsLocalData = true;
        ShowRestoreOffer = false;
        Status = $"Локальні дані від {LocalSnapshot.SavedAt:dd.MM.yyyy HH:mm}";
    }
    
    
    
}