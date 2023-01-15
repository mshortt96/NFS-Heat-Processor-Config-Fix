# Need For Speed Heat Processor Config Fix
Need For Speed Heat's PC port is notorious for being extremely CPU-intensive, often utilizing 100% of the chip and causing dangerous temperatures. The only solution to this is to modify the game's "user.cfg" folder with your CPU specs, and cap the game's FPS to 60.

This automated console tool for Windows achieves the former. It will determine your CPU's physical and logical cores and generate a corresponding "user.cfg" file. Before generation it will scan for your NFS Heat installation directory and ultimately place the file there; if an installation can't be found it will simply create the file in the same location as the tool's EXE. Should an existing file be found, it will be backed up with the name "user (backup).cfg".


## Technical Notes
- The EXE's size is a known issue. The program relies on Windows Management Instrumentation, which breaks when the assembly is trimmed:
  https://github.com/dotnet/core/issues/7051
  
  One solution would be to release a separate version of the tool that is not self-contained (the user's machine would need .NET installed), but this is not ideal.
