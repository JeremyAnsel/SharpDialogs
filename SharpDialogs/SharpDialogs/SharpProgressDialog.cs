using SharpDialogs.ComObjects;
using SharpDialogs.Enumerations;
using System.Runtime.InteropServices;

namespace SharpDialogs;

/// <summary>
/// A progress dialog.
/// </summary>
public class SharpProgressDialog : IDisposable
{
    private IProgressDialogCom? _dialog;

    /// <summary>
    /// Creates a progress dialog.
    /// </summary>
    /// <param name="hwndParent">The handle of the owner window.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="cancelMessage">The cancel message of the dialog.</param>
    /// <param name="allowCancel">Shows a cancel button.</param>
    /// <param name="showTime">Shows the progress time.</param>
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

    /// <summary>
    /// Disposes the dialog.
    /// </summary>
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

    /// <summary>
    /// Tests whether the user has cancelled the dialog.
    /// </summary>
    /// <returns>Returns whether the user has cancelled the dialog.</returns>
    /// <exception cref="ObjectDisposedException"></exception>
    public bool HasUserCancelled()
    {
        if (_dialog is null)
        {
            throw new ObjectDisposedException(nameof(_dialog));
        }

        return _dialog.HasUserCancelled();
    }

    /// <summary>
    /// Sets the progress of the dialog.
    /// </summary>
    /// <param name="completed">The completed value.</param>
    /// <param name="total">The total value.</param>
    /// <exception cref="ObjectDisposedException"></exception>
    public void SetProgress(ulong completed, ulong total)
    {
        if (_dialog is null)
        {
            throw new ObjectDisposedException(nameof(_dialog));
        }

        _dialog.SetProgress64(completed, total);
    }

    /// <summary>
    /// Sets the text of the first line of the dialog.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="compactPath">A value indicating whether the line is a path to compact.</param>
    /// <exception cref="ObjectDisposedException"></exception>
    public void SetLine1(string text, bool compactPath = false)
    {
        if (_dialog is null)
        {
            throw new ObjectDisposedException(nameof(_dialog));
        }

        _dialog.SetLine(1, text, compactPath, IntPtr.Zero);
    }

    /// <summary>
    /// Sets the text of the second line of the dialog.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="compactPath">A value indicating whether the line is a path to compact.</param>
    /// <exception cref="ObjectDisposedException"></exception>
    public void SetLine2(string text, bool compactPath = false)
    {
        if (_dialog is null)
        {
            throw new ObjectDisposedException(nameof(_dialog));
        }

        _dialog.SetLine(2, text, compactPath, IntPtr.Zero);
    }

    /// <summary>
    /// Resets the progress timer.
    /// </summary>
    /// <exception cref="ObjectDisposedException"></exception>
    public void ResetTimer()
    {
        if (_dialog is null)
        {
            throw new ObjectDisposedException(nameof(_dialog));
        }

        _dialog.Timer(ProgressDialogTimerAction.Reset, IntPtr.Zero);
    }

    /// <summary>
    /// Pauses the progress timer.
    /// </summary>
    /// <exception cref="ObjectDisposedException"></exception>
    public void PauseTimer()
    {
        if (_dialog is null)
        {
            throw new ObjectDisposedException(nameof(_dialog));
        }

        _dialog.Timer(ProgressDialogTimerAction.Pause, IntPtr.Zero);
    }

    /// <summary>
    /// Resumes the progress timer.
    /// </summary>
    /// <exception cref="ObjectDisposedException"></exception>
    public void ResumeTimer()
    {
        if (_dialog is null)
        {
            throw new ObjectDisposedException(nameof(_dialog));
        }

        _dialog.Timer(ProgressDialogTimerAction.Resume, IntPtr.Zero);
    }
}
