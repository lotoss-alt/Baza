namespace ControllTask2;

    public interface IFileProvider
    {
        Directory CurrentDirectory { get; }
        string CurrentPath { get; }
        string Delimiter { get; }
        Directory RootDirectory { get; }
        string RootDirectoryPath { get; }

        Directory AddDirectory(string path, string name);
        void BackToTheRoots();
        void ChangeOS(OS os);
        File FindFileByPath(string path);
        bool GetNextDirectory(string name);
        bool TryDeleteDirectory(string path);
    }
