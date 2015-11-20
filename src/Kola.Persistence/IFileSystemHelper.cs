namespace Kola.Persistence
{
    using System.Collections.Generic;

    public interface IFileSystemHelper
    {
        bool FileExists(string path);

        bool DirectoryExists(string path);

        IEnumerable<string> FindChildDirectories(string path, string pattern);

        string CombinePaths(params string[] paths);

        void CreateDirectory(string path);

        void DeleteFile(string path);

        IEnumerable<string> GetFiles(string path);
    }
}