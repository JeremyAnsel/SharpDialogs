using SharpDialogs.Enumerations;
using System.Runtime.InteropServices;
using System.Security;

namespace SharpDialogs.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IShellItem
{
    void BindToHandler();

    [PreserveSig]
    HResult GetParent(
        [Out] out IShellItem ppsi
        );

    [PreserveSig]
    HResult GetDisplayName(
        [In] uint sigdnName,
        [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszName);

    void GetAttributes();

    void Compare();
}
