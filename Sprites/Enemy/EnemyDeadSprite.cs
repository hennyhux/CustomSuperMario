﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameSpace.Sprites.Enemy
{
    public class EnemyDeadSprite : Sprite
    {
        public EnemyDeadSprite(Texture2D texture, int rows, int columns, int totalFrames)
        {
            Texture = texture;
            isVisible = true;
            this.rows = rows;
            this.columns = columns;
            frameWidth = columns;
            frameHeight = rows;
            currentFrame = 0;
            this.totalFrames = totalFrames;

        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (isVisible)
            {
                int width = Texture.Width / frameWidth;
                int height = Texture.Height / frameHeight;
                int row = currentFrame / frameWidth;
                int column = currentFrame % frameWidth;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y + 6, width * 2, height * 2);
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipVertically, 0);
            }
        }

        public override void Update(GameTime gametime)
        {

        }

    }
}
