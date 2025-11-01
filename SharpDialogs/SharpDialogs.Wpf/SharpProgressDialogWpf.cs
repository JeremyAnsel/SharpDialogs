using System.Windows;

namespace SharpDialogs.Wpf;

/// <summary>
/// A progress dialog for WPF.
/// </summary>
public class SharpProgressDialogWpf : SharpProgressDialog
{
    /// <summary>
    /// Creates a progress dialog.
    /// </summary>
    /// <param name="owner">The owner window.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="cancelMessage">The cancel message of the dialog.</param>
    /// <param name="allowCancel">Shows a cancel button.</param>
    /// <param name="showTime">Shows the progress time.</param>
    public SharpProgressDialogWpf(Window? owner, string? title, string? cancelMessage = null, bool allowCancel = true, bool showTime = true)
        : base(Helpers.GetHWndForWindow(owner), title, cancelMessage, allowCancel, showTime)
    {
    }
}
