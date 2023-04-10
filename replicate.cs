using System;
using System.IO;
using System.Reflection;

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
            PlayRickRoll(); // Insert in loop if you want to rickroll everytime you replicate (spam)
        }

        static void PlayRickRoll()
        {
            string url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";

            // Launch the default web browser to play the video
            System.Diagnostics.Process.Start(url);
        }
    }
}
