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
    public class StartScene : IGameState
    {
        //Fields
        private PyramidPanic game;

        // Stap1: maak een variabele (reference) aan van de class, bedenk een goede passende naam
        private Image background;

        // Maak een variabele aan genaamd title, deze is van het type Image
        private Image title;

       

        //Constructor
        public StartScene(PyramidPanic game)
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
            this.background = new Image(this.game, @"StartScene\Background", Vector2.Zero);

            // Maak een object aan van het type Image
            this.title = new Image(this.game, @"StartScene\Title", new Vector2(100f, 30f));
        }


        //Update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                this.game.GameState = this.game.PlayScene;
            }
        }
        
        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Red);
            this.background.Draw(gameTime);
            this.title.Draw(gameTime);
        }
    }
}
