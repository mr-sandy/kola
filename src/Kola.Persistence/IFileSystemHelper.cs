namespace Kola.Persistence
{
    using System.Collections.Generic;

    public interface IFileSystemHelper
    {
        bool FileExists(string relativePath);

        bool DirectoryExists(string relativePath);

        IEnumerable<string> FindChildDirectories(string relativePath, string pattern);

        void CreateDirectory(string relativePath);

        IEnumerable<string> GetFiles(string relativePath);
    }
}