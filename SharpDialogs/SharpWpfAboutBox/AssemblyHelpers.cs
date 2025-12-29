using System.Reflection;

namespace SharpWpfAboutBox;

internal static class AssemblyHelpers
{
    public static string? GetDescription(Assembly? assembly)
    {
        return assembly?.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;
    }

    public static string? GetCompany(Assembly? assembly)
    {
        return assembly?.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company;
    }

    public static string? GetCopyright(Assembly? assembly)
    {
        return assembly?.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright;
    }

    public static string? GetInformationalVersion(Assembly? assembly)
    {
        return assembly?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
    }

    public static string? GetProduct(Assembly? assembly)
    {
        return assembly?.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
    }

    public static string? GetTitle(Assembly? assembly)
    {
        return assembly?.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;
    }

    public static Version? GetVersion(Assembly? assembly)
    {
        return assembly?.GetName()?.Version;
    }

    public static DateTime? GetReleaseDate(Assembly? assembly)
    {
        if (assembly is null)
        {
            return null;
        }

        string location = assembly.Location;
        DateTime date = System.IO.File.GetLastWriteTime(location);
        return date;
    }
}
