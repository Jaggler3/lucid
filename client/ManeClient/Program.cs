using Mane.GameCore;
using System;

namespace Mane
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            GameScript.Initialize();
            using (var game = new MonoGameInitialize())
            {
                game.Run();
            }
        }
    }
#endif
}
