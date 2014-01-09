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

        // Maak een variabele aan van het type LoadScene
        private LoadScene loadScene; // Camelcase notatie

        // Maak een variabele aan van het type GameOverScene
        private GameOverScene gameOverScene; // Camelcase notatie
        
        
        // Maak een variabele aan van het type HelpScene
        private HelpScene helpScene; // Camelcase notatie

        // Maak een variabele aan van het type HelpScene
        private ScoreScene scoreScene; // Camelcase notatie

        //Maak een variabele van het typ QuitScene
        private QuitScene quitScene; //Camelcase notatie

        // Maak een variabele aan van het type GameEndScene
        private GameEndScene gameEndScene; // Camelcase notatie

        /* De variabele die alle verschillende Scene-objecten kan bevatten is van het type 
         * IGameState. Dit is geen class, maar een nieuw objecttype Interface
         */
        private IGameState gameState;

        //Properties
        #region Properties
        public IGameState GameState
        {
            get { return this.gameState; }
            set { this.gameState = value; }
        }

        public StartScene StartScene
        {
            get { return this.startScene; }
        }

        public PlayScene PlayScene
        {
            get { return this.playScene; }
        }

        public LoadScene LoadScene
        {
            get { return this.loadScene;  }
        }


        public GameOverScene GameOverScene
        {
            get { return this.gameOverScene; }
        }

        public HelpScene HelpScene
        {
            get { return this.helpScene; }
        }

        public ScoreScene ScoreScene
        {
            get { return this.scoreScene;  }
        }

        public QuitScene QuitScene
        {
            get { return this.quitScene; }
        }

        public GameEndScene GameEndScene
        {
            get { return this.gameEndScene; }
        }

        /* Hoe maak je een property voor een private field?
         * Een property is public, is van hetzelfde type als het field, heeft dezelfde naam
         * als het field maar is met Pascal-casing geschreven. Een getter maak als volgt:
         * get { return this.<naam van het field>; }
         */

        public SpriteBatch SpriteBatch
        {
            get { return this.spriteBatch; }
        }
        #endregion


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

            // Maak een instantie aan van de class LoadScene
            this.loadScene = new LoadScene(this);

            // Maak een instantie aan van de class StartScene
            this.playScene = new PlayScene(this);

            // Maak een instantie aan van de class GameOverScene
            this.gameOverScene = new GameOverScene(this);

            // Maak een instantie aan van de class HelpScene
            this.helpScene = new HelpScene(this);

            // Maak een instantie aan van de class ScoreScene
            this.scoreScene = new ScoreScene(this);

            // Maak een instantie aan van de class QuitScene en ken deze toe aan this.quitScene
            this.quitScene = new QuitScene(this);

            // Maak een instantie aan van de class GameEndScene
            this.gameEndScene = new GameEndScene(this);

            this.gameState = this.startScene;
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
            
            // Roep de Update method aan van de Input class
            Input.Update();

            // Roep de Update(gameTime) method aan van het startScene-object
            this.gameState.Update(gameTime);

            

            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Purple);

            // Roep de Begin() method aan van het spriteBatch-object
            this.spriteBatch.Begin();

            // Roep de Draw(gameTime) method aan van het startScene-object
            this.gameState.Draw(gameTime);

            // Roep de End() method aan van het spriteBatch-object
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
