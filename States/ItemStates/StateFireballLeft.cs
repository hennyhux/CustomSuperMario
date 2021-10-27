﻿using GameSpace.Factories;
using GameSpace.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using GameSpace.GameObjects.ItemObjects;
using System.Diagnostics;
using GameSpace.Enums;

namespace GameSpace.States.ItemStates
{
    public class StateFireballLeft : IItemStates
    {
        public ISprite StateSprite { get; set; }
        public Boolean CollidedWithMario { get; set; }
        public Fireball Fireball;
        private Boolean bounce;
        public int countdown;
        public int timeAlive; 

        public StateFireballLeft(Fireball fireball)
        {
            StateSprite = SpriteItemFactory.GetInstance().CreateFireBall();
            CollidedWithMario = false;
            this.Fireball = fireball;
            this.Fireball.Position = new Vector2(this.Fireball.Position.X - 25, this.Fireball.Position.Y +25);
            this.Fireball.Velocity = new Vector2((float)-80, (float)0);
            this.Fireball.Acceleration = new Vector2(0, 400);
        }

        public void Draw(SpriteBatch spritebatch, Vector2 location)
        {
            if (bounce) ++this.countdown;
            ++timeAlive;
        }

        public void Trigger()
        {
            bounce = true;
        }

        public void Update(GameTime gametime)
        {
            if (this.countdown == 4)
            {
                this.Fireball.Acceleration = new Vector2(0, 400);
                bounce = false;
                this.countdown = 0;
            }

            if (timeAlive == 75) this.Fireball.Trigger();
        }
    }
}
