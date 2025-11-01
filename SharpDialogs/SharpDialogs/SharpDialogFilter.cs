using SharpDialogs.Structures;
using System.Text;

namespace SharpDialogs;

/// <summary>
/// A files filter for the dialogs.
/// </summary>
public sealed class SharpDialogFilter
{
    /// <summary>
    /// Creates a dialog file filter.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="extensions">The extensions.</param>
    public SharpDialogFilter(string name, params string[] extensions)
        : this(name, (IEnumerable<string>)extensions)
    {
    }

    /// <summary>
    /// Creates a dialog file filter.
    /// </summary>
    /// <param name="name">The names.</param>
    /// <param name="extensions">The extensions.</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public SharpDialogFilter(string name, IEnumerable<string> extensions)
    {
        Name = name.Trim();

        if (string.IsNullOrEmpty(Name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        Extensions = [.. extensions
            .Select(t => t.Trim())
            .Where(t => !string.IsNullOrEmpty(t))];

        if (Extensions.Count == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(extensions));
        }
    }

    /// <summary>
    /// Gets the name of the filter.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the extensions of the filter.
    /// </summary>
    public IReadOnlyList<string> Extensions { get; }

    /// <summary>
    /// Returns the filter as a string.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append(Name);
        sb.Append(' ');
        sb.Append('(');

        for (int i = 0; i < Extensions.Count; i++)
        {
            if (i > 0)
            {
                sb.Append(',');
            }

            sb.Append("*.");
            sb.Append(Extensions[i]);
        }

        sb.Append(')');

        return sb.ToString();
    }

    /// <summary>
    /// Creates filters from a string.
    /// </summary>
    /// <param name="windowsFilter">The filter string.</param>
    /// <returns>Returns the filters.</returns>
    public static IReadOnlyList<SharpDialogFilter> ParseWindowsFilter(string windowsFilter)
    {
        if (string.IsNullOrWhiteSpace(windowsFilter))
        {
            return [];
        }

        string[] items = windowsFilter.Split(['|'], StringSplitOptions.RemoveEmptyEntries);

        if (items.Length % 2 != 0)
        {
            return [];
        }

        SharpDialogFilter[] filters = new SharpDialogFilter[items.Length / 2];

        for (int i = 0; i < items.Length; i += 2)
        {
            string itemName = items[i];
            string itemExtensions = items[i + 1];
            string[] extensions = itemExtensions.Split([';'], StringSplitOptions.RemoveEmptyEntries);
            filters[i / 2] = new SharpDialogFilter(itemName, extensions);
        }

        return filters;
    }

    internal FilterSpec ToFilterSpec()
    {
        var sb = new StringBuilder();

        for (int i = 0; i < Extensions.Count; i++)
        {
            if (i > 0)
            {
                sb.Append(';');
            }

            sb.Append("*.");
            sb.Append(Extensions[i]);
        }

        string filter = sb.ToString();
        return new FilterSpec(Name, filter);
    }
}
