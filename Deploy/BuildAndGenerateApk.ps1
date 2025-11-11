$solutionDirectory = "F:\Work\ApocalypseNow"
$path = "$solutionDirectory\ApocalypseNow\bin\Release\net9.0-android\publish"

Write-Host "Cleaning...";
if (Test-Path $path) {
    Remove-Item -Path "$path\*" -Recurse -Force -ErrorAction SilentlyContinue
}

Write-Host ".NET Publishing...";
Set-Location $solutionDirectory
$currentDirectory = Get-Location
Write-Host "$currentDirectory"
$project = "$solutionDirectory\ApocalypseNow\ApocalypseNow.csproj"
Write-Host ".NET Publishing project: $project ..."
dotnet publish $project -c Release -f net9.0-android /p:AndroidPackageFormat=aab /p:BundleLocalization=en-GB /p:LocalizationCulture=en-GB
#dotnet publish "$solutionDirectory\ApocalypseNow.sln" -c Release -f net9.0-android /p:BundleLocalization=en-GB /p:LocalizationCulture=en-GB

Write-Host "Searching generated APK..."

if (-not (Test-Path -Path $path))
{
    Write-Host "Not found: $path";
	$path = Get-Location
    Write-Host "Changing to: $path";
}

$apkPath = Get-ChildItem -Path "$path\*-Signed.apk" | Select-Object -ExpandProperty FullName

Write-Host "APK generated at: $apkPath"
return $apkPath