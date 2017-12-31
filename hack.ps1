# Initialize
$workpath = Split-Path -Parent $MyInvocation.MyCommand.Definition
cd $workpath

do {
    Write-Host "Ready Go!"
    # Capture screenshot
    
    copy screenshot-2.png screenshot-3.png
    copy screenshot-1.png screenshot-2.png
    copy screenshot.png screenshot-1.png
    Write-Host "Captrue......"
    sh cap.sh
    Write-Host "Captrued"

    .\PictureProcess\PictureProcess\obj\Release\PictureProcess.exe .\screenshot.png
    # swipe
    adb shell input swipe 500 1700 500 1700 $LASTEXITCODE
    #adb shell input swipe 0 0 0 0 $LASTEXITCODE
    Start-Sleep -Seconds 1.5
} while ($true)