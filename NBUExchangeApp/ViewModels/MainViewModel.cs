using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NBUExchangeApp.Models;
using NBUExchangeApp.Services;

namespace NBUExchangeApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _status = "Натисніть «Завантажити з інтернету»";

    [ObservableProperty]
    private List<ExchangeReading>? _readings;

    [RelayCommand]
    private async Task LoadAsync()
    {
        Status = "Завантаження…";
        Readings = null;

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
    }
}