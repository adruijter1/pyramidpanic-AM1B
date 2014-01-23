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
        private IAnimatedSprite iAnimatedSprite;
        protected Rectangle destinationRect, sourceRect;
        protected SpriteEffects effect = SpriteEffects.None;
        private float timer = 0f;
        protected int imageNumber = 0;


        // Constructor
        public AnimatedSprite(IAnimatedSprite iAnimatedSprite)
        {
            this.iAnimatedSprite = iAnimatedSprite;
            this.destinationRect = new Rectangle((int)this.iAnimatedSprite.Position.X,
                                                 (int)this.iAnimatedSprite.Position.Y,
                                                 32,
                                                 32);
            this.sourceRect = new Rectangle(this.imageNumber * 32, 0, 32, 32);
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
            
            this.destinationRect.X = (int)this.iAnimatedSprite.Position.X;
            this.destinationRect.Y = (int)this.iAnimatedSprite.Position.Y;
        }

        // Draw method
        public void Draw(GameTime gameTime)
        {
            this.iAnimatedSprite.Game.SpriteBatch.Draw(this.iAnimatedSprite.Texture,
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
