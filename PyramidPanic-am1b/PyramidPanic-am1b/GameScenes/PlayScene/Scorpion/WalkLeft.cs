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
    public class WalkLeft : AnimatedSprite, IScorpionState
    {
        // Fields
        private Scorpion scorpion;


        // Constructor van deze toestands class krijgt altijd het object mee
        // van de hoofdclass Beetle als argument
        public WalkLeft(Scorpion scorpion) : base(scorpion)
        {
            this.scorpion = scorpion;
        }

        public void Initialize()
        {
            this.destinationRect.X = (int)this.scorpion.Position.X;
            this.destinationRect.Y = (int)this.scorpion.Position.Y;
        }

        public new void Update(GameTime gameTime)
        {
            if (this.scorpion.Position.X < 0)
            {
                this.scorpion.State = this.scorpion.WalkRight;
                this.scorpion.WalkRight.Initialize();
            }
            this.scorpion.Position -= new Vector2(0f, this.scorpion.Speed);
            base.Update(gameTime);
        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
