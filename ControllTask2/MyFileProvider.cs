namespace ControllTask2;

    public class MyFileProvider : IFileProvider
    {
        private static readonly Dictionary<OS, (string delimiter, string rootPath)> FileProviderParameters =
            new Dictionary<OS, (string, string)>
            {
                { OS.Windows, ("\\", "C:\\") },
                { OS.Unix, ("/", "/") },
                { OS.MacOS, ("/", "/MyMac") }
            };

        private OS _currentOS;
        private Directory _currentDirectory;
        private string _currentPath;
        private string _delimiter;
        private Directory _rootDirectory;
        private string _rootDirectoryPath;

        public Directory CurrentDirectory 
        { 
            get => _currentDirectory;
            private set => _currentDirectory = value;
        }

        public string CurrentPath
        {
            get => _currentPath;
            private set => _currentPath = value;
        }

        public string Delimiter
        {
            get => _delimiter;
            private set => _delimiter = value;
        }

        public Directory RootDirectory
        {
            get => _rootDirectory;
            private set => _rootDirectory = value;
        }

        public string RootDirectoryPath
        {
            get => _rootDirectoryPath;
            private set => _rootDirectoryPath = value;
        }

        public MyFileProvider(OS os)
        {
            ChangeOS(os);
        }

        public void ChangeOS(OS os)
        {
            _currentOS = os;
            var parameters = FileProviderParameters[os];
            _delimiter = parameters.delimiter;
            _rootDirectoryPath = parameters.rootPath;
            
            _rootDirectory = new Directory("root", null);
            _currentDirectory = _rootDirectory;
            _currentPath = _rootDirectoryPath;
        }

        public Directory AddDirectory(string path, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя директории не может быть пустым");

            if (string.IsNullOrWhiteSpace(path))
            {
                var newDir = new Directory(name, _currentDirectory);
                _currentDirectory.Directories.Add(newDir);
                return newDir;
            }

            var targetDir = FindDirectoryByPath(path);
            if (targetDir == null)
                throw new InvalidOperationException($"Директория по пути '{path}' не найдена");

            var directory = new Directory(name, targetDir);
            targetDir.Directories.Add(directory);
            return directory;
        }

        public void BackToTheRoots()
        {
            _currentDirectory = _rootDirectory;
            _currentPath = _rootDirectoryPath;
        }

        public File FindFileByPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Путь не может быть пустым");

            var pathParts = path.Split(new[] { _delimiter }, StringSplitOptions.RemoveEmptyEntries);
            var currentDir = _currentDirectory;

            for (int i = 0; i < pathParts.Length - 1; i++)
            {
                var dirName = pathParts[i];
                currentDir = currentDir.Directories.FirstOrDefault(d => d.Name == dirName);
                
                if (currentDir == null)
                    throw new InvalidOperationException($"Директория '{dirName}' не найдена");
            }

            var fileNameWithExtension = pathParts.Last();
            var fileParts = fileNameWithExtension.Split('.');
            
            if (fileParts.Length < 2)
                throw new ArgumentException("Некорректное имя файла");

            var fileName = fileParts[0];
            var fileExtension = string.Join(".", fileParts.Skip(1));
            
            var targetFile = new File(fileName, fileExtension);
            
            return currentDir.Files.FirstOrDefault(f => f.Equals(targetFile));
        }

        public bool GetNextDirectory(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя директории не может быть пустым");

            var nextDir = _currentDirectory.Directories.FirstOrDefault(d => d.Name == name);
            
            if (nextDir == null)
                return false;

            _currentDirectory = nextDir;
            _currentPath += _delimiter + name;
            return true;
        }

        public bool TryDeleteDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;

            try
            {
                var directory = FindDirectoryByPath(path);
                if (directory == null)
                    return false;

                if (directory == _rootDirectory)
                    return false;

                var tempDir = _currentDirectory;
                while (tempDir != null)
                {
                    if (tempDir == directory)
                        return false;
                    tempDir = tempDir.RootDirectory;
                }

                directory.RootDirectory?.Directories.Remove(directory);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveFileOnCurrentDirectory(File file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            return _currentDirectory.AddFileToDirectory(file);
        }

        private Directory FindDirectoryByPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return _currentDirectory;

            var pathParts = path.Split(new[] { _delimiter }, StringSplitOptions.RemoveEmptyEntries);
            var currentDir = _currentDirectory;

            foreach (var dirName in pathParts)
            {
                currentDir = currentDir.Directories.FirstOrDefault(d => d.Name == dirName);
                
                if (currentDir == null)
                    return null;
            }

            return currentDir;
        }
    }