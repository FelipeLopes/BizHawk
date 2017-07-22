BizHawk is a multi-system emulator written in C#. BizHawk provides nice features for casual gamers such as fullscreen, rewind, and joypad support in addition to rerecording and debugging tools for all system cores.

[Release Notes](http://tasvideos.org/Bizhawk/ReleaseHistory.html)

[Here](http://tasvideos.org/Bizhawk/Features.html) is a list of features offered by bizhawk.

## Linux version
This is a highly experimental Linux version of the main BizHawk repo.
Requirements for Build
Mono version 5 or higher
Monodevelop version 6 or higher
libgdiplus 5.4 (no package available right now, download the source and compile it)
OpenGL and OpenAL libraries
NVidia's CG compiler version 3.1 April 2012

To build it, clone the repository fetching SVN information (only HEAD is enough, no need to sync the entire SVN history):
$ git svn clone https://github.com/FelipeLopes/BizHawk.git/branches/mono-portable --revision HEAD

After that, generate the C# source containing the SVN version
$ cd mono-portable/Version
$ sh subwcrev.sh .

Copy NVidia's binary cgc to the output64/dll folder. If you extracted cgc to the home folder and also cloned the repo there,
the command is

$ cp ~/cgc ~/mono-portable/output64/dll/cgc

Now, open mono-develop and build MonoMacWrapper.sln, only the 64-bit version has been tested. The program will build
to the output64 folder, and you can run it with

$ mono ~/mono-portable/output64/EmuHawk.exe

Currently, only the C# frontend builds, so you can load ROMs, but there are no cores to run them.

## Known issues

The program sometimes crashes when windows are closed. Probably because of race conditions in the Dispose() methods. If
your desktop environment freezes because of the program, just change to a TTY session with Ctrl+Alt+F2 and reboot
the system.

## Download Binaries

Windows users, don't forget to run the [prereq installer](http://github.com/TASVideos/BizHawk-Prereqs/releases) first!

Release binaries can be found on [on github](http://github.com/TASVideos/BizHawk/releases)

[Developer build](https://ci.appveyor.com/project/zeromus/bizhawk-udexo/build/artifacts) of the most recent commit

## Supported Systems

 * Nintendo Entertainment System / Famicom / Famicom Disk System (NES/FDS)
 * Super Nintendo (SNES)
 * Nintendo 64
 * Game Boy, Game Boy Color, and Super Game Boy
 * Game Boy Advance
 * Sony PlayStation
 * Sega Master System, Game Gear, and SG-1000
 * Sega Genesis / Sega-CD
 * Sega Saturn
 * PC-Engine (TurboGrafx-16) / CD-ROM & SuperGrafx 
 * Atari 2600
 * Atari 7800
 * Atari Lynx
 * ColecoVision
 * TI-83 Calculator
 * Wonderswan and Wonderswan Color 
 * Apple II

## Resources

[BizHawk homepage](http://tasvideos.org/Bizhawk.html) 

[FAQ](http://tasvideos.org/Bizhawk/FAQ.html) - Frequently Asked Questions / Troubleshooting

[Compiling](http://tasvideos.org/Bizhawk/Compiling.html) - What is needed to compile BizHawk src

[CompactDiscInfoDump](http://tasvideos.org/Bizhawk/CompactDiscInfoDump.html) - A concise explanation of compact disc CDs, gathered for the first time EVER in one location, and mostly inaccurate

[Rerecording](http://tasvideos.org/Bizhawk/Rerecording.html) - (Work in progress) - Documentation of the rerecording implementation of  BizHawk
 * [TAS movie file format](http://tasvideos.org/Bizhawk/TASFormat.html) - Mnemonic patterns for each platform for .tas (input) files.

[Commandline](http://tasvideos.org/Bizhawk/CommandLine.html) - Documentation of the command line options in BizHawk 
