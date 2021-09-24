﻿using GameSpace.Factories;
using GameSpace.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameSpace
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private List<ISprite> spriteList;
        private List<ISprite> enemySpriteList;
        private List<IController> controllers;
        private BlockFactory blockFactory;
        private MarioFactory marioFactory;
        private EnemyFactory enemyFactory;
        private BackgroundFactory backgroundFactory;

        private ISprite MarioSprite;
        private ISprite Background;

        private BrickBlock newBricks;
        public BrickBlock NewBricks { get => newBricks; }

        public List<ISprite> SpriteList { get => spriteList; }
        public ISprite GetMarioSprite { get => MarioSprite; }
        public GraphicsDeviceManager Graphics { get => graphics; }

        public BlockFactory BlockFactory { get => blockFactory; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            controllers = new List<IController>()
            {
                new KeyboardInput(this), new ControllerInput(this)
            };

            blockFactory = new BlockFactory();
            marioFactory = new MarioFactory();
            enemyFactory = new EnemyFactory();
            backgroundFactory = new BackgroundFactory();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("font");
            blockFactory.LoadContent(Content);
            marioFactory.LoadContent(Content);
            enemyFactory.LoadContent(Content);
            backgroundFactory.LoadContent(Content);

            spriteList = new List<ISprite>()
            {
                blockFactory.ReturnUsedBlock(), blockFactory.ReturnStairBlock(),
                blockFactory.ReturnBrickBlock(), blockFactory.ReturnFloorBlock(),
                blockFactory.ReturnHiddenBlock(), blockFactory.ReturnQuestionBlock(),
            };

            enemySpriteList = new List<ISprite>()
            {
                enemyFactory.ReturnGoomba()
            };

            MarioSprite = marioFactory.ReturnMarioStandingLeftSprite();
            Background = backgroundFactory.ReturnRegularBackground();

            newBricks = new BrickBlock(this);
        }

        protected override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }

            //foreach (ISprite sprite in spriteList)
            //{
            //    sprite.Update(gameTime);
            //}

            //foreach (ISprite sprite in enemySpriteList)
            //{
            //    sprite.Update(gameTime);
            //}

            newBricks.Update(gameTime);
            MarioSprite.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(blendState: BlendState.AlphaBlend);

            //foreach (ISprite sprite in spriteList)
            //{
            //    sprite.Draw(spriteBatch, new Vector2(0, 0));
            //}

            //foreach (ISprite sprite in enemySpriteList)
            //{
            //    sprite.Draw(spriteBatch, new Vector2(0, 0));
            //}

            newBricks.Draw(spriteBatch, new Vector2(150, 150));
            MarioSprite.Draw(spriteBatch, new Vector2(500, 200));
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
