using SharpDialogs.Enumerations;
using System.Runtime.InteropServices;
using System.Security;

namespace SharpDialogs.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("b63ea76d-1f85-456f-a19c-48159efa858b")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IShellItemArray
{
    void BindToHandler();

    void GetPropertyStore();

    void GetPropertyDescriptionList();

    void GetAttributes();

    [PreserveSig]
    HResult GetCount(
        [Out] out uint pdwNumItems
        );

    [PreserveSig]
    HResult GetItemAt(
        [In] uint dwIndex,
        [Out] out IShellItem ppsi
        );

    void EnumItems();
}
