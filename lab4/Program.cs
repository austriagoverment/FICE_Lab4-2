using System;

namespace FileSystem 
{
    public class CustomDirectory
    {
        public string Path { get; set; }

        public CustomDirectory(string path)
        {
            Path = path;
        }

        public override string ToString()
        {
            return $"Шлях: {Path}";
        }

        public override bool Equals(object obj)
        {
            if (obj is CustomDirectory otherDirectory)
            {
                return Path.Equals(otherDirectory.Path, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Path.GetHashCode();
        }
    }

    public class File 
    {
        public string Name { get; set; }
        
        public CustomDirectory ParentDirectory { get; set; }

        public File(string name, CustomDirectory directory) 
        {
            Name = name;
            ParentDirectory = directory;
        }
        
        public void Delete()
        {
            Console.WriteLine($"Видалення файлу: {Name}");
        }

        public void Rename(string newName)
        {
            Console.WriteLine($"Перейменування файлу: {Name} на {newName}");
            Name = newName;
        }

        public override string ToString()
        {
            return $"File Name: {Name}, Directory: {ParentDirectory.Path}";
        }

        public override bool Equals(object obj)
        {
            if (obj is File otherFile)
            {
                return Name.Equals(otherFile.Name, StringComparison.OrdinalIgnoreCase) &&
                       ParentDirectory.Equals(otherFile.ParentDirectory);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, ParentDirectory);
        }
    }

    public class TextFile : File
    {
        public TextFile(string name, CustomDirectory directory) : base(name, directory)
        {
        }

        public void Open()
        {
            Console.WriteLine($"Відкриття файлу: {Name} в директорії: {ParentDirectory.Path}");
        }

        public void Print()
        {
            Console.WriteLine($"Друк файлу: {Name}");
        }

        public void AppendText(string text)
        {
            Console.WriteLine($"Додавання тексту до файлу: {Name} - {text}");
        }

        public override string ToString()
        {
            return $"Text File Name: {Name}, Directory: {ParentDirectory.Path}";
        }

        public override bool Equals(object obj)
        {
            if (obj is TextFile otherTextFile)
            {
                return base.Equals(otherTextFile);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            CustomDirectory directory1 = new CustomDirectory("/Documents");
            CustomDirectory directory2 = new CustomDirectory("/Documents");

            Console.WriteLine(directory1);
            Console.WriteLine(directory2);
            Console.WriteLine($"Директорії дорівнюються: {directory1.Equals(directory2)}");

            File file1 = new File("report.docx", directory1);
            File file2 = new File("report.docx", directory2);

            Console.WriteLine(file1);
            Console.WriteLine(file2);
            Console.WriteLine($"Файли дорівнюються: {file1.Equals(file2)}");

            TextFile textFile = new TextFile("notes.txt", directory1);
            textFile.Open();
            textFile.AppendText("Це додатковий текст");
            textFile.Print();
        }
    }
}