using SharpDialogs.Enumerations;
using SharpDialogs.Structures;
using System.Runtime.InteropServices;
using System.Security;

namespace SharpDialogs.ComInterfaces;

/// <remarks>Inherited from <see cref="IModalWindow"/></remarks>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("42f85136-db7e-439c-85f1-e4075d135fc8")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IFileDialog
{
    [PreserveSig]
    HResult Show(
        [In] IntPtr hwndOwner
        );

    [PreserveSig]
    HResult SetFileTypes(
        [In] uint cFileTypes,
        [In, MarshalAs(UnmanagedType.LPArray)] FilterSpec[] rgFilterSpec
        );

    [PreserveSig]
    HResult SetFileTypeIndex(
        [In] uint iFileType
        );

    [PreserveSig]
    HResult GetFileTypeIndex(
        [Out] out uint piFileType
        );

    void Advise();

    void Unadvise();

    [PreserveSig]
    HResult SetOptions(
        [In] FileOpenOptions fos
        );

    [PreserveSig]
    HResult GetOptions(
        [Out] out FileOpenOptions pfos
        );

    [PreserveSig]
    HResult SetDefaultFolder(
        [In] IShellItem psi
        );

    [PreserveSig]
    HResult SetFolder(
        [In] IShellItem psi
        );

    [PreserveSig]
    HResult GetFolder(
        [Out] out IShellItem ppsi
        );

    [PreserveSig]
    HResult GetCurrentSelection(
        [Out] out IShellItem ppsi
        );

    HResult SetFileName(
        [In, MarshalAs(UnmanagedType.LPWStr)] string pszName
        );

    [PreserveSig]
    HResult GetFileName(
        [Out, MarshalAs(UnmanagedType.LPWStr)] out string pszName
        );

    [PreserveSig]
    HResult SetTitle(
        [In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle
        );

    [PreserveSig]
    HResult SetOkButtonLabel(
        [In, MarshalAs(UnmanagedType.LPWStr)] string pszText
        );

    [PreserveSig]
    HResult SetFileNameLabel(
        [In, MarshalAs(UnmanagedType.LPWStr)] string pszLabel
        );

    [PreserveSig]
    HResult GetResult(
        [Out] out IShellItem ppsi
        );

    [PreserveSig]
    HResult AddPlace(
        [In] IShellItem psi,
        [In] int fdap
        );

    [PreserveSig]
    HResult SetDefaultExtension(
        [In] string pszDefaultExtension
        );

    [PreserveSig]
    HResult Close(
        [In] HResult hr
        );

    [PreserveSig]
    HResult SetClientGuid(
        [In] in Guid guid);

    [PreserveSig]
    HResult ClearClientData();

    void SetFilter();
}
