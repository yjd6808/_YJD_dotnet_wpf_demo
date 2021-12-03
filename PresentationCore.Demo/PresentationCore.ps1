[String]$ProjectPat = "src\Microsoft.DotNet.Wpf\src\PresentationCore\PresentationCore.csproj"
[String]$Platform = "x64"
[String]$Configuration = "Release"
[String]$VCToolsetVersion = "14.29.30133"

Set-Location -Path D:\dotnet\wpf
.\build.cmd -projects $ProjectPat -platform $Platform -c $Configuration /p:VCToolsVersion=$VCToolsetVersion
