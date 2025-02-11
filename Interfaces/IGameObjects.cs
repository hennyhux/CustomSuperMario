﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameSpace.Interfaces
{
    public interface IGameObjects
    {
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Rectangle CollisionBox { get; set; }
        public int ObjectID { get; }
        public void Draw(SpriteBatch spritebatch);
        public void Update(GameTime gametime);
        public void Trigger();
        public void HandleCollision(IGameObjects entity);
        public void ToggleCollisionBoxes();
        public bool RevealItem();
    }
}
