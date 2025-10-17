using SharpDialogs.Structures;
using System.Text;

namespace SharpDialogs;

public sealed class SharpDialogFilter
{
    public SharpDialogFilter(string name, params string[] extensions)
        : this(name, (IEnumerable<string>)extensions)
    {
    }

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

    public string Name { get; }

    public IReadOnlyList<string> Extensions { get; }

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
