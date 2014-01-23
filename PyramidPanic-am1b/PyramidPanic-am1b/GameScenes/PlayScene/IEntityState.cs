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
    public interface IEntityState
    {
        /* Elke toestandsclass van de Beetle past de interface IBeetleState toe (implementeren)
         * Deze interface eist dan van deze toestandsclass dat hij een Update en een Draw method heeft
         */        
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}
