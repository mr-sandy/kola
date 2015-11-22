namespace Kola.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;

    public class FileSystemHelper : IFileSystemHelper
    {
        private readonly string root;

        public FileSystemHelper(string root)
        {
            this.root = root;
        }

        public bool FileExists(string relativePath)
        {
            var fullPath = Path.Combine(this.root, relativePath);
            return File.Exists(fullPath);
        }

        public bool DirectoryExists(string relativePath)
        {
            var fullPath = Path.Combine(this.root, relativePath);
            return Directory.Exists(fullPath);
        }

        public IEnumerable<string> FindChildDirectories(string relativePath, string pattern)
        {
            var fullPath = Path.Combine(this.root, relativePath);
            if (!Directory.Exists(fullPath)) return Enumerable.Empty<string>();

            var childPaths = Directory.GetDirectories(fullPath, pattern, SearchOption.TopDirectoryOnly);
            return childPaths.Select(d => new DirectoryInfo(d).Name);
        }

        public void CreateDirectory(string relativePath)
        {
            var fullPath = Path.Combine(this.root, relativePath);
            Directory.CreateDirectory(fullPath);
        }

        public IEnumerable<string> GetFiles(string relativePath)
        {
            var fullPath = Path.Combine(this.root, relativePath);
            return Directory.GetFiles(fullPath).Select(Path.GetFileName);
        }
    }
}