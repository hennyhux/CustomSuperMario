﻿using GameSpace.Abstracts;
using GameSpace.EntitiesManager;
using GameSpace.Enums;
using GameSpace.Factories;
using GameSpace.Interfaces;
using GameSpace.States;
using GameSpace.States.EnemyStates;
using Microsoft.Xna.Framework;

namespace GameSpace.GameObjects.EnemyObjects
{
    public class RedKoopa : AbstractEnemy
    {

        public RedKoopa(Vector2 initalPosition)
        {
            ObjectID = (int)EnemyID.REDKOOPA;
            Direction = (int)eFacing.LEFT;
            drawBox = false;
            Position = initalPosition;
            state = new StateRedKoopaAliveLeft(this);
            Sprite = SpriteEnemyFactory.GetInstance().CreateRedKoopaSprite();
            ExpandedCollisionBox = new Rectangle((int)(Position.X + Sprite.Texture.Width / 32), (int)Position.Y, Sprite.Texture.Width, Sprite.Texture.Height * 3);
            UpdateCollisionBox(Position);
        }

        public override void UpdatePosition(Vector2 location, GameTime gameTime) //use velocity
        {
            if (EntityManager.IsGoingToFall(this) && !(state is StateRedKoopaDead))
            {

                Velocity = new Vector2(0, Velocity.Y);
                Acceleration = new Vector2(0, 400);
            }

            else if (!EntityManager.IsGoingToFall(this))
            {
                Acceleration = new Vector2(0, 0);
                if (Direction == (int)eFacing.RIGHT && !(state is StateRedKoopaDead))
                {
                    Velocity = new Vector2(85, 0);
                }

                if (Direction == (int)eFacing.LEFT && !(state is StateRedKoopaDead))
                {
                    Velocity = new Vector2(-85, 0);
                }
            }

            Velocity += Acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            UpdateCollisionBox(Position);
        }

        public override void Trigger()
        {
            state = new StateRedKoopaDead(this);
            PreformShellOffset();
        }

        #region Collision Handling
        public IEnemyState GetCurrentState()
        {
            return state;
        }

        private void PreformShellOffset()
        {
            Position = new Vector2(Position.X, Position.Y + 20);
        }

        #endregion
    }
}

