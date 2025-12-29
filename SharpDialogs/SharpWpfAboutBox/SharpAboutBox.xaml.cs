using System.Windows;

namespace SharpWpfAboutBox;

/// <summary>
/// Logique d'interaction pour SharpAboutBox.xaml
/// </summary>
public partial class SharpAboutBox : Window
{
    /// <summary>
    /// Create a new <see cref="SharpAboutBox"/> window.
    /// </summary>
    /// <param name="owner">The owner window.</param>
    public SharpAboutBox(Window? owner)
    {
        InitializeComponent();
        Owner = owner;
    }

    /// <summary>
    /// The properties of the assembly.
    /// </summary>
    public SharpAppProperties AppProperties => new();

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}
