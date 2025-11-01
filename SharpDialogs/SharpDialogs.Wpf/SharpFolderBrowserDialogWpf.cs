using System.Windows;

namespace SharpDialogs.Wpf;

/// <summary>
/// A folder browser dialog for WPF.
/// </summary>
public static class SharpFolderBrowserDialogWpf
{
    /// <summary>
    /// Shows a dialog to select a single folder.
    /// </summary>
    /// <param name="owner">The owner window.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <returns>Returns the selected folder.</returns>
    public static string? ShowSingleSelect(
        Window? owner,
        string? title = null,
        string? initialDirectory = null)
    {
        return SharpFolderBrowserDialog.ShowSingleSelect(Helpers.GetHWndForWindow(owner), title, initialDirectory);
    }

    /// <summary>
    /// Shows a dialog to select multiple folders.
    /// </summary>
    /// <param name="owner">The owner window.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <returns>Returns the selected folders.</returns>
    public static IReadOnlyList<string>? ShowMultiSelect(
        Window? owner,
        string? title = null,
        string? initialDirectory = null)
    {
        return SharpFolderBrowserDialog.ShowMultiSelect(Helpers.GetHWndForWindow(owner), title, initialDirectory);
    }
}
