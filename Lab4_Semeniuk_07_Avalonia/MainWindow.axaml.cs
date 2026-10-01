using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaApplication1;


public partial class MainWindow : Window
{
    private readonly TextAnalyzer _analyzer = new();
    
    public MainWindow()
    {
        InitializeComponent();
    }
    
    
    private void OnProcessButtonClicked(object? sender, RoutedEventArgs e)
    {
        string inputText = ProcessInput.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrEmpty(inputText))
        {
            StatusText.Text = "Status: Input cannot be empty.";
            OutputTextBlock.Text = string.Empty;
            return;
        }
        
        // Run analysis and format result
        var results = _analyzer.Analyse(inputText);
        OutputTextBlock.Text = _analyzer.FormatReport(inputText, results);
        StatusText.Text = "Status: Success.";
    }
    
    
    private void OnClearButtonClicked(object? sender, RoutedEventArgs e)
    {
        ProcessInput.Clear();
        OutputTextBlock.Text = string.Empty;
        StatusText.Text = "Status: Ready.";
        
    }
    
}