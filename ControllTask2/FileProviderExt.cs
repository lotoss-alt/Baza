namespace ControllTask2;

    public static class FileProviderExt
    {
        public static string[] GetDirectoryNamesFromPath(this IFileProvider provider, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return Array.Empty<string>();

            return path.Split(new[] { provider.Delimiter }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
