﻿
using System;
using GameSpace.Machines;
namespace GameSpace
{
    public class TakeDamage : ICommand
    {
        private protected GameRoot game;
        public TakeDamage(GameRoot game)
        {
            this.game = game;
        }

        public void Execute()
        {
            MarioHandler.marioLives--;
        }

        public void Unexecute()
        {
            throw new NotImplementedException();
        }
    }


}
