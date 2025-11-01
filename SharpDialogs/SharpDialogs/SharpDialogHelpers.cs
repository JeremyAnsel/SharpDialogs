using System.Text;

namespace SharpDialogs;

/// <summary>
/// Helper methods for the dialogs.
/// </summary>
public static class SharpDialogHelpers
{
    /// <summary>
    /// Converts a numeric value into a string that represents the number expressed as a size value in bytes, kilobytes, megabytes, or gigabytes, depending on the size.
    /// </summary>
    /// <param name="filesize">The numeric value to be converted.</param>
    /// <returns>Returns the converted string.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
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

    /// <summary>
    /// Truncates a path to fit within a certain number of characters by replacing path components with ellipses.
    /// </summary>
    /// <param name="path">The path to be altered.</param>
    /// <param name="length">The maximum number of characters to be contained in the new string.</param>
    /// <returns>Returns the new string.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
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
