using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Reflection;
using System.Resources;

namespace TaskOne
{
    public class UserFile
    {
        public string Directory { get; set; }
        public string PathOfFile { get; set; }
        public Version Version { get; set; }

        public UserFile(string directory, string pathOfFile)
        {
            Directory = directory;
            PathOfFile = pathOfFile;
            if (File.Exists(pathOfFile))
            {
                Version = new Version(FileVersionInfo.GetVersionInfo(PathOfFile).FileVersion);
            }
            else
            {
                Version = new Version();
            }
        }

        public void UpdateFileToVersion(UserFile targetFileVersion)
        {
            File.Delete(this.PathOfFile);
            if (targetFileVersion == null)
            {
                throw new ArgumentNullException("targetFileVersion cannot be null", "targetFileVersion");
            }
            File.Copy(targetFileVersion.PathOfFile, this.PathOfFile);
        }

        public static int CompareFileVersion(UserFile currentFile, UserFile newFile)
        {
            if (currentFile == null || newFile == null)
            {
                throw new ArgumentNullException("currentFile and newFile cannot be null");
            }
            return currentFile.Version.CompareTo(newFile.Version);
        }

        public bool HasNewerVersionThen(UserFile file)
        {
            if (file == null)
                throw new ArgumentNullException("file cannot be null");
            else if (CompareFileVersion(file, this) != -1)
                return false;

            return true;
        }
    }
}
