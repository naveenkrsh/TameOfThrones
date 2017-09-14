using System.Collections.Generic;
using System.IO;
using System;
using System.Collections.ObjectModel;

namespace Core.Sources
{
    public class FileMessageSource : IMessageSource
    {
       
        private string Path { get; }
        public FileMessageSource(string path)
        {
            this.Path = path;
        }
        public ReadOnlyCollection<string> GetAllMessages()
        {
            StreamReader sr = File.OpenText(Path);
            List<string> fileContents = new List<string>();
            while (!sr.EndOfStream)
            {
                fileContents.Add(sr.ReadLine());
            }
            return new ReadOnlyCollection<string>(fileContents);
        }
    }
}