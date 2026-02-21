using System.Runtime.InteropServices;
using System.Security;

namespace SharpDialogs.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface ITaskbarList3
{
    [PreserveSig]
    void HrInit();

    [PreserveSig]
    void AddTab(IntPtr hwnd);

    [PreserveSig]
    void DeleteTab(IntPtr hwnd);

    [PreserveSig]
    void ActivateTab(IntPtr hwnd);

    [PreserveSig]
    void SetActiveAlt(IntPtr hwnd);

    [PreserveSig]
    void MarkFullscreenWindow(
        IntPtr hwnd,
        [MarshalAs(UnmanagedType.Bool)] bool fFullscreen
        );

    [PreserveSig]
    void SetProgressValue(
        IntPtr hwnd,
        ulong ullCompleted,
        ulong ullTotal);

    [PreserveSig]
    void SetProgressState(
        IntPtr hwnd,
        SharpTaskbarStates state);
}
