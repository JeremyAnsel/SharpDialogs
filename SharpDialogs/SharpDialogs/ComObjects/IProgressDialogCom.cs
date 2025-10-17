using SharpDialogs.Enumerations;
using System.Runtime.InteropServices;
using System.Security;

namespace SharpDialogs.ComObjects;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("ebbc7c04-315e-11d2-b62f-006097df5bd4")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[CoClass(typeof(ProgressDialogComClass))]
internal interface IProgressDialogCom
{
    void StartProgressDialog(
        [In] IntPtr hwndParent,
        [In] IntPtr punkEnableModless,
        [In] ProgressDialogOptions options,
        [In] IntPtr pvResevered
        );

    void StopProgressDialog(
        );

    void SetTitle(
        [In, MarshalAs(UnmanagedType.LPWStr)] string title
        );

    void SetAnimation(
        [In] IntPtr hInstAnimation,
        [In] uint idAnimation
        );

    [PreserveSig]
    [return: MarshalAs(UnmanagedType.Bool)]
    bool HasUserCancelled(
        );

    void SetProgress(
        [In] uint dwCompleted,
        [In] uint dwTotal
        );

    void SetProgress64(
        [In] ulong ullCompleted,
        [In] ulong ullTotal
        );

    void SetLine(
        [In] uint dwLineNum,
        [In, MarshalAs(UnmanagedType.LPWStr)] string pwzString,
        [In, MarshalAs(UnmanagedType.Bool)] bool fCompactPath,
        [In] IntPtr pvResevered
        );

    void SetCancelMsg(
        [In, MarshalAs(UnmanagedType.LPWStr)] string pwzCancelMsg,
        [In] IntPtr pvResevered
        );

    void Timer(
        [In] ProgressDialogTimerAction dwTimerAction,
        [In] IntPtr pvResevered
        );
}
