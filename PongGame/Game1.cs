using _1.Zadaca;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PongGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Paddle PaddleBottom { get; private set; }
        public Paddle PaddleTop { get; private set; }
        public Ball Ball { get; private set; }
        public Background Background { get; private set; }
        public SoundEffect HitSound { get; private set; }
        public Song Music { get; private set; }
        private IGenericList<Sprite> SpritesForDrawList = new GenericList<Sprite>();
      
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 600,
                PreferredBackBufferWidth = 500

            };

            
            Content.RootDirectory = "Content";
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

            var  screenBounds = GraphicsDevice.Viewport.Bounds;

            Texture2D paddleTexture = Content.Load<Texture2D>("paddle");

            PaddleBottom = new Paddle(paddleTexture);
            PaddleTop = new Paddle(paddleTexture);

 
            PaddleBottom.Position = new Vector2(screenBounds.Bottom, screenBounds.Bottom - PaddleBottom.Size.Height);
            PaddleTop.Position = new Vector2(screenBounds.Top);


            Texture2D ballTexture = Content.Load<Texture2D>("ball");

            Ball = new Ball(ballTexture);
           Ball.Position = screenBounds.Center.ToVector2();
         
            Texture2D backgroundTexture = Content.Load<Texture2D>("background");
            Background = new Background(backgroundTexture, screenBounds.Width, screenBounds.Height);

            HitSound = Content.Load<SoundEffect>("hit");
            Music = Content.Load<Song>("music");
            
            MediaPlayer.IsRepeating = true;
          
            MediaPlayer.Play(Music);
            ;

            SpritesForDrawList.Add(Background);
            SpritesForDrawList.Add(PaddleBottom);
            SpritesForDrawList.Add(PaddleTop);
            SpritesForDrawList.Add(Ball);
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


            var touchState = Keyboard.GetState();
            if (touchState.IsKeyDown(Keys.Left)) {

                PaddleBottom.Position.X -= (float)(PaddleBottom.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
            }
            if (touchState.IsKeyDown(Keys.Right)) {
                PaddleBottom.Position.X += (float)(PaddleBottom.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
            }
            if (touchState.IsKeyDown(Keys.A))
            {
                PaddleTop.Position.X -= (float)(PaddleTop.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);

            }
            if (touchState.IsKeyDown(Keys.D))
            {
                PaddleTop.Position.X += (float)(PaddleTop.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
                
            }
            // TODO: Add your update logic here
            PaddleTop.Position.X = MathHelper.Clamp(PaddleTop.Position.X, graphics.GraphicsDevice.Viewport.Bounds.Left, graphics.GraphicsDevice.Viewport.Bounds.Right - PaddleTop.Size.Width);
            PaddleBottom.Position.X = MathHelper.Clamp(PaddleBottom.Position.X, graphics.GraphicsDevice.Viewport.Bounds.Left, graphics.GraphicsDevice.Viewport.Bounds.Right - PaddleBottom.Size.Width);

            Ball.Position += Ball.Direction * (float)(gameTime.ElapsedGameTime.TotalMilliseconds * Ball.Speed);

            var bounds = GraphicsDevice.Viewport.Bounds;
          
            if (Ball.Position.X < bounds.Left || Ball.Position.X + Ball.Size.Width > bounds.Right)
            {
                Ball.Direction.X = -Ball.Direction.X;
                Ball.Speed = Ball.Speed * Ball.BumpSpeedIncreaseFactor;
                HitSound.Play();
                
            }

            if (Ball.Position.Y > bounds.Bottom || Ball.Position.Y < bounds.Top)
            {
                Ball.Position = bounds.Center.ToVector2();
             
                Ball.Speed = Ball.InitialSpeed;
            
            }
            
            if((CollisionDetector.Overlaps(Ball,PaddleTop) && Ball.Direction.Y < 0) ||
            (CollisionDetector.Overlaps(Ball, PaddleBottom) && Ball.Direction.Y > 0)){
            
                Ball.Direction.Y = -Ball.Direction.Y;
                Ball.Speed *= Ball.BumpSpeedIncreaseFactor;
               
                
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

            spriteBatch.Begin();
            foreach (Sprite element in SpritesForDrawList) {
                element.Draw(spriteBatch);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
