namespace SharpDialogs.Enumerations;

[Flags]
internal enum FileOpenOptions : uint
{
    None = 0,

    OverwritePrompt = 0x00000002, // (on by default in the save dialog)

    StrictFileTypes = 0x00000004, // In the save dialog, only allow the user to choose a file that has
                                  // one of the file extensions provided in SetFileTypes.

    NoChangeDir = 0x00000008, // Don't change the current working directory

    PickFolders = 0x00000020, // Invoke the open dialog in folder picking mode.

    ForceFileSystem = 0x00000040, // Ensure that items returned are filesystem items.

    AllNonStorageItems = 0x00000080, // Allow choosing items that have no storage.

    NoValidate = 0x00000100,

    AllowMultiselect = 0x00000200,

    PathMustExist = 0x00000800, // (on by default)

    FileMustExist = 0x00001000, // (on by default in the open dialog and folder picker)

    CreatePrompt = 0x00002000,

    ShareAware = 0x00004000,

    NoReadOnlyReturn = 0x00008000, // (on by default in the save dialog)

    NoTestFileCreate = 0x00010000, // Avoid testing the creation of the chosen file in the save dialog
                                   // (specifying this flag will circumvent some useful error handling, such as access denied)

    HideMruPlaces = 0x00020000, // (not used in Win7)

    HidePinnedPlaces = 0x00040000, // Don't display the standard namespace locations in the navigation pane.
                                   // (generally used along with AddPlace)

    NoDereferenceLinks = 0x00100000, // Don't treat shortcuts as their target files.

    OkButtonNeedsInteraction = 0x00200000, // Only enable the OK button if the user has done something in the view.

    DontAddToRecent = 0x02000000, // Don't add the chosen file to the recent documents list (SHAddToRecentDocs)

    ForceShowHidden = 0x10000000, // Show all files including system and hidden files.

    DefaultNoMiniMode = 0x20000000, // (not used in Win7)

    ForcePreviewPaneOn = 0x40000000,

    SupportStreamableItems = 0x80000000, // Indicates the caller will use BHID_Stream to open contents, no need to download the file
}
