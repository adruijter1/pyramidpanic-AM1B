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
    public class WalkDown : AnimatedSprite, IEntityState
    {
        // Fields
        private Beetle beetle;
        private Vector2 velocity;


        // Constructor van deze toestands class krijgt altijd het object mee
        // van de hoofdclass Beetle als argument
        public WalkDown(Beetle beetle) : base(beetle)
        {
            this.beetle = beetle;
            this.effect = SpriteEffects.FlipVertically;
            this.velocity = new Vector2(0f, this.beetle.Speed);
        }

        public void Initialize()
        {
            this.destinationRect.X = (int)this.beetle.Position.X;
            this.destinationRect.Y = (int)this.beetle.Position.Y;
        }

        public new void Update(GameTime gameTime)
        {
            if (this.beetle.Position.Y > 480 - 32)
            {
                this.beetle.State = this.beetle.WalkUp;
                this.beetle.WalkUp.Initialize();
            }
            this.beetle.Position += this.velocity;
            base.Update(gameTime);
        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
