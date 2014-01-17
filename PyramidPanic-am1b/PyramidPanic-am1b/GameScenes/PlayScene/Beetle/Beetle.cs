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
    public class Beetle
    {
        // Fields
        private Vector2 position;
        private int speed = 2;
        private PyramidPanic game;
        private IBeetleState state;
        private Texture2D texture;
        private WalkUp walkUp;
        private WalkDown walkDown;

        // Properties
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        public int Speed
        {
            get { return this.speed; }
        }
        public IBeetleState State
        {
            get { return this.state; }
            set { this.state = value; }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        public WalkDown WalkDown
        {
            get { return this.walkDown; }
        }
        public WalkUp WalkUp
        {
            get { return this.walkUp; }
        }


        // Maak de constructor
        public Beetle(PyramidPanic game, Vector2 position)
        {
            this.position = position;
            this.game = game;
            this.texture = this.game.Content.Load<Texture2D>(@"PlayScene\Beetle");
            this.walkDown = new WalkDown(this);
            this.walkUp = new WalkUp(this);
            this.state = this.walkDown;
        }

        public void Update(GameTime gameTime)
        {
            this.state.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);
        }
    }
}
