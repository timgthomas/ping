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

		private Paddle _player1;
		private Paddle _player2;

		public int Player1Score;
		public int Player2Score;

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

			_player1 = new Paddle(this, 10f);
			_player2 = new Paddle(this, ScreenWidth - 34f);

			Components.Add(_player1);
			Components.Add(_player2);
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
			var currentState = Keyboard.GetState();

			if (currentState.IsKeyDown(Keys.Escape)) Exit();

			UpdatePlayerPaddle(_player1, currentState, Keys.Q, Keys.A);
			UpdatePlayerPaddle(_player2, currentState, Keys.P, Keys.L);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			Window.Title = string.Format("P1: {0} - P2: {1}", Player1Score, Player2Score);

			base.Draw(gameTime);
		}

		public void SideHit(PlayerIndex player)
		{
			if (player == PlayerIndex.One) Player1Score += 1;
			if (player == PlayerIndex.Two) Player2Score += 1;
		}

		private void UpdatePlayerPaddle(Paddle playerPaddle, KeyboardState currentState, Keys up, Keys down)
		{
			if (currentState.IsKeyDown(up))
			{
				playerPaddle.MoveUp();
			}
			else
			{
				playerPaddle.StopMovingUp();
			}

			if (currentState.IsKeyDown(down))
			{
				playerPaddle.MoveDown();
			}
			else
			{
				playerPaddle.StopMovingDown();
			}
		}
	}
}
