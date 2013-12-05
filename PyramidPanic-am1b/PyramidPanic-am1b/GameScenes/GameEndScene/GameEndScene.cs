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
    public class GameEndScene : IGameState
    {
        //Fields
        private PyramidPanic game;

        //Constructor
        public GameEndScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }

        //Initialize
        public void Initialize()
        {
            this.LoadContent();
        }


        //LoadContent
        public void LoadContent()
        {

        }


        //Update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                this.game.GameState = this.game.StartScene;
            }
        }
        
        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.DarkOliveGreen);
        }
    }
}
