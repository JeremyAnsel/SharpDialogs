using System.Reflection;
using System.Windows.Media;

namespace SharpWpfAboutBox;

/// <summary>
/// Contains the assembly properties.
/// </summary>
public class AppProperties
{
    private Assembly? AppAssembly => Assembly.GetEntryAssembly();

    /// <summary>
    /// The description.
    /// </summary>
    public string Description => AssemblyHelpers.GetDescription(AppAssembly) ?? string.Empty;

    /// <summary>
    /// The company.
    /// </summary>
    public string Company => AssemblyHelpers.GetCompany(AppAssembly) ?? string.Empty;

    /// <summary>
    /// The copyright.
    /// </summary>
    public string Copyright => AssemblyHelpers.GetCopyright(AppAssembly) ?? string.Empty;

    /// <summary>
    /// The informational version.
    /// </summary>
    public string InformationalVersion => AssemblyHelpers.GetInformationalVersion(AppAssembly) ?? string.Empty;

    /// <summary>
    /// The product.
    /// </summary>
    public string Product => AssemblyHelpers.GetProduct(AppAssembly) ?? string.Empty;

    /// <summary>
    /// The title.
    /// </summary>
    public string Title => AssemblyHelpers.GetTitle(AppAssembly) ?? string.Empty;

    /// <summary>
    /// The version.
    /// </summary>
    public Version? Version => AssemblyHelpers.GetVersion(AppAssembly);

    /// <summary>
    /// The icon.
    /// </summary>
    public ImageSource? Icon => IconExtractor.GetAppIcon(AppAssembly);
}
