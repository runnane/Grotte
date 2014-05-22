using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grotte
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont font;
        private Texture2D map;
        Effect effect;
        VertexPositionColor[] vertices;
        GraphicsDevice device;

        Matrix viewMatrix;
        Matrix projectionMatrix;

        Player player;

        List<Block> blocks;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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

            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("StandardFont");
            map = Content.Load<Texture2D>("map");
            effect = Content.Load<Effect>("effects");
            device = graphics.GraphicsDevice;

            blocks = new List<Block>();

            var bits = new Color[map.Width * map.Height];
            map.GetData<Color>(bits);

            player = new Player();

            for (int z = 0; z < map.Height; z++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    if (bits[x * map.Width + z] != Color.Black)
                        blocks.Add(new Block(x, z, bits[x * map.Width + z]));
                }
            }

            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, device.Viewport.AspectRatio, 1.0f, 300.0f);
           

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
    
            // TODO: Add your update logic here
            player.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Disable Culling! <dev>
            var rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            device.RasterizerState = rs;

            viewMatrix = Matrix.CreateLookAt(player.Position, player.Direction, new Vector3(0, 1, 0));

            // Clear screen
            GraphicsDevice.Clear(Color.Black);
            effect.CurrentTechnique = effect.Techniques["ColoredNoShading"];

            effect.Parameters["xView"].SetValue(viewMatrix);
            effect.Parameters["xProjection"].SetValue(projectionMatrix);
            effect.Parameters["xWorld"].SetValue(Matrix.Identity);

            spriteBatch.Begin();
            

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                foreach(Block block in blocks){
                    if(block != null)
                        block.Draw(gameTime, device);
                }
            }




            spriteBatch.DrawString(font, "Location: " + player.Position , new Vector2(5, 10), Color.White);
            spriteBatch.DrawString(font, "Direction: " + player.Direction, new Vector2(5, 30), Color.White);
            spriteBatch.DrawString(font, "Angle: " + MathHelper.ToDegrees(player.Angle), new Vector2(5, 50), Color.White);
            //spriteBatch.DrawString(font, "Mapsize: " + map.Width + "x" + map.Height, new Vector2(10, 30), Color.White);
            spriteBatch.End();
     
            base.Draw(gameTime);
        }

       

    }
}
