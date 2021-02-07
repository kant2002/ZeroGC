ZeroGC in C#
============

This is fun prototype for ZeroGC written in C#.

    dotnet publish ZeroGC\ZeroGC.csproj -c Release -r win-x64
    dotnet publish TestApp\TestApp.csproj -c Release -r win-x64

Now in separate Powershell session

    # Important to keep paths relative, since they are prepended to app folder.
    $env:COMPlus_GCName="..\..\..\..\..\..\ZeroGC\bin\Release\net5.0\win-x64\publish\ZeroGC.dll"
    cd TestApp\bin\Release\net5.0\win-x64\publish
    .\TestApp.exe

Debugging of the Custom GC loading process. Build Debug version of Runtime.

    $env:COMPLUS_LogEnable=1
    $env:COMPLUS_LOGLEVEL=6
    $env:COMPLUS_LogToFile=1
    $env:COMPLUS_LogFile=out.txt

Current problems
- If run under normal NativeAOT and `COMPlus_GCName` set, following process happens
    * Loaded CoreCLR
    * Loaded ZeroGC
    * Executed GC_VersionInfo
    * Inside GC_VersionInfo executed RhpReversePInvoke2 which trigger runtime initialization
    * During runtime initialization executed `GC_Initialize` defined in this library because it is linked instead of normal GC
    * `GC_Initialize` also has `RhpReversePInvoke2` call inside, so it's cycled.

- If run using mini-runtime version following compilation/dependencies problems happens:
    * Application cannot be compiled with existing bootstrapping methodologies.
    * Export does not produced if mini-runtime embedded into DLL project. Need separate mini-runtime.
    * `_DllMainCRTStartup` and `CoreRT_StaticInitialization` required to get rid of bootstrapperdll.lib which take all runtime into application.
