﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;


namespace GameSpace.Sprites
{
    public class GreenKoopaSprite : AbstractSprite
    {
        public GreenKoopaSprite(Texture2D texture, int rows, int columns, int totalFrames, int startingPointX,
                int startingPointY)
        {
            Texture = texture;
            isVisible = true;
            currentFrame = 1;
            frameHeight = rows;
            frameWidth = columns;
            this.totalFrames = totalFrames;
            this.startingPointX = startingPointX;
            this.startingPointY = startingPointY;
            offsetX = 0;

            #region points
            currentFramePoint = new Point(startingPointX, startingPointY);
            frameOrigin = new Point(startingPointX, startingPointY);
            atlasSize = new Point(columns, rows);
            frameSize = new Point(Texture.Width / atlasSize.X, Texture.Height / atlasSize.Y);
            #endregion

            #region time
            timeSinceLastFrame = 0;
            milliSecondsPerFrame = 275;
            #endregion

        }
    }
}
