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
        // We definieren een nieuw soort variabele, Button. Het is een enum.
        private enum Button { Start, Load, Help, Scores, Quit };
        //                      0      1    2       3       4
        /* We maken nu een variabele aan van het type Button. Deze variabele kan maar 5 waarden
         * aannemen. Namelijk Start, Load, Help, Scores, Quit. We kunnen natuurlijk altijd
         * waarden toevoegen.
         */
        private Button buttonState = Button.Start;

        // Definieer een kleur van de actieve knop
        private Color activeColor = Color.PeachPuff;

        // game bevat de PyramidPanic instantie doorgegeven als argument aan de constructor
        private PyramidPanic game;
        private Image startButton, loadButton, helpButton, scoresButton, quitButton;
        
        // Maak een List<Image> waar we Image objecten in kunnen stoppen, in dit geval de buttons
        private List<Image> buttonList;
        private int top = 430, left = 10, space = 130;
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
            this.startButton = 
                new Image(this.game, @"StartScene\Button_start", new Vector2(this.left, this.top));
            this.loadButton = 
                new Image(this.game, @"StartScene\Button_load", new Vector2(this.left + this.space, this.top));
            this.helpButton =
                new Image(this.game, @"StartScene\Button_help", new Vector2(this.left + 2 * this.space, this.top));
            this.scoresButton =
                new Image(this.game, @"StartScene\Button_scores", new Vector2(this.left + 3 * this.space, this.top));
            this.quitButton =
                new Image(this.game, @"StartScene\Button_quit", new Vector2(this.left + 4 * this.space, this.top));

            this.startButton.Color = Color.Gold;
            // Maak een nieuw object van het type List<Image>
            this.buttonList = new List<Image>();

            // Voeg nu de gemaakte Image objecten toe aan this.buttonList
            this.buttonList.Add(this.startButton);
            this.buttonList.Add(this.loadButton);
            this.buttonList.Add(this.helpButton);
            this.buttonList.Add(this.scoresButton);
            this.buttonList.Add(this.quitButton);        
        }
        #endregion

        #region Update
        public void Update(GameTime gameTime)
        {
            /* Maak het menu bestuurbaar met de muis
             */            
            this.MakeButtonActiveByMouse(this.startButton, this.game.PlayScene, Button.Start);
            this.MakeButtonActiveByMouse(this.loadButton, this.game.LoadScene, Button.Load);
            this.MakeButtonActiveByMouse(this.helpButton, this.game.HelpScene, Button.Help);
            this.MakeButtonActiveByMouse(this.scoresButton, this.game.ScoreScene, Button.Scores);
            this.MakeButtonActiveByMouse(this.quitButton, this.game.QuitScene, Button.Quit);
 
           
            // Als de right knop wordt ingedrukt....
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                // en de buttonState is kleiner dan Button.quit
                if (this.buttonState < Button.Quit)
                {
                    // Zet alle knopkleuren op wit
                    foreach (Image button in this.buttonList)
                    {
                        button.Color = Color.White;
                    }
                    // Verhoog de buttonState met 1
                    this.buttonState++;
                }
            }

            // Als de links knop wordt ingedrukt
            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                // Als de buttonState groter is dan Button.Start
                if (this.buttonState > Button.Start)
                {
                    // Maak alle knopkleuren wit
                    foreach (Image button in this.buttonList)
                    {
                        button.Color = Color.White;
                    }
                    // Verlaag de buttonState met 1
                    this.buttonState--;
                }
            }
           

            // Maak een switch-case instructie voor het evalueren van de variabele this.buttonState
            switch (this.buttonState)
            {
                case Button.Start:
                    this.startButton.Color = this.activeColor;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.PlayScene;
                    }
                    break;
                case Button.Load:
                    this.loadButton.Color = this.activeColor;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.LoadScene;
                    }
                    break;
                case Button.Help:
                    this.helpButton.Color = this.activeColor;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.HelpScene;
                    }
                    break;
                case Button.Scores:
                    this.scoresButton.Color = this.activeColor;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.ScoreScene;
                    }
                    break;
                case Button.Quit:
                    this.quitButton.Color = this.activeColor;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.GameState = this.game.QuitScene;
                    }
                    break;
            }
        }
        #endregion


        #region Draw
        public void Draw(GameTime gameTime)
        {
            foreach (Image button in this.buttonList)
            {
                button.Draw(gameTime);
            }           
        }
        #endregion

        // HelperMethod
        private void ChangeButtonColorToNormal()
        {
            foreach (Image button in this.buttonList)
            {
                button.Color = Color.White;
            }
        }

        // HelperMethod Als je met je muiscursor over een knop gaat wordt deze knop actief
        // Er wordt dan ook gedetecteerd of er linksgeklikt wordt.
        private void MakeButtonActiveByMouse(Image button, IGameState scene, Button buttonState)
        {
            if (button.Rectangle.Intersects(Input.MouseRect()))
            {
                if (Input.EdgeDetectMousePressLeft())
                {
                    this.game.GameState = scene;
                }
                this.buttonState = buttonState;
                this.ChangeButtonColorToNormal();
            }
        }
    }
}
