﻿using System;
using System.Collections.Generic;
using System.Text;
using GameSpace.Interfaces;
using GameSpace.States.BlockStates;
using GameSpace.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameSpace.States.MarioStates;
using GameSpace.GameObjects.BlockObjects;
using System.Diagnostics;
using GameSpace.Enums;

namespace GameSpace.States.MarioStates
{
    class DeadMarioState : MarioActionStates//MarioPowerUpStates
    {
        public DeadMarioState(Mario mario)
            : base(mario)
        {

        }

        public override void Enter(IMarioActionStates previousActionState)
        {
            Mario.marioActionState = this;
            this.previousActionState = previousActionState;
           // Mario.marioPowerUpState = new DeadMarioState(Mario);
            Debug.WriteLine("MarioDeadState(25) ed, {0}", Mario.marioActionState);
            Debug.WriteLine("MarioDeadState(25) ded:, {0}", Mario.marioPowerUpState);

            //AABB aabb = Mario.AABB;
            //eFacing Facing = MarioStandingState.Facing;
            eFacing Facing = Mario.Facing;
            Mario.Facing = Facing;
            //Mario.Sprite = MarioStandingState.SpriteFactory.CreateSprite(MarioSpriteFactory.MarioSpriteType(this, currentPowerUpState));
            Mario.sprite = MarioFactory.GetInstance().CreateSprite(MarioFactory.MarioSpriteType(this, Mario.marioPowerUpState));

            //Mario.sprite = MarioFactory.GetInstance().CreateSprite(1);

        }

        public override void Exit() { }



        public override void StandingTransition()
        {//going to crouch for now(going to superstand
         //currentActionState.Exit();

        }
        public override void CrouchingTransition()
        {

        }//nothing
        public override void WalkingTransition()//Not Used Now, Used after Sprint2
        {

        }
        public override void RunningTransition()
        {

        } //Longer you hold running you increase velocity and speed of animation
        public override void JumpingTransition()
        {
            //Exit();
            //Mario.marioActionState = new DeadMarioJumpingState(Mario);
            //Debug.WriteLine("MarioStandState(39) currentAState, {0}", Mario.marioActionState);
            //Mario.sprite = MarioFactory.GetInstance().CreateSprite(5);
            //Mario.marioActionState.Enter(this); // Changing states
        }
        public override void FallingTransition()
        {
            //Exit();
            //Mario.marioActionState = new DeadMarioFallingState(Mario);
            //Debug.WriteLine("MarioStandState(39) currentAState, {0}", Mario.marioActionState);
            //Mario.sprite = MarioFactory.GetInstance().CreateSprite(6);
            //Mario.marioActionState.Enter(this); // Changing states
        }

        public override void FaceLeftTransition()
        {
            if (Mario.Facing == eFacing.LEFT)
                RunningTransition();
            // WalkingTransition(); bc no walking
            else
                Mario.Facing = eFacing.LEFT;
        }
        public override void FaceRightTransition()
        {

            if (Mario.Facing == eFacing.RIGHT)
                RunningTransition();
            // WalkingTransition();
            else
                Mario.Facing = eFacing.RIGHT;
        }

        public override void SmallPowerUp()
        {
            Exit();
            Mario.marioActionState = new SmallMarioStandingState(Mario);
            Mario.marioActionState.Enter(this);
        }
        public override void DeadPowerUp() { }
        public override void BigPowerUp() { }
        public override void FirePowerUp()
        {
            Exit();
            Mario.marioActionState = new FireMarioCrouchingState(Mario);
            Mario.marioActionState.Enter(this);
        }

        public override void CrouchingDiscontinueTransition()
        {
            StandingTransition();
        }//when you exit crouch, release down key
        public override void FaceLeftDiscontinueTransition() { }//generic entering walk and run, face left then start walking, then start running
        public override void FaceRightDiscontinueTransition() { }
        public override void WalkingDiscontinueTransition() { }//decelerata and go to standing
        public override void RunningDiscontinueTransition() { }//decelerate and go to walking dis
        public override void JumpingDiscontinueTransition() { }//abort jump or force jump to disc bc you reached apex of jump

        public override void Update(GameTime gametime)
        {

        }
        //void Update(GameTime gametime, GraphicsDeviceManager graphics);

        Vector2 ClampVelocity(Vector2 velocity)
        {
            return Vector2.Zero;
        }
        // max velocity speed, clamp for each state speed
    }
}
