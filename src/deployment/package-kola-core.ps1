# ensure directories exist
New-Item -ItemType Directory -Force -Path Kola.Core\lib\net40
New-Item -ItemType Directory -Force -Path .\packages

# copy dlls
remove-item Kola.Core\lib\net40\*
Copy-Item  ..\Kola.Domain\bin\debug\Kola.Domain.dll Kola.Core\lib\net40\
Copy-Item  ..\Kola.Configuration\bin\debug\Kola.Configuration.dll Kola.Core\lib\net40\

# package
.\NuGet.exe pack .\Kola.Core\Kola.Core.nuspec -OutputDirectory .\packages
