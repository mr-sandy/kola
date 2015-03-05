New-Item -ItemType Directory -Force -Path kola-plugins-core\lib\net40
remove-item kola-plugins-core\lib\net40\*
Copy-Item  ..\Plugins\Kola.Plugins.Core\bin\debug\Kola.Plugins.Core.dll kola-plugins-core\lib\net40\
