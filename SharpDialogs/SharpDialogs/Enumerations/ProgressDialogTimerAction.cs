namespace SharpDialogs.Enumerations;

internal enum ProgressDialogTimerAction : uint
{
    /// <summary>
    /// None.
    /// </summary>
    None = 0,

    /// <summary>
    /// Reset the timer so the progress will be calculated from now until the first SetProgress() is called so those this time will correspond to the values passed to SetProgress(). Only do this before SetProgress() is called.
    /// </summary>
    Reset = 0x00000001,

    /// <summary>
    /// Progress has been suspended.
    /// </summary>
    Pause = 0x00000002,

    /// <summary>
    /// Progress has resumed.
    /// </summary>
    Resume = 0x00000003,
}
