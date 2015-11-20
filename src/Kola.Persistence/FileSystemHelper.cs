namespace Kola.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FileSystemHelper : IFileSystemHelper
    {
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public IEnumerable<string> FindChildDirectories(string path, string pattern)
        {
            if (!Directory.Exists(path)) return Enumerable.Empty<string>();

            var childPaths = Directory.GetDirectories(path, pattern, SearchOption.TopDirectoryOnly);
            return childPaths.Select(d => new DirectoryInfo(d).Name);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public IEnumerable<string> GetFiles(string path)
        {
            return Directory.GetFiles(path).Select(Path.GetFileName);
        }
    }
}