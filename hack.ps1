# Initialize
$workpath = "D:\Workspace\TThack"
cd $workpath

do {
    Write-Host "Ready Go!"
    # Capture screenshot
    adb shell screencap -p /sdcard/screenshot.png;
    copy screenshot-2.png screenshot-3.png
    copy screenshot-1.png screenshot-2.png
    copy screenshot.png screenshot-1.png
    adb pull /sdcard/screenshot.png $workpath;

    .\PictureProcess\PictureProcess\obj\Debug\PictureProcess.exe .\screenshot.png
    # swipe
    adb shell input swipe 500 1700 500 1700 $LASTEXITCODE
    #adb shell input swipe 0 0 0 0 $LASTEXITCODE
    Start-Sleep -Seconds 1
} while ($true)