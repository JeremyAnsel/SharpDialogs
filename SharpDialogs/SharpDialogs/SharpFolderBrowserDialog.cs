using SharpDialogs.ComInterfaces;
using SharpDialogs.ComObjects;
using SharpDialogs.Enumerations;
using System.Runtime.InteropServices;

namespace SharpDialogs;

/// <summary>
/// A folder browser dialog.
/// </summary>
public static class SharpFolderBrowserDialog
{
    /// <summary>
    /// Shows a dialog to select a single folder.
    /// </summary>
    /// <param name="hwndOwner">The handle of the owner window.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <returns>Returns the selected folder.</returns>
    public static string? ShowSingleSelect(
        IntPtr hwndOwner,
        string? title = null,
        string? initialDirectory = null)
    {
        List<string>? result = InnerShow(hwndOwner, title, initialDirectory, FileOpenOptions.None);

        if (result is not null && result.Count > 0)
        {
            return result[0];
        }

        return null;
    }

    /// <summary>
    /// Shows a dialog to select multiple folders.
    /// </summary>
    /// <param name="hwndOwner">The handle of the owner window.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <returns>Returns the selected folders.</returns>
    public static IReadOnlyList<string>? ShowMultiSelect(
        IntPtr hwndOwner,
        string? title = null,
        string? initialDirectory = null)
    {
        List<string>? result = InnerShow(hwndOwner, title, initialDirectory, FileOpenOptions.AllowMultiselect);
        return result;
    }

    private static List<string>? InnerShow(
        IntPtr hwndOwner,
        string? title,
        string? initialDirectory,
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
                | FileOpenOptions.FileMustExist
                | FileOpenOptions.PickFolders;

            dialog.SetOptions(options);

            if (title is not null)
            {
                dialog.SetTitle(title);
            }

            if (initialDirectory is not null)
            {
                SetFolder(dialog, initialDirectory);
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
