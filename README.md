# SharpDialogs

SharpDialogs is a .Net library for win32 dialogs. Include FileOpenDialog, FileSaveDialog, FolderBrowserDialog, ProgressDialog.

[![NuGet Version](https://img.shields.io/nuget/v/SharpDialogs)](https://www.nuget.org/packages/SharpDialogs)
![License](https://img.shields.io/github/license/JeremyAnsel/SharpDialogs)

Description     | Value
----------------|----------------
License         | [The MIT License (MIT)](https://github.com/JeremyAnsel/SharpDialogs/blob/main/LICENSE)
Documentation   | http://jeremyansel.github.io/SharpDialogs
Source code     | https://github.com/JeremyAnsel/SharpDialogs
Nuget           | https://www.nuget.org/packages/SharpDialogs
Build           | https://ci.appveyor.com/project/JeremyAnsel/sharpdialogs/branch/main

# Usage

## `SharpFileOpenDialog`:
```csharp
using SharpDialogs;

// Select a single file
string? result = SharpFileOpenDialog.ShowSingleSelect(hWndOwner, "Title", "C:\Initial\Directory\");

// Allow multiple files
IReadOnlyList<string>? result = SharpFileOpenDialog.ShowMultiSelect(hWndOwner, "Title", "C:\Initial\Directory\");
```

## `SharpFileSaveDialog`:
```csharp
using SharpDialogs;

string? result = SharpFileSaveDialog.Show(hWndOwner, "Title", "C:\Initial\Directory\");
```

## `SharpFolderBrowserDialog`:
```csharp
using SharpDialogs;

// Select a single folder
string? result = SharpFolderBrowserDialog.ShowSingleSelect(hWndOwner, "Title", "C:\Initial\Directory\");

// Allow multiple folder
IReadOnlyList<string>? result = SharpFolderBrowserDialog.ShowMultiSelect(hWndOwner, "Title", "C:\Initial\Directory\");
```

## `SharpProgressDialog`:
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
