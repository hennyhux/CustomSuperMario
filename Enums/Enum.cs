﻿namespace GameSpace.Enums
{
    public enum BlockID
    {
        FLOORBLOCK = 0,
        HIDDENBLOCK = 1,
        USEDBLOCK = 2,
        STAIRBLOCK = 3,
        BRICKBLOCK = 4,
        COINBRICKBLOCK = 5,
        STARBRICKBLOCK = 6,
        QUESTIONBLOCK = 7,
        COINQUESTIONBLOCK = 8,
        STARQUESTIONBLOCK = 9,
        ONEUPSHROOMQUESTIONBLOCK = 10,
        SUPERSHROOMQUESTIONBLOCK = 11,
        FIREFLOWERQUESTIONBLOCK = 12
    };

    public enum ItemID : int
    {
        COIN = 13,
        STAR = 14,
        ONEUPSHROOM = 15,
        SUPERSHROOM = 16,
        FIREFLOWER = 17,
        FIREBALL = 18,
        SMALLPIPE = 19,
        MEDIUMPIPE = 20,
        BIGPIPE = 21,
        WARPPIPE = 22,
        WARPPIPEGOOMBA = 23,
        WARPPIPEGREENKOOPA = 24,
        WARPPIPEREDKOOPA = 25,
        WARPPIPENEWENEMY = 26, //For Sprint 5, we can implement another enemy
        FLAGPOLE = 27,
        CASTLE = 28
    };

    public enum EnemyID : int
    {
        GOOMBA = 29,
        GREENKOOPA = 30,
        REDKOOPA = 31,
        NEWENEMYFORSPRINT5 = 32 //For Sprint 5, we can implement another enemy
    };

    public enum Velocity
    {
        VELOCITYMARIO = 33,
        VELOCITYGOOMBA = 34,
        VELOCITYGREENKOOPA = 35,
        VELOCITYREDKOOPA = 36,
        VELOCITYNEWENEMY = 37 //For Sprint 5, we can implement velocity for new enemy
    };

    public enum eFacing
    {
        LEFT = 38,
        RIGHT = 39
    };

    public enum AvatarID
    {
        MARIO = 40,
    };

    public enum CollisionDirection
    {
        UP, // NEEDS FIXED! If this enum is changed, Mario will do nothing when it is supposed to kill an enemy. This might be HARDCODED somewhere. NEEDS FIXED!
        DOWN = 42,
        LEFT = 43,
        RIGHT = 44
    };
}
