New-Item -ItemType Directory -Force -Path .\packages
.\NuGet.exe pack .\kola\Kola.nuspec -OutputDirectory .\packages
