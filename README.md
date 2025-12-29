# SharpDialogs

SharpDialogs is a .Net library for win32 dialogs. Include FileOpenDialog, FileSaveDialog, FolderBrowserDialog, ProgressDialog.
SharpWpfAboutBox is a .Net AboutBox dialog for WPF.

[![Build status](https://ci.appveyor.com/api/projects/status/6bktd0k9pe762ren/branch/main?svg=true)](https://ci.appveyor.com/project/JeremyAnsel/sharpdialogs/branch/main)
[![NuGet Version](https://img.shields.io/nuget/v/SharpDialogs)](https://www.nuget.org/packages/SharpDialogs)
![License](https://img.shields.io/github/license/JeremyAnsel/SharpDialogs)

Description     | Value
----------------|----------------
License         | [The MIT License (MIT)](https://github.com/JeremyAnsel/SharpDialogs/blob/main/LICENSE)
Documentation   | http://jeremyansel.github.io/SharpDialogs
Source code     | https://github.com/JeremyAnsel/SharpDialogs
Nuget           | https://www.nuget.org/packages/SharpDialogs
Nuget           | https://www.nuget.org/packages/SharpWpfAboutBox
Build           | https://ci.appveyor.com/project/JeremyAnsel/sharpdialogs/branch/main

# Usage

## `SharpFileOpenDialog`:
To open a FileOpen dialog, use the `SharpFileOpenDialog` static class. You can allow only a single file selection or allow multiple files selection.
```csharp
using SharpDialogs;

// Select a single file
string? result = SharpFileOpenDialog.ShowSingleSelect(hWndOwner, "Title", "C:\Initial\Directory\");

// Allow multiple files
IReadOnlyList<string>? result = SharpFileOpenDialog.ShowMultiSelect(hWndOwner, "Title", "C:\Initial\Directory\");
```

## `SharpFileSaveDialog`:
To open a FileSave dialog, use the `SharpFileSaveDialog` static class.
```csharp
using SharpDialogs;

string? result = SharpFileSaveDialog.Show(hWndOwner, "Title", "C:\Initial\Directory\");
```

## `SharpFolderBrowserDialog`:
To open a FolderBrowser dialog, use the `SharpFolderBrowserDialog` static class. You can allow only a single folder selection or allow multiple folders selection.
```csharp
using SharpDialogs;

// Select a single folder
string? result = SharpFolderBrowserDialog.ShowSingleSelect(hWndOwner, "Title", "C:\Initial\Directory\");

// Allow multiple folder
IReadOnlyList<string>? result = SharpFolderBrowserDialog.ShowMultiSelect(hWndOwner, "Title", "C:\Initial\Directory\");
```

## `SharpProgressDialog`:
To show a Progress dialog, use the `SharpProgressDialog` class. The dialog is closed when the class object is disposed.
There is an option to show the remaining time.
```csharp
using SharpDialogs;

using var dialog = new SharpProgressDialog(hWndOwner, "My Slow Operation", "Please wait while the current operation is cleaned up", true);

uint complete = 0;
uint total = 1000;

dialog.ResetTimer();
dialog.SetProgress(complete, total);

for (uint index = 0; index < total; index++)
{
    if (dialog.HasUserCancelled())
    {
        break;
    }

    dialog.SetLine1("Header");
    dialog.SetLine2("I'm processing item " + (index + 1));

    Thread.Sleep(100);
    complete++;

    dialog.SetProgress(complete, total);
}
```

## `SharpInputBox`:

To prompt a InputBox dialog, use the `SharpInputBox` static class.
```csharp
using SharpDialogs;

string text = SharpInputBox.Show("Enter a message", "Title", "Default response");
```

## `SharpAboutBox`

To show a AboutBox dialog, use the `SharpAboutBox` class.
```csharp
using SharpWpfAboutBox;

new SharpAboutBox(this).ShowDialog();
```
