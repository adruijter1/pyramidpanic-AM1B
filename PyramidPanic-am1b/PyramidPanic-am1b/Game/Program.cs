using System;

namespace PyramidPanic
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (PyramidPanic game = new PyramidPanic())
            {
                game.Run();
            }
        }
    }
#endif
}

