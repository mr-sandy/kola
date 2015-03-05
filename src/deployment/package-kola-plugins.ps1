New-Item -ItemType Directory -Force -Path .\packages
.\NuGet.exe pack .\kola-plugins-core\Kola.Plugins.Core.nuspec -OutputDirectory .\packages
