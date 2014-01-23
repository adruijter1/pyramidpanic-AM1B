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
    // Dit is de toestands class van de Explorer    
    public class ExplorerWalkLeft : AnimatedSprite, IEntityState
    {
        // Fields
        private Explorer explorer;
        private Vector2 velocity;


        // Constructor van deze toestands class krijgt altijd het object mee
        // van de hoofdclass Explorer als argument
        public ExplorerWalkLeft(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.velocity = new Vector2(this.explorer.Speed, 0f);
            this.effect = SpriteEffects.FlipHorizontally;
        }

        public void Initialize()
        {
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;
        }

        public new void Update(GameTime gameTime)
        {
            if (Input.LevelDetectKeyUp(Keys.Left))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Initialize();
                this.explorer.Idle.Effect = SpriteEffects.FlipHorizontally;
            }
            
            this.explorer.Position -= this.velocity;
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;
            
            // Zorgt voor de animatie 
            base.Update(gameTime);
        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
