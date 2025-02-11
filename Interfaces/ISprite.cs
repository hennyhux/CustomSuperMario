﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameSpace
{
    public interface ISprite
    {
        Texture2D Texture { get; set; }
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Update(GameTime gametime);
        void SetVisible();
        void DrawBoundary(SpriteBatch spriteBatch, Rectangle destination);
        int GetTotalFrames();
    }
}
