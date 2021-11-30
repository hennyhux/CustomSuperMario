﻿using GameSpace.Abstracts;
using GameSpace.EntityManaging;
using GameSpace.Enums;
using GameSpace.Factories;
using GameSpace.Interfaces;
using GameSpace.States;
using GameSpace.States.EnemyStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using GameSpace.Machines;
using GameSpace.Objects.EnemyObjects;

namespace GameSpace.GameObjects.EnemyObjects
{
    public class SpinyRefactored : Enemy
    {
        private int searchState;//0 passed mario, now throw spiny, 1 going left towards mario, 2 going right towards mario
        public SpinyRefactored(Vector2 initalPosition)
        {
            state = new StateSpinyAliveLeft(this);
            Position = initalPosition;
            drawBox = false;
            ObjectID = (int)EnemyID.UBERGOOMBA;
            Direction = (int)MarioDirection.LEFT;
        }
    }

    public abstract class StateSpiny : IMobState
    {
        public ISprite StateSprite { get; set; }
        internal protected SpinyRefactored enemy;

        protected StateSpiny(SpinyRefactored enemy)
        {
            this.enemy = enemy;
        }

        public void Draw(SpriteBatch spritebatch, Vector2 position)
        {
            StateSprite.Draw(spritebatch, position);
        }

        public void DrawBoundingBox(SpriteBatch spritebatch, Rectangle collisionBox)
        {
            StateSprite.DrawBoundary(spritebatch, collisionBox);
        }

        public abstract void Trigger();

        public void Update(GameTime gametime)
        {
            StateSprite.Update(gametime);
            UpdatePosition(enemy.Position, gametime);
            UpdateCollisionBox(enemy.Position);
            UpdateSpeed();
        }
        internal virtual void UpdatePosition(Vector2 location, GameTime gametime)
        {
            enemy.Velocity += enemy.Acceleration * (float)gametime.ElapsedGameTime.TotalSeconds;
            enemy.Position += enemy.Velocity * (float)gametime.ElapsedGameTime.TotalSeconds;
        }

        internal virtual void UpdateCollisionBox(Vector2 location)
        {
            enemy.CollisionBox = new Rectangle((int)location.X, (int)location.Y,
                StateSprite.Texture.Width / 7, StateSprite.Texture.Height /2 + 4);

            enemy.ExpandedCollisionBox = new Rectangle((int)location.X, (int)location.Y,
                StateSprite.Texture.Width / 7, (StateSprite.Texture.Height /2 ) + 6);
        }

        internal virtual void UpdateSpeed()
        {
            if (EnemyCollisionHandler.GetInstance().IsGoingToFall(enemy))
            {
                enemy.Acceleration = new Vector2(0, 400);
            }

            else
            {
                enemy.Acceleration = new Vector2(0, 0);
                if (enemy.Direction == (int)MarioDirection.RIGHT)
                {
                    enemy.Velocity = new Vector2(75, 0);
                }

                else if (enemy.Direction == (int)MarioDirection.LEFT)
                {
                    enemy.Velocity = new Vector2(-75, 0);
                }
            }
        }

        internal protected void DestoryCollisionBox()
        {
            enemy.CollisionBox = new Rectangle(0, 0, 0, 0);

            enemy.ExpandedCollisionBox = new Rectangle(0, 0, 0, 0);
        }

        internal protected void HaltAllMotion()
        {
            enemy.Velocity = new Vector2(0, 0);
            enemy.Acceleration = new Vector2(0, 0);
        }

    }

    public class StateSpinyAliveLeft : StateSpiny
    {
        public StateSpinyAliveLeft(SpinyRefactored spiny) : base (spiny)
        {
            StateSprite = SpriteEnemyFactory.GetInstance().CreateSpinySprite();
        }

        public override void Trigger()
        {
            //death when triggered, or whatever the behavior is 
            DestoryCollisionBox();
            HaltAllMotion();
        }
    }

    public class StateSpinyAliveRight : StateSpiny
    {
        public StateSpinyAliveRight(SpinyRefactored enemy) : base(enemy)
        {
            StateSprite = SpriteEnemyFactory.GetInstance().CreateSpinySprite();
            StateSprite.Facing = SpriteEffects.FlipHorizontally;
        }

        public override void Trigger()
        {
            //death when triggered, or whatever the behavior is 
            DestoryCollisionBox();
            HaltAllMotion();
        }
    }
}

