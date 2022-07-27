using System;
using System.IO;
using OpenGloves_Unity.Extensions;

namespace OpenGloves_Unity.Logging
{
    /// <summary>
    /// A util class to Log info to a log file.
    /// </summary>
    public class Log
    {
        /// <summary>
        /// The <see cref="Log"/> instance used by <see cref="OpenGloves_Unity"/>
        /// </summary>
        public static Log OpenGlovesLogger {
            get
            {
                if (_defaultLogger == null)
                    _defaultLogger = new Log(OpenGlovesFolderName, OpenGlovesLogFileName);

                return _defaultLogger;
            }
        }

        private static Log _defaultLogger;

        /// <summary>
        /// A const <see cref="string"/> with the <see cref="Log"/>'s default Folder name
        /// </summary>
        public const string OpenGlovesFolderName = "OpenGloves";

        /// <summary>
        /// A const <see cref="string"/> with the <see cref="Log"/>'s default file name
        /// </summary>
        public const string OpenGlovesLogFileName = "opengloves-unity.log";


        /// <summary>
        /// A readonly <see cref="string"/> with a path to the user's AppData
        /// </summary>
        public static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        /// <summary>
        /// A readonly <see cref="string"/> with a path to the log folder
        /// </summary>
        public string FolderPath { get; set; }

        /// <summary>
        /// A readonly <see cref="string"/> with a path to the log file
        /// </summary>
        public string LogPath { get; set; }

        /// <summary>
        /// Creates a <see cref="Log"/> instance and the files required for it.
        /// </summary>
        /// <param name="folderName">The folder's name to be created.</param>
        /// <param name="fileName">The file's name to be created.</param>
        /// <param name="showAwake">Chooses if the Log awake! message will be sent.</param>
        /// <remarks>This will not create anything if FolderName is not specified. It will automatically create in the AppData folder if nothing is specified. If you wish to automatically create files, specify FolderPath and LogPath properties and call <see cref="CheckFiles"/>.</remarks>
        public Log(string folderName = "", string fileName = "", bool showAwake = true)
        {
            if (folderName != "")
            {
                FolderPath = Path.Combine(AppData, folderName);

                if (fileName != "")
                    LogPath = Path.Combine(FolderPath, fileName);

                CheckFiles();
            }


            if (showAwake)
                Info("Log awake!");
        }

        /// <summary>
        /// Checks if the <see cref="LogPath"/> & <see cref="FolderPath"/> exist, and creates them if not.
        /// </summary>
        public void CheckFiles()
        {
            if (FolderPath == "" && LogPath == "")
                return;

            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            if (!File.Exists(LogPath))
                File.Create(LogPath);
        }

        /// <summary>
        /// Writes information to the <see cref="Log"/>
        /// </summary>
        /// <param name="content">The content to send.</param>
        public void Info(string content)
            => this.Write($"[INFO] {content}");

        /// <summary>
        /// Writes debugging information to the <see cref="Log"/>.
        /// </summary>
        /// <param name="content">The content to send.</param>
        /// <remarks>This will only send if OpenGloves-Unity is built in debug config.</remarks>
        public void Debug(string content)
        {
            #if DEBUG
            this.Write($"[DEBUG] {content}");
            #endif
        }

        /// <summary>
        /// Writes an error to the <see cref="Log"/>.
        /// </summary>
        /// <param name="content">The content to send.</param>
        public void Error(string content)
            => this.Write($"[ERROR] {content}");
    }
}