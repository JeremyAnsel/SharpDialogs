namespace SharpDialogs.Enumerations;

[Flags]
internal enum ProgressDialogOptions : uint
{
    /// <summary>
    /// Default normal progress dlg behavior.
    /// </summary>
    Normal = 0x00000000,

    /// <summary>
    /// The dialog is modal to its hwndParent (default is modeless).
    /// </summary>
    Modal = 0x00000001,

    /// <summary>
    /// Automatically updates the "Line3" text with the "time remaining" (you cant call SetLine3 if you passs this!).
    /// </summary>
    AutoTime = 0x00000002,

    /// <summary>
    /// Don't show the "time remaining" if this is set. We need this if dwTotal &lt; dwCompleted for sparse files.
    /// </summary>
    NoTime = 0x00000004,

    /// <summary>
    /// Do not have a minimize button in the caption bar.
    /// </summary>
    NoMinimize = 0x00000008,

    /// <summary>
    /// Don't display the progress bar.
    /// </summary>
    NoProgressBar = 0x00000010,

    /// <summary>
    /// Use marquee progress (comctl32 v6 required).
    /// </summary>
    MarqueeProgress = 0x00000020,

    /// <summary>
    /// No cancel button (operation cannot be canceled) (use sparingly)
    /// </summary>
    NoCancel = 0x00000040,
}
