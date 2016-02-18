$ScriptPath = Split-Path $MyInvocation.InvocationName

remove-item .\packages\*

& "$ScriptPath\package-kola-application.ps1"
& "$ScriptPath\package-kola-core.ps1"
& "$ScriptPath\package-kola-plugins-core.ps1"
& "$ScriptPath\publish-all.ps1"
