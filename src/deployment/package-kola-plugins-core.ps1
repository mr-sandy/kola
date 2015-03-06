# ensure directories exist
New-Item -ItemType Directory -Force -Path Kola.Plugins.Core\lib\net40
New-Item -ItemType Directory -Force -Path .\packages

# copy dlls
remove-item Kola.Plugins.Core\lib\net40\*
Copy-Item  ..\Plugins\Kola.Plugins.Core\bin\debug\Kola.Plugins.Core.dll Kola.Plugins.Core\lib\net40\

# package
.\NuGet.exe pack .\Kola.Plugins.Core\Kola.Plugins.Core.nuspec -OutputDirectory .\packages
