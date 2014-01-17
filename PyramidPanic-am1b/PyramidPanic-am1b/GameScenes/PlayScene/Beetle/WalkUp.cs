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
    // Dit is de toestands class van de Beetle    
    public class WalkUp : IBeetleState
    {
        // Fields
        private Beetle beetle;


        // Constructor van deze toestands class krijgt altijd het object mee
        // van de hoofdclass Beetle als argument
        public WalkUp(Beetle beetle)
        {
            this.beetle = beetle;
        }

        public void Update(GameTime gameTime)
        {
            if (this.beetle.Position.Y < 0)
            {
                this.beetle.State = new WalkDown(this.beetle);
            }
            this.beetle.Position -= new Vector2(0f, this.beetle.Speed);
        }

        public void Draw(GameTime gameTime)
        {
            this.beetle.Game.SpriteBatch.Draw(this.beetle.Texture,
                                              this.beetle.Position,
                                              Color.White);
        }
    }
}
