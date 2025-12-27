namespace ControllTask2;

using System;

    public class File
    {
        public string Name { get; }
        public string Extension { get; }
        public byte[] Data { get; set; }

        public File(string name, string extension)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя файла не может быть пустым");
            
            Name = name;
            Extension = extension;
            Data = new byte[0];
        }

        public override bool Equals(object obj)
        {
            if (obj is File other)
                return Name == other.Name && Extension == other.Extension;
            
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Extension);
        }

        public override string ToString()
        {
            return $"{Name}.{Extension}";
        }
    }