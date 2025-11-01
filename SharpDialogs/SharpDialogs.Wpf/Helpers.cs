using System.Windows;
using System.Windows.Interop;

namespace SharpDialogs.Wpf;

internal static class Helpers
{
    public static IntPtr GetHWndForWindow(Window? window)
    {
        return window is null ? IntPtr.Zero : new WindowInteropHelper(window).Handle;
    }
}
