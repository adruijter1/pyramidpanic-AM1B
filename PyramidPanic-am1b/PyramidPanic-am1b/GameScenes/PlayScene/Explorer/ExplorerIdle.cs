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
    public class ExplorerIdle : AnimatedSprite, IEntityState
    {
        // Fields
        private Explorer explorer;
        private Vector2 velocity;

        //properties
        public SpriteEffects Effect
        {
            set { this.effect = value; }
        }

        // Constructor van deze toestands class krijgt altijd het object mee
        // van de hoofdclass Explorer als argument
        public ExplorerIdle(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.velocity = new Vector2(this.explorer.Speed, 0f);
            this.effect = SpriteEffects.None;
            this.imageNumber = 1;
            this.sourceRect = new Rectangle(this.imageNumber * 32, 0, 32, 32);
        }

        public void Initialize()
        {
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;
            this.effect = SpriteEffects.None;
        }

        public new void Update(GameTime gameTime)
        {
            if (Input.LevelDetectKeyDown(Keys.Right))
            {
                this.explorer.State = this.explorer.WalkRight;
                this.explorer.WalkRight.Initialize();
            }
            if (Input.LevelDetectKeyDown(Keys.Left))
            {
                this.explorer.State = this.explorer.WalkLeft;
                this.explorer.WalkLeft.Initialize();
            }
        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
