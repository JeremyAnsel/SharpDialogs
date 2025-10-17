using SharpDialogs.ComInterfaces;
using SharpDialogs.ComObjects;
using SharpDialogs.Enumerations;
using SharpDialogs.Structures;
using System.Runtime.InteropServices;

namespace SharpDialogs;

public static class SharpFileSaveDialog
{
    public static string? Show(
        IntPtr hwndOwner,
        string? title,
        string? initialDirectory,
        string? defaultFileName,
        string windowsFilter,
        int selectedFilterIndex)
    {
        IReadOnlyCollection<SharpDialogFilter> filters = SharpDialogFilter.ParseWindowsFilter(windowsFilter);
        string? result = InnerShow(hwndOwner, title, initialDirectory, defaultFileName, filters, selectedFilterIndex, FileOpenOptions.None);
        return result;
    }

    public static string? Show(
        IntPtr hwndOwner,
        string? title = null,
        string? initialDirectory = null,
        string? defaultFileName = null,
        IReadOnlyCollection<SharpDialogFilter>? filters = null,
        int selectedFilterIndex = -1)
    {
        string? result = InnerShow(hwndOwner, title, initialDirectory, defaultFileName, filters, selectedFilterIndex, FileOpenOptions.None);
        return result;
    }

    private static string? InnerShow(
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
        IFileSaveDialogCom dialog = new();

        try
        {
            options |=
                FileOpenOptions.NoTestFileCreate
                | FileOpenOptions.ForceFileSystem
                | FileOpenOptions.PathMustExist
                | FileOpenOptions.FileMustExist
                | FileOpenOptions.OverwritePrompt;

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
                return GetFileName(dialog);
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

    private static void SetFilters(IFileSaveDialogCom dialog, IReadOnlyCollection<SharpDialogFilter> filters, int selectedFilterIndex)
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

    private static void SetFolder(IFileSaveDialogCom dialog, string folder)
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

    private static string GetFileName(IFileSaveDialogCom dialog)
    {
        dialog.GetResult(out IShellItem item);

        try
        {
            item.GetDisplayName(0x80028000, out string name);
            return name;
        }
        finally
        {
            Marshal.ReleaseComObject(item);
        }
    }
}
