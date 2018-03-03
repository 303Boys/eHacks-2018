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

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Level CurrentLevel;
        ReadLevel levelLoader;
        LevelEdit levelEditor;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

		private void updatePlayers(GameTime gameTime)
		{
			CurrentLevel.players[0].movementCheck(gameTime, CurrentLevel);
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

            sprites.Add(Content.Load<Texture2D>("simpleBlock"));

            levelLoader.CreateLevel(System.Reflection.Assembly.GetExecutingAssembly().Location + "..\\..\\..\\..\\..\\..\\Levels\\level1.level", sprites);
            CurrentLevel = levelLoader.returnLevel();
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

            levelEditor.checkState(this, CurrentLevel, sprites);
			// TODO: Add your update logic here
			//Controls playerOneTest = new Controls();

			updatePlayers(gameTime);
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
            spriteBatch = CurrentLevel.draw(spriteBatch, sprites);

            base.Draw(gameTime);
        }
    }
}
