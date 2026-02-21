using SharpDialogs.ComInterfaces;
using SharpDialogs.ComObjects;

namespace SharpDialogs;

/// <summary>
/// Exposes methods that control the progress indicator of the taskbar.
/// </summary>
public static class SharpTaskbarProgress
{
    private static readonly ITaskbarList3 _taskbar = (ITaskbarList3)new TaskbarComClass();

    /// <summary>
    /// Returns the console window.
    /// </summary>
    /// <returns>The window handle.</returns>
    public static IntPtr GetConsoleWindow()
    {
        return NativeMethods.GetConsoleWindow();
    }

    /// <summary>
    /// Sets the type and state of the progress indicator displayed on a taskbar button.
    /// </summary>
    /// <param name="hwnd">The handle of the window in which the progress of an operation is being shown. This window's associated taskbar button will display the progress bar.</param>
    /// <param name="state">Control the current state of the progress button.</param>
    public static void SetState(IntPtr hwnd, SharpTaskbarStates state)
    {
        _taskbar.SetProgressState(hwnd, state);
    }

    /// <summary>
    /// Displays or updates a progress bar hosted in a taskbar button to show the specific percentage completed of the full operation.
    /// </summary>
    /// <param name="hwnd">The handle of the window whose associated taskbar button is being used as a progress indicator.</param>
    /// <param name="progress">A value that indicates the proportion of the operation that has been completed at the time the method is called.</param>
    /// <param name="max">A value that specifies the value ullCompleted will have when the operation is complete.</param>
    public static void SetValue(IntPtr hwnd, ulong progress, ulong max)
    {
        _taskbar.SetProgressValue(hwnd, progress, max);
    }
}
