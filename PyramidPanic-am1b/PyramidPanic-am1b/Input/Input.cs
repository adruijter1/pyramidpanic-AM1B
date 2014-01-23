using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public static class Input
    {
        //Fields
        private static KeyboardState ks, oks;
        private static MouseState ms, oms;
        private static GamePadState gps, ogps;

        // Maak een rectangle voor de muiscursor
        private static Rectangle mouseRect;

        //Constructor van een static class mag geen excesmodifier (private, public, protected)
        //krijgen.
        static Input()
        {
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
            mouseRect = new Rectangle(ms.X, ms.Y, 1, 1);
        }

        public static void Update()
        {
            oks = ks;
            oms = ms;
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
        }


        // Dit is de edgedetector voor een willekeurige toets op het toetsenbord
        public static bool EdgeDetectKeyDown(Keys key)
        {
            return (ks.IsKeyDown(key) && oks.IsKeyUp(key));
        }

        // Dit is een edgedetector voor de linkermuisknop. Als deze knop in de huidige update
        // ingedrukt is en de vorige update niet, dan geeft de method true terug.
        public static bool EdgeDetectMousePressLeft()
        {
            return ((ms.LeftButton == ButtonState.Pressed) && (oms.LeftButton == ButtonState.Released));
        }

        // Dit is een leveldetector voor een willekeurige toets op het toetsenbord die ingedrukt wordt
        public static bool LevelDetectKeyDown(Keys key)
        {
            return ks.IsKeyDown(key);
        }

        // Dit is een leveldetector voor een willekeurige toets op het toetsenbord die losgelaten wordt
        public static bool LevelDetectKeyUp(Keys key)
        {
            return ks.IsKeyUp(key);
        }

        public static Rectangle MouseRect()
        {
            mouseRect.X = ms.X;
            mouseRect.Y = ms.Y;
            return mouseRect;
        }
    }
}
