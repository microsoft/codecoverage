using Microsoft.UI.Xaml;

namespace CodeCoverage.WinUI3Sample;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void RunSample_Click(object sender, RoutedEventArgs e)
    {
        int result = CoverageCalculator.Add(2, 3);
        ResultText.Text = $"2 + 3 = {result}, which is {CoverageCalculator.Describe(result)}.";
    }
}
