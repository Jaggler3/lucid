using System;
using System.IO;

namespace Mane.Core
{
    class Utilities
    {
        public static string LoadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
