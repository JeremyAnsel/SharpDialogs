using System.Text;

namespace SharpDialogs;

public static class SharpDialogHelpers
{
    public static string GetByteSizeString(long filesize)
    {
        if (filesize < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(filesize));
        }

        var sb = new StringBuilder(11);
        NativeMethods.StrFormatByteSize(filesize, sb, sb.Capacity);
        return sb.ToString();
    }

    public static string CompactPath(string path, int length)
    {
        if (length < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }

        var sb = new StringBuilder(32768);
        NativeMethods.PathCompactPathEx(sb, path, (uint)Math.Min(sb.Capacity, length), 0);
        return sb.ToString();
    }
}
