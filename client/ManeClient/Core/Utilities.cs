using System;
using System.IO;

namespace Mane.Core
{
    class Utilities
    {
        public const string GameVersion = "0.1.0";
        public static string LoadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
