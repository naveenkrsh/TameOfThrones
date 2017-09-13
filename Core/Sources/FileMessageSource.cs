using System.Collections.Generic;
using System.IO;
using System;
namespace Core.Sources
{
    public class FileMessageSource : IMessageSource
    {
        public string Path { get; set; }
        public FileMessageSource(string path)
        {
            this.Path = path;
        }


        List<string> IMessageSource.GetAllMessages()
        {
            StreamReader sr = File.OpenText(Path);
            List<string> fileContents = new List<string>();
            while (!sr.EndOfStream)
            {
                fileContents.Add(sr.ReadLine());
            }
            return fileContents;
        }
    }
}