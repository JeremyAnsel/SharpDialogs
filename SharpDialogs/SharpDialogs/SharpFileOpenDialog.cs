using SharpDialogs.ComInterfaces;
using SharpDialogs.ComObjects;
using SharpDialogs.Enumerations;
using SharpDialogs.Structures;
using System.Runtime.InteropServices;

namespace SharpDialogs;

/// <summary>
/// A file open dialog.
/// </summary>
public static class SharpFileOpenDialog
{
    /// <summary>
    /// Shows a dialog to select a single open filename.
    /// </summary>
    /// <param name="hwndOwner">The handle of the onwer window.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <param name="defaultFileName">The default filename.</param>
    /// <param name="windowsFilter">The files filter.</param>
    /// <param name="selectedFilterIndex">The index of the selected filter.</param>
    /// <returns>Returns the selected open filename.</returns>
    public static string? ShowSingleSelect(
        IntPtr hwndOwner,
        string? title,
        string? initialDirectory,
        string? defaultFileName,
        string windowsFilter,
        int selectedFilterIndex)
    {
        IReadOnlyCollection<SharpDialogFilter> filters = SharpDialogFilter.ParseWindowsFilter(windowsFilter);
        List<string>? result = InnerShow(hwndOwner, title, initialDirectory, defaultFileName, filters, selectedFilterIndex, FileOpenOptions.None);

        if (result is not null && result.Count > 0)
        {
            return result[0];
        }

        return null;
    }

    /// <summary>
    /// Shows a dialog to select a single open filename.
    /// </summary>
    /// <param name="hwndOwner">The handle of the onwer window.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <param name="defaultFileName">The default filename.</param>
    /// <param name="filters">The files filters.</param>
    /// <param name="selectedFilterIndex">The index of the selected filter.</param>
    /// <returns>Returns the selected open filename.</returns>
    public static string? ShowSingleSelect(
        IntPtr hwndOwner,
        string? title = null,
        string? initialDirectory = null,
        string? defaultFileName = null,
        IReadOnlyCollection<SharpDialogFilter>? filters = null,
        int selectedFilterIndex = -1)
    {
        List<string>? result = InnerShow(hwndOwner, title, initialDirectory, defaultFileName, filters, selectedFilterIndex, FileOpenOptions.None);

        if (result is not null && result.Count > 0)
        {
            return result[0];
        }

        return null;
    }

    /// <summary>
    /// Shows a dialog to select multiple open filenames.
    /// </summary>
    /// <param name="hwndOwner">The handle of the onwer window.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <param name="defaultFileName">The default filename.</param>
    /// <param name="windowsFilter">The files filter.</param>
    /// <param name="selectedFilterIndex">The index of the selected filter.</param>
    /// <returns>Returns selected open filenames.</returns>
    public static IReadOnlyList<string>? ShowMultiSelect(
        IntPtr hwndOwner,
        string? title,
        string? initialDirectory,
        string? defaultFileName,
        string windowsFilter,
        int selectedFilterIndex)
    {
        IReadOnlyCollection<SharpDialogFilter> filters = SharpDialogFilter.ParseWindowsFilter(windowsFilter);
        List<string>? result = InnerShow(hwndOwner, title, initialDirectory, defaultFileName, filters, selectedFilterIndex, FileOpenOptions.AllowMultiselect);
        return result;
    }

    /// <summary>
    /// Shows a dialog to select multiple open filenames.
    /// </summary>
    /// <param name="hwndOwner">The handle of the onwer window.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <param name="defaultFileName">The default filename.</param>
    /// <param name="filters">The files filter.</param>
    /// <param name="selectedFilterIndex">The index of the selected filter.</param>
    /// <returns>Returns selected open filenames.</returns>
    public static IReadOnlyList<string>? ShowMultiSelect(
        IntPtr hwndOwner,
        string? title = null,
        string? initialDirectory = null,
        string? defaultFileName = null,
        IReadOnlyCollection<SharpDialogFilter>? filters = null,
        int selectedFilterIndex = -1)
    {
        List<string>? result = InnerShow(hwndOwner, title, initialDirectory, defaultFileName, filters, selectedFilterIndex, FileOpenOptions.AllowMultiselect);
        return result;
    }

    private static List<string>? InnerShow(
        IntPtr hwndOwner,
        string? title,
        string? initialDirectory,
        string? defaultFileName,
        IReadOnlyCollection<SharpDialogFilter>?
        filters,
        int selectedFilterIndex,
        FileOpenOptions options)
    {
        DpiHelpers.SetDpiAware();
        IFileOpenDialogCom dialog = new();

        try
        {
            options |=
                FileOpenOptions.NoTestFileCreate
                | FileOpenOptions.ForceFileSystem
                | FileOpenOptions.PathMustExist
                | FileOpenOptions.FileMustExist;

            dialog.SetOptions(options);

            if (title is not null)
            {
                dialog.SetTitle(title);
            }

            if (initialDirectory is not null)
            {
                SetFolder(dialog, initialDirectory);
            }

            if (defaultFileName is not null)
            {
                dialog.SetFileName(defaultFileName);
            }

            if (filters is not null)
            {
                SetFilters(dialog, filters, selectedFilterIndex);
            }

            HResult hr = dialog.Show(hwndOwner);

            if (hr == HResult.OK)
            {
                return GetFileNames(dialog);
            }

            if (hr == HResult.Canceled)
            {
                return null;
            }

            Marshal.ThrowExceptionForHR((int)hr);
            return null;
        }
        finally
        {
            Marshal.ReleaseComObject(dialog);
        }
    }

    private static void SetFilters(IFileOpenDialogCom dialog, IReadOnlyCollection<SharpDialogFilter> filters, int selectedFilterIndex)
    {
        FilterSpec[] specs = new FilterSpec[filters.Count];
        int index = 0;

        foreach (SharpDialogFilter filter in filters)
        {
            specs[index] = filter.ToFilterSpec();
            index++;
        }

        dialog.SetFileTypes((uint)specs.Length, specs);

        if (selectedFilterIndex >= 0 && selectedFilterIndex < specs.Length)
        {
            dialog.SetFileTypeIndex((uint)(1 + selectedFilterIndex));
        }
    }

    private static void SetFolder(IFileOpenDialogCom dialog, string folder)
    {
        IShellItem ppv = NativeMethods.SHCreateItemFromParsingName(folder);

        try
        {
            dialog.SetFolder(ppv);
        }
        finally
        {
            Marshal.ReleaseComObject(ppv);
        }
    }

    private static List<string> GetFileNames(IFileOpenDialogCom dialog)
    {
        var results = new List<string>();

        dialog.GetResults(out IShellItemArray itemsArray);

        try
        {
            itemsArray.GetCount(out uint itemsCount);

            for (uint i = 0; i < itemsCount; i++)
            {
                itemsArray.GetItemAt(i, out IShellItem item);

                try
                {
                    item.GetDisplayName(0x80028000, out string name);
                    results.Add(name);
                }
                finally
                {
                    Marshal.ReleaseComObject(item);
                }
            }
        }
        finally
        {
            Marshal.ReleaseComObject(itemsArray);
        }

        return results;
    }
}
