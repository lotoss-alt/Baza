namespace ControllTask2;

    public interface IDirectory
    {
        List<Directory> Directories { get; set; }
        List<File> Files { get; set; }
        string Name { get; }
        Directory RootDirectory { get; set; }

        bool AddFileToDirectory(File file);
        bool ContainsFile(File file);
        bool RemoveFileFromDirectory(File file);
    }
