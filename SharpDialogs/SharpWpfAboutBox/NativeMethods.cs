using System.Runtime.InteropServices;
using System.Security;

namespace SharpWpfAboutBox;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
internal static class NativeMethods
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern IntPtr LoadIcon(IntPtr hInstance, string lpIconName);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    public static extern IntPtr LoadLibrary(string lpFileName);
}
