namespace Kola.Persistence
{
    using System.Collections.Generic;

    public interface IFileSystemHelper
    {
        bool FileExists(string path);

        bool DirectoryExists(string path);

        IEnumerable<string> FindChildDirectories(string path, string pattern);

        void CreateDirectory(string path);

        IEnumerable<string> GetFiles(string path);
    }
}