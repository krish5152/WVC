Write-Host "Detecting installed IDEs and checking SonarLint installation."

# Define paths to check for each IDE
$idePaths = @{
    "vscode"        = "$env:USERPROFILE\.vscode\extensions\sonarsource.sonarlint-vscode*"
    "intellij"      = "$env:APPDATA\JetBrains\sonarlint*"
    "eclipse"       = "$env:USERPROFILE\eclipse\plugins\org.sonarlint.eclipse*"
    "visualstudio"  = "$env:LOCALAPPDATA\Microsoft\VisualStudio\SonarLint.VisualStudio*.dll"
}

$found = $false

foreach ($ide in $idePaths.Keys) {
    $path = $idePaths[$ide]
    Write-Host "Checking for $ide..."
    if (Test-Path -Path $path) {
        Write-Host "SonarLint is installed for $ide."
        $found = $true
    } else {
        Write-Host "SonarLint is not installed for $ide."
    }
}

if (-not $found) {
    Write-Host "ERROR: No IDE with SonarLint installed was detected. Please install SonarLint in your IDE to proceed."
    exit 1
}
