using SharpDialogs.ComObjects;
using SharpDialogs.Enumerations;
using System.Runtime.InteropServices;

namespace SharpDialogs;

public class SharpProgressDialog : IDisposable
{
    private IProgressDialogCom? _dialog;

    public SharpProgressDialog(IntPtr hwndParent, string? title, string? cancelMessage = null, bool allowCancel = true, bool showTime = true)
    {
        DpiHelpers.SetDpiAware();
        _dialog = new();

        ProgressDialogOptions options = ProgressDialogOptions.NoMinimize;

        if (!allowCancel)
        {
            options |= ProgressDialogOptions.NoCancel;
        }

        if (showTime)
        {
            options |= ProgressDialogOptions.AutoTime;
        }
        else
        {
            options |= ProgressDialogOptions.NoTime;
        }

        if (title is not null)
        {
            _dialog.SetTitle(title);
        }

        _dialog.StartProgressDialog(hwndParent, IntPtr.Zero, options, IntPtr.Zero);

        if (cancelMessage is not null)
        {
            _dialog.SetCancelMsg(cancelMessage, IntPtr.Zero);
        }
    }

    public void Dispose()
    {
        if (_dialog is not null)
        {
            _dialog.StopProgressDialog();
            Marshal.ReleaseComObject(_dialog);
            _dialog = null;
        }

        GC.SuppressFinalize(this);
    }

    public bool HasUserCancelled()
    {
        if (_dialog is null)
        {
            throw new ObjectDisposedException(nameof(_dialog));
        }

        return _dialog.HasUserCancelled();
    }

    public void SetProgress(ulong completed, ulong total)
    {
        if (_dialog is null)
        {
            throw new ObjectDisposedException(nameof(_dialog));
        }

        _dialog.SetProgress64(completed, total);
    }

    public void SetLine1(string text, bool compactPath = false)
    {
        if (_dialog is null)
        {
            throw new ObjectDisposedException(nameof(_dialog));
        }

        _dialog.SetLine(1, text, compactPath, IntPtr.Zero);
    }

    public void SetLine2(string text, bool compactPath = false)
    {
        if (_dialog is null)
        {
            throw new ObjectDisposedException(nameof(_dialog));
        }

        _dialog.SetLine(2, text, compactPath, IntPtr.Zero);
    }

    public void ResetTimer()
    {
        if (_dialog is null)
        {
            throw new ObjectDisposedException(nameof(_dialog));
        }

        _dialog.Timer(ProgressDialogTimerAction.Reset, IntPtr.Zero);
    }

    public void PauseTimer()
    {
        if (_dialog is null)
        {
            throw new ObjectDisposedException(nameof(_dialog));
        }

        _dialog.Timer(ProgressDialogTimerAction.Pause, IntPtr.Zero);
    }

    public void ResumeTimer()
    {
        if (_dialog is null)
        {
            throw new ObjectDisposedException(nameof(_dialog));
        }

        _dialog.Timer(ProgressDialogTimerAction.Resume, IntPtr.Zero);
    }
}
