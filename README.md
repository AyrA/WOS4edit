# WOS4edit

World of subways 4 savegame editor

This application allows you to edit your "World of Subways 4 - New York" savegame file.

## Usage

Launch WOS4edit.exe from the bin/release directory
or compile it yourself using C# and .NET 2.0.

Open your savegame, this is located in your Documents folder in a subdirectory called
```WOS4 - New York```. The name of the file is ```SaveGame.save```.
The file open dialog defaults to this directory, but you can switch to any other, if you want to.

Feel free to change any settings in the file,
but please create a backup copy of your save before using this application.

## help.txt

The file ```help.txt```, which is located in the same directory as the exe file is optional.
It contains some help regarding the settings.


## Editing Waring

This application will not check, if your input is valid,
apart from checking if your input is in the accepted range of the data type.

For example you can change your score to 1337.0815,
but the game expects this from being between 0 and 100,
or set the number of schedules as beginner to 50, but the total counter to 15.
It is up to you to validate your input.

## Compilation Warning

The precompiled binary is signed by myself to prevent it from being altered.
If you compile it yourself you will also overwrite the signature.
Signing is optional, but recommended if you distribute the file.

## Open Tasks

- Allow the user to add and remove settings
- provide a settings manager so the user can have multiple "profiles"
- Find out, what the unknown values do (Block99 wtf?!)
- Find out the accepted range of values and what happens, if you are outside of this range.
