using System.Windows;

namespace SharpDialogs.Wpf;

/// <summary>
/// A file open dialog for WPF.
/// </summary>
public static class SharpFileOpenDialogWpf
{
    /// <summary>
    /// Shows a dialog to select a single open filename.
    /// </summary>
    /// <param name="owner">The onwer window.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <param name="defaultFileName">The default filename.</param>
    /// <param name="windowsFilter">The files filter.</param>
    /// <param name="selectedFilterIndex">The index of the selected filter.</param>
    /// <returns>Returns the selected open filename.</returns>
    public static string? ShowSingleSelect(
        Window? owner,
        string? title,
        string? initialDirectory,
        string? defaultFileName,
        string windowsFilter,
        int selectedFilterIndex)
    {
        return SharpFileOpenDialog.ShowSingleSelect(Helpers.GetHWndForWindow(owner), title, initialDirectory, defaultFileName, windowsFilter, selectedFilterIndex);
    }

    /// <summary>
    /// Shows a dialog to select a single open filename.
    /// </summary>
    /// <param name="owner">The onwer window.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <param name="defaultFileName">The default filename.</param>
    /// <param name="filters">The files filters.</param>
    /// <param name="selectedFilterIndex">The index of the selected filter.</param>
    /// <returns>Returns the selected open filename.</returns>
    public static string? ShowSingleSelect(
        Window? owner,
        string? title = null,
        string? initialDirectory = null,
        string? defaultFileName = null,
        IReadOnlyCollection<SharpDialogFilter>? filters = null,
        int selectedFilterIndex = -1)
    {
        return SharpFileOpenDialog.ShowSingleSelect(Helpers.GetHWndForWindow(owner), title, initialDirectory, defaultFileName, filters, selectedFilterIndex);
    }

    /// <summary>
    /// Shows a dialog to select multiple open filenames.
    /// </summary>
    /// <param name="owner">The onwer window.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <param name="defaultFileName">The default filename.</param>
    /// <param name="windowsFilter">The files filter.</param>
    /// <param name="selectedFilterIndex">The index of the selected filter.</param>
    /// <returns>Returns selected open filenames.</returns>
    public static IReadOnlyList<string>? ShowMultiSelect(
        Window? owner,
        string? title,
        string? initialDirectory,
        string? defaultFileName,
        string windowsFilter,
        int selectedFilterIndex)
    {
        return SharpFileOpenDialog.ShowMultiSelect(Helpers.GetHWndForWindow(owner), title, initialDirectory, defaultFileName, windowsFilter, selectedFilterIndex);
    }

    /// <summary>
    /// Shows a dialog to select multiple open filenames.
    /// </summary>
    /// <param name="owner">The onwer window.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <param name="defaultFileName">The default filename.</param>
    /// <param name="filters">The files filter.</param>
    /// <param name="selectedFilterIndex">The index of the selected filter.</param>
    /// <returns>Returns selected open filenames.</returns>
    public static IReadOnlyList<string>? ShowMultiSelect(
        Window? owner,
        string? title = null,
        string? initialDirectory = null,
        string? defaultFileName = null,
        IReadOnlyCollection<SharpDialogFilter>? filters = null,
        int selectedFilterIndex = -1)
    {
        return SharpFileOpenDialog.ShowMultiSelect(Helpers.GetHWndForWindow(owner), title, initialDirectory, defaultFileName, filters, selectedFilterIndex);
    }
}
