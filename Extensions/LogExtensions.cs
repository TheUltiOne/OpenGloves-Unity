using System;
using System.IO;
using OpenGloves_Unity.Logging;

namespace OpenGloves_Unity.Extensions
{
    public static class LogExtensions
    {
        public static void Write(this Log log, string content, bool check = true)
        {
            if (check) log.CheckFiles();

            using (StreamWriter writer = new StreamWriter(log.LogPath))
                writer.WriteLine($"[{DateTime.Now}]: {content}");
        }

        public static void WriteRaw(this Log log, string content, bool check = true)
        {
            if (check) log.CheckFiles();

            using (StreamWriter writer = new StreamWriter(log.LogPath))
                writer.Write(content);
        }
    }
}