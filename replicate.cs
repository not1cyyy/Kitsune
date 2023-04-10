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
            for (int i = 0; i < MAX_ITERATIONS; i++)
            {
                string newFileName = Path.GetDirectoryName(fileName) + "\\" +
                    Path.GetFileNameWithoutExtension(fileName) + i + Path.GetExtension(fileName);
                File.Copy(fileName, newFileName, true);
            }
        }
    }
}
