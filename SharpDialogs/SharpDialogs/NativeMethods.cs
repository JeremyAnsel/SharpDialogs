using SharpDialogs.ComInterfaces;
using SharpDialogs.Enumerations;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace SharpDialogs;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
internal static class NativeMethods
{
    public const int DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE = -3;
    public const int PROCESS_PER_MONITOR_DPI_AWARE = 2;

    [DllImport("user32.dll", EntryPoint = "IsProcessDPIAware")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsProcessDPIAware();

    [DllImport("user32.dll", EntryPoint = "SetProcessDPIAware")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetProcessDPIAware();

    [DllImport("shcore.dll", EntryPoint = "SetProcessDpiAwareness")]
    public static extern IntPtr SetProcessDpiAwareness(int value);

    [DllImport("user32.dll", EntryPoint = "SetProcessDpiAwarenessContext")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool SetProcessDpiAwarenessContext(int value);

    [DllImport("shell32.dll", EntryPoint = "SHCreateItemFromParsingName")]
    private static extern HResult SHCreateItemFromParsingName(
        [MarshalAs(UnmanagedType.LPWStr)] string path,
        IntPtr pbc,
        in Guid riid,
        out IShellItem ppv
        );

    public static IShellItem SHCreateItemFromParsingName(string path)
    {
        SHCreateItemFromParsingName(
            path,
            IntPtr.Zero,
            new Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe"),
            out IShellItem ppv);

        return ppv;
    }

    [DllImport("shlwapi.dll", EntryPoint = "StrFormatByteSizeW")]
    public static extern IntPtr StrFormatByteSize(
        long fileSize,
        [MarshalAs(UnmanagedType.LPWStr)] StringBuilder buffer,
        int bufferSize);

    [DllImport("shlwapi.dll", EntryPoint = "PathCompactPathExW")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool PathCompactPathEx(
        [MarshalAs(UnmanagedType.LPWStr)] StringBuilder bufferOut,
        [MarshalAs(UnmanagedType.LPWStr)] string pszSrc,
        uint cchMax,
        uint dwFlags);

    [DllImport("kernel32.dll", EntryPoint = "GetConsoleWindow")]
    public static extern IntPtr GetConsoleWindow();
}
