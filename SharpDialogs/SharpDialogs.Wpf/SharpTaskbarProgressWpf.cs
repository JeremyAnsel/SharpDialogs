using System.Windows;

namespace SharpDialogs.Wpf;

/// <summary>
/// Exposes methods that control the progress indicator of the taskbar.
/// </summary>
public static class SharpTaskbarProgressWpf
{
    /// <summary>
    /// Sets the type and state of the progress indicator displayed on a taskbar button.
    /// </summary>
    /// <param name="owner">The window in which the progress of an operation is being shown. This window's associated taskbar button will display the progress bar.</param>
    /// <param name="state">Control the current state of the progress button.</param>
    public static void SetState(Window? owner, SharpTaskbarStates state)
    {
        IntPtr hwnd = Helpers.GetHWndForWindow(owner);
        SharpTaskbarProgress.SetState(hwnd, state);
    }

    /// <summary>
    /// Displays or updates a progress bar hosted in a taskbar button to show the specific percentage completed of the full operation.
    /// </summary>
    /// <param name="owner">The window whose associated taskbar button is being used as a progress indicator.</param>
    /// <param name="progress">A value that indicates the proportion of the operation that has been completed at the time the method is called.</param>
    /// <param name="max">A value that specifies the value ullCompleted will have when the operation is complete.</param>
    public static void SetValue(Window? owner, ulong progress, ulong max)
    {
        IntPtr hwnd = Helpers.GetHWndForWindow(owner);
        SharpTaskbarProgress.SetValue(hwnd, progress, max);
    }
}
