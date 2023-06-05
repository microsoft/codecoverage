using System.Windows;

namespace WpfApplication;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public static int Add(int x, int y)
    {
        return x + y;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Result.Text = Add(int.Parse(One.Text), int.Parse(Two.Text)).ToString();
    }
}
