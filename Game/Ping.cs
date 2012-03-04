using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ping.Game
{
	public class Ping : Microsoft.Xna.Framework.Game
	{
		private GraphicsDeviceManager _graphics;

		public SpriteBatch SpriteBatch;

		public int ScreenHeight = 600;
		public int ScreenWidth = 800;

		public Ping()
		{
			_graphics = new GraphicsDeviceManager(this)
				{
					PreferredBackBufferHeight = ScreenHeight,
					PreferredBackBufferWidth = ScreenWidth
				};
			Content.RootDirectory = "Content";
		}

		protected override void Initialize()
		{
			var puck = new Puck(this);

			Components.Add(puck);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			SpriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
		}

		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

			// TODO: Add your update logic here

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here

			base.Draw(gameTime);
		}
	}
}
