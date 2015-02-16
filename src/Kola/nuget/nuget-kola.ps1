.\NuGet.exe spec -f -AssemblyPath ..\bin\Debug\Kola.dll
.\NuGet.exe pack Kola.nuspec
.\NuGet.exe setApiKey C33FB0EC-F395-4EDC-87ED-48F644AC5457 -Source http://code.it.linn.co.uk
.\NuGet.exe push .\Kola.*.nupkg C33FB0EC-F395-4EDC-87ED-48F644AC5457 -s http://code.it.linn.co.uk