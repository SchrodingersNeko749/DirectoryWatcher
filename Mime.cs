using System.Collections.Generic;
using System.IO;

namespace DirectoryWatcher
{
    public static class MIMEAssistant
    {
    private static readonly Dictionary<string, string> MIMETypesDictionary = new Dictionary<string, string>
    {
        //images
        {"jpg", "/home/neko/Images/downloads/"},
        {"png", "/home/neko/Images/downloads/"},
        {"webm","/home/neko/Images/downloads/"},
        {"gif","/home/neko/Images/downloads/"},
        //documents
        {"doc", "/home/neko/Books/downloads/"},
        {"docx", "/home/neko/Books/downloads/"},
        {"log","/home/neko/Books/downloads/"},
        {"msg", "/home/neko/Books/downloads/"},
        {"txt", "/home/neko/Books/downloads/"},
        {"pdf", "/home/neko/Books/downloads/"},
        //audio-music
        {"aif", "/home/neko/Music/downloads/"},
        {"iff", "/home/neko/Music/downloads/"},
        {"m3u","/home/neko/Music/downloads/"},
        {"m4a","/home/neko/Music/downloads/"},
        {"midi","/home/neko/Music/downloads/"},
        {"mp3","/home/neko/Music/downloads/"},
        {"mpa","/home/neko/Music/downloads/"},
        {"wav","/home/neko/Music/downloads/"},
        {"wma","/home/neko/Music/downloads/"},
        //data
        {"rar","/home/neko/Downloads/data"},
        {"zip","/home/neko/Downloads/data"},
        {"tar","/home/neko/Downloads/data"},
        {"tar.gz","/home/neko/Downloads/data"},
        //video
        {"3g2", "/home/neko/Movies/downloads/"},
        {"3gp", "/home/neko/Movies/downloads/"},
        {"asf", "/home/neko/Movies/downloads/"},
        {"avi", "/home/neko/Movies/downloads/"},
        {"flv", "/home/neko/Movies/downloads/"},
        {"m4v", "/home/neko/Movies/downloads/"},
        {"mov", "/home/neko/Movies/downloads/"},
        {"mp4", "/home/neko/Movies/downloads/"},
        {"mpg", "/home/neko/Movies/downloads/"},
        {"rm", "/home/neko/Movies/downloads/"},
        {"rst", "/home/neko/Movies/downloads/"},
        {"swf", "/home/neko/Movies/downloads/"},
        {"vob", "/home/neko/Movies/downloads/"},
        {"wmv", "/home/neko/Movies/downloads/"},
    };

    public static string GetMIMEType(string fileName)
    {
        //get file extension
        string extension = Path.GetExtension(fileName).ToLowerInvariant();

        if (extension.Length > 0 && 
            MIMETypesDictionary.ContainsKey(extension.Remove(0, 1)))
        {
        return MIMETypesDictionary[extension.Remove(0, 1)];
        }
        return "unknown/unknown";
    }
    }
    
}