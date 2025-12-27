namespace ControllTask2;

    public class Directory : IDirectory
    {
        public string Name { get; }
        public Directory RootDirectory { get; set; }
        public List<Directory> Directories { get; set; }
        public List<File> Files { get; set; }

        public Directory(string name, Directory rootDirectory = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя директории не должно быть пустым");
            
            Name = name;
            RootDirectory = rootDirectory;
            Directories = new List<Directory>();
            Files = new List<File>();
        }

        public bool AddFileToDirectory(File file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));
            
            if (ContainsFile(file))
                return false;
            
            Files.Add(file);
            return true;
        }

        public bool RemoveFileFromDirectory(File file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));
            
            return Files.Remove(file);
        }

        public bool ContainsFile(File file)
        {
            return Files.Contains(file);
        }

        public override string ToString()
        {
            return Name;
        }
    }