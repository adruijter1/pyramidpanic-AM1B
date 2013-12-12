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
    public class Menu
    {
        #region Fields
        private PyramidPanic game;
        private Image startButton;
        #endregion

        #region Properties
        
        #endregion


        #region Constructor
        public Menu(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }
        #endregion

        #region Initialize
        public void Initialize()
        {
            this.LoadContent();
        }
        #endregion

        #region LoadContent
        public void LoadContent()
        {
            this.startButton = new Image(this.game, @"StartScene\Button_start", new Vector2(10f, 440f));
        }
        #endregion

        #region Update
        
        #endregion


        #region Draw
        public void Draw(GameTime gameTime)
        {
            this.startButton.Draw(gameTime);
        }
        #endregion
    }
}
