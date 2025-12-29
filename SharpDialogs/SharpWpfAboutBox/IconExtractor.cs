using System.Reflection;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SharpWpfAboutBox;

internal static class IconExtractor
{
    public static ImageSource? GetAppIcon(Assembly? assembly)
    {
        if (assembly is null)
        {
            return null;
        }

        IntPtr hLibrary = NativeMethods.LoadLibrary(assembly.Location);

        if (hLibrary == IntPtr.Zero)
        {
            return null;
        }

        IntPtr hIcon = NativeMethods.LoadIcon(hLibrary, "#32512");

        if (hIcon == IntPtr.Zero)
        {
            return null;
        }

        return Imaging.CreateBitmapSourceFromHIcon(hIcon, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
    }
}
