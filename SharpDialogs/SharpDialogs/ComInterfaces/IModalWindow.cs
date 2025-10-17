using SharpDialogs.Enumerations;
using System.Runtime.InteropServices;
using System.Security;

namespace SharpDialogs.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("b4db1657-70d7-485e-8e3e-6fcb5a5c1802")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IModalWindow
{
    [PreserveSig]
    HResult Show(
        [In] IntPtr hwndOwner
        );
}
