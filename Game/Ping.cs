using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ping.Game
{
	public class Ping : Microsoft.Xna.Framework.Game
	{
		private GraphicsDeviceManager _graphics;
		private KeyboardState _priorState;

		public SpriteBatch SpriteBatch;

		public int ScreenHeight = 600;
		public int ScreenWidth = 800;

		private Puck _puck;
		private Paddle _player1;
		private Paddle _player2;
		private Messages _messages;

		public bool GameStarted;
		public bool GameRunning;

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
			_priorState = Keyboard.GetState();

			// Initialize game components.
			var puckStartPosition = new Vector2(ScreenWidth / 2f - 16f, ScreenHeight / 2f - 16f);
			_puck = new Puck(this, puckStartPosition);

			float verticalCenter = (ScreenHeight / 2.0f) - 44.0f;
			_player1 = new Paddle(this, new Vector2(10f, verticalCenter));
			_player2 = new Paddle(this, new Vector2(ScreenWidth - 34f, verticalCenter));
			_messages = new Messages(this);
			_messages.SetMessage(Messages.Start);

			Components.Add(_player1);
			Components.Add(_player2);
			Components.Add(_puck);
			Components.Add(_messages);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			SpriteBatch = new SpriteBatch(GraphicsDevice);

			// NOTE: I'm empty!
		}

		protected override void UnloadContent()
		{
			// We're not using this for Ping.
		}

		protected override void Update(GameTime gameTime)
		{
			var currentState = Keyboard.GetState();

			if (currentState.IsKeyDown(Keys.Escape)) Exit();

			if (GameRunning)
			{
				// Puck/Paddle collision
				if (_puck.GetBoundingBox().Intersects(_player1.GetBoundingBox()) ||
					_puck.GetBoundingBox().Intersects(_player2.GetBoundingBox()))
				{
					_puck.ReflectHorizontally();
				}

				// Player controls
				UpdatePlayerPaddle(_player1, currentState, Keys.Q, Keys.A);
				UpdatePlayerPaddle(_player2, currentState, Keys.P, Keys.L);
			}

			// State management
			if (currentState.IsKeyDown(Keys.Enter) && _priorState.IsKeyUp(Keys.Enter))
			{
				GameStarted = true;
				GameRunning = !GameRunning;

				_messages.SetMessage(GameRunning ? Messages.Empty : Messages.Paused);
			}

			_priorState = currentState;

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.FromNonPremultiplied(63, 63, 63, 255));

			// NOTE: I'm empty!

			base.Draw(gameTime);
		}

		public void SideHit(PlayerIndex player)
		{
			if (player == PlayerIndex.One) _player1.Score();
			if (player == PlayerIndex.Two) _player2.Score();
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
