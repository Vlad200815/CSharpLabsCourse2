using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using NBUExchangeApp.Models;

namespace NBUExchangeApp.Services;

public static class LocalStateService
{
    private static readonly string FilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "NBUExchangeApp", "last-snapshot.json");

    public static async Task SaveAsync(ExchangeSnapshot snapshot)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);

        // Спочатку пишемо у тимчасовий файл, потім підміняємо.
        // Якщо програма впаде посеред запису, старий знімок лишиться цілим.
        string tmp = FilePath + ".tmp";
        await JsonFileService.SaveAsync(tmp, snapshot);
        File.Move(tmp, FilePath, overwrite: true);
    }

    public static async Task<ExchangeSnapshot?> TryLoadAsync()
    {
        if (!File.Exists(FilePath)) return null;
        try
        {
            return await JsonFileService.LoadAsync<ExchangeSnapshot>(FilePath);
        }
        catch (Exception ex) when (ex is JsonException or IOException)
        {
            return null; // пошкоджений файл = немає знімка
        }
    }
}