using System.Windows;

namespace SharpDialogs.Wpf;

/// <summary>
/// A file save dialog for WPF.
/// </summary>
public static class SharpFileSaveDialogWpf
{
    /// <summary>
    /// Shows a dialog to select a save filename.
    /// </summary>
    /// <param name="owner">The onwer window.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <param name="defaultFileName">The default filename</param>
    /// <param name="windowsFilter">The files filter.</param>
    /// <param name="selectedFilterIndex">The index of the selected filter.</param>
    /// <returns>Returns the selected save filename.</returns>
    public static string? Show(
        Window? owner,
        string? title,
        string? initialDirectory,
        string? defaultFileName,
        string windowsFilter,
        int selectedFilterIndex)
    {
        return SharpFileSaveDialog.Show(Helpers.GetHWndForWindow(owner), title, initialDirectory, defaultFileName, windowsFilter, selectedFilterIndex);
    }

    /// <summary>
    /// Shows a dialog to select a save filename.
    /// </summary>
    /// <param name="owner">The onwer window.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <param name="defaultFileName">The default filename</param>
    /// <param name="filters">The files filters.</param>
    /// <param name="selectedFilterIndex">The index of the selected filter.</param>
    /// <returns>Returns the selected save filename.</returns>
    public static string? Show(
        Window? owner,
        string? title = null,
        string? initialDirectory = null,
        string? defaultFileName = null,
        IReadOnlyCollection<SharpDialogFilter>? filters = null,
        int selectedFilterIndex = -1)
    {
        return SharpFileSaveDialog.Show(Helpers.GetHWndForWindow(owner), title, initialDirectory, defaultFileName, filters, selectedFilterIndex);
    }
}
