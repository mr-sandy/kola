namespace Kola.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FileSystemHelper
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

        public string CombinePaths(params string[] paths)
        {
            return Path.Combine(paths.ToArray());
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public IEnumerable<string> GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }
    }
}