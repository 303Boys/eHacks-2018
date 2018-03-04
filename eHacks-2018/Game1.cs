using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace eHacks_2018
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        List<Texture2D> sprites = new List<Texture2D>();
        List<Microsoft.Xna.Framework.Audio.SoundEffect> sounds = new List<Microsoft.Xna.Framework.Audio.SoundEffect>();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Level CurrentLevel;
        MainMenu menu;
        ReadLevel levelLoader;
		bool listLoaded;

        bool fullscreen;

        Camera camera;

        LevelEdit levelEditor;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

		private void updatePlayers(GameTime gameTime)
		{
            if(menu.gameState == MainMenu.GameState.inGame)
            {
                foreach (Player p in CurrentLevel.players)
                {
                    p.movementCheck(gameTime, CurrentLevel);
					if (p.health <= 0)
					{
                        Sounds.returnSound("Explosion").Play();
						p.isActive = false;
					}
                }
                //CurrentLevel.players[0].movementCheck(gameTime, CurrentLevel);
                foreach (Thing t in CurrentLevel.thingList)
                {
                    if (t.GetType().Equals(typeof(Projectile)))
                    {
                        //Projectile p = t as Projectile;
                        //t.GetType().GetProperty("sprite").SetValue(Content.Load<Texture2D>("bullet"), 0);
                        t.sprite = Content.Load<Texture2D>("bullet");
                        t.GetType().GetMethod("move").Invoke(t, null);
                    }
                }
            }
		}

		private void clean()
		{
			for (int i = 0; i < CurrentLevel.thingList.Count; i++)
			{
				if (CurrentLevel.thingList[i].isActive == false)
				{
					CurrentLevel.thingList[i] = null;
					CurrentLevel.thingList.Remove(CurrentLevel.thingList[i]);
				}
			}
			for (int i = 0; i < CurrentLevel.players.Count; i++)
			{
				if (CurrentLevel.players[i].isActive == false)
				{
					CurrentLevel.players[i] = null;
					CurrentLevel.players.Remove(CurrentLevel.players[i]);
				}
			}
		}

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.levelLoader = new ReadLevel();
            this.levelEditor = new LevelEdit(false);
            //camera = new Camera(GraphicsDevice.Viewport);

            menu = new MainMenu(this.levelLoader, this);
            IsMouseVisible = true;
			listLoaded = false;

            camera = new Camera(GraphicsDevice.Viewport);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            menu.LoadContent(Content, new Size(800, 600));

            sprites.Add(Content.Load<Texture2D>("simpleBlock"));
			sprites.Add(Content.Load<Texture2D>("basic"));
			sprites.Add(Content.Load<Texture2D>("bullet"));
			sprites.Add(Content.Load<Texture2D>("P1"));
			sprites.Add(Content.Load<Texture2D>("P2"));
            sprites.Add(Content.Load<Texture2D>("P3"));
            sprites.Add(Content.Load<Texture2D>("P4"));
            sprites.Add(Content.Load<Texture2D>("door_closed"));
            sprites.Add(Content.Load<Texture2D>("door_open"));

            Sounds.readSoundFiles(this);

            menu.recieveSprites(sprites);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                levelLoader.CreateLevel(System.Reflection.Assembly.GetExecutingAssembly().Location + "../../Content/Levels/level1.level", sprites);
                CurrentLevel = levelLoader.returnLevel();
            }

            //Switch between fullscreen using left or right alt and enter
            if((Keyboard.GetState().IsKeyDown(Keys.RightAlt) || Keyboard.GetState().IsKeyDown(Keys.LeftAlt)) && Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                if (fullscreen)
                {
                    graphics.IsFullScreen = false;
                    graphics.ApplyChanges();
                    fullscreen = false;
                }
                else
                {
                    graphics.PreferredBackBufferHeight = 600;
                    graphics.PreferredBackBufferWidth = 800;
                    graphics.IsFullScreen = true;
                    graphics.ApplyChanges();
                    fullscreen = true;
                }
            }

            levelEditor.checkState(this, CurrentLevel, sprites);
            menu.Update();
            //levelEditor.checkState(this, CurrentLevel, sprites);
			// TODO: Add your update logic here
			//Controls playerOneTest = new Controls();

            camera.camUpdate(gameTime, CurrentLevel);
			updatePlayers(gameTime);
			if (listLoaded == true)
			{
				clean();
			}
			base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //spriteBatch = levelLoader.loadLevel(spriteBatch, sprites);
            //CurrentLevel = levelLoader.returnLevel();
            //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transformMatrix);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transformMatrix);
            //spriteBatch.Begin();
            menu.Draw(spriteBatch);
            //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transformMatrix);
            if (menu.gameState == MainMenu.GameState.inGame)
            {
                spriteBatch = CurrentLevel.draw(spriteBatch, sprites);
				listLoaded = true;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void recieveLevel(Level level)
        {
            this.CurrentLevel = level;
        }
    }
}
