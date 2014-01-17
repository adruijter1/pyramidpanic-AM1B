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
    public class AnimatedSprite
    {
        //Fields
        private Beetle beetle;
        protected Rectangle destinationRect, sourceRect;
        protected SpriteEffects effect = SpriteEffects.None;
        private float timer = 0f;


        // Constructor
        public AnimatedSprite(Beetle beetle)
        {
            this.beetle = beetle;
            this.destinationRect = new Rectangle((int)this.beetle.Position.X,
                                                 (int)this.beetle.Position.Y,
                                                 32,
                                                 32);
            this.sourceRect = new Rectangle(0, 0, 32, 32);
        }

        public void Update(GameTime gameTime)
        {
            if (this.timer > 5 / 60f)
            {
                if (this.sourceRect.X < 96)
                {
                    this.sourceRect.X += 32;
                }
                else
                {
                    this.sourceRect.X = 0;
                }
                this.timer = 0f;
            }
            else
            {
                this.timer += 1 / 60f;
            }
            
            this.destinationRect.X = (int)this.beetle.Position.X;
            this.destinationRect.Y = (int)this.beetle.Position.Y;
        }

        // Draw method
        public void Draw(GameTime gameTime)
        {
            this.beetle.Game.SpriteBatch.Draw(this.beetle.Texture,
                                              this.destinationRect,
                                              this.sourceRect,
                                              Color.White,
                                              0f,
                                              Vector2.Zero,
                                              this.effect,
                                              0f);
        }
    }
}
