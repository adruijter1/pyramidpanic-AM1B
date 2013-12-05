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
   
    public class PyramidPanic : Microsoft.Xna.Framework.Game
    {
        // Fields, de velden van deze class 
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        // Maak een variabele aan van het type StartScene
        private StartScene startScene; // Camelcase notatie

        // Maak een variabele aan van het type PlayScene
        private PlayScene playScene; // Camelcase notatie

        // Maak een variabele aan van het type GameOverScene
        private GameOverScene gameOverScene; // Camelcase notatie
        
        
        // Maak een variabele aan van het type HelpScene
        private HelpScene helpScene; // Camelcase notatie

        // Maak een variabele aan van het type GameEndScene
        private GameEndScene gameEndScene; // Camelcase notatie

        public PyramidPanic()
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            // Maakt de muiscursor zichtbaar in het canvas
            IsMouseVisible = true;
            
            // Veranderd de titel van het canvas
            this.Window.Title = "Pyramid Panic";
            
            // Veranderd de breedte van het canvas
            this.graphics.PreferredBackBufferWidth = 640;

            //Veranderd de hoogte van het canvas
            this.graphics.PreferredBackBufferHeight = 480;

            // Past de veranderingen betreffende het canvas toe
            this.graphics.ApplyChanges();
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            // Maak een instantie aan van de class StartScene
            this.startScene = new StartScene(this);

            // Maak een instantie aan van de class StartScene
            this.playScene = new PlayScene(this);

            // Maak een instantie aan van de class GameOverScene
            this.gameOverScene = new GameOverScene(this);

            // Maak een instantie aan van de class HelpScene
            this.helpScene = new HelpScene(this);

            // Maak een instantie aan van de class GameEndScene
            this.gameEndScene = new GameEndScene(this);
        }

        
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            // Wanneer de gamepad Back toets of de toetsenbord Escape toets wordt ingedrukt dan
            // Stopt het spel 
            if ( (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
                 (Keyboard.GetState().IsKeyDown(Keys.Escape)))
                this.Exit();
            
            // Roep de Update(gameTime) method aan van het startScene-object
            this.gameEndScene.Update(gameTime);

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Purple);

            // Roep de Begin() method aan van het spriteBatch-object
            this.spriteBatch.Begin();

            // Roep de Draw(gameTime) method aan van het startScene-object
            this.gameEndScene.Draw(gameTime);

            // Roep de End() method aan van het spriteBatch-object
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}