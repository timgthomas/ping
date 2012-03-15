using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ping.Game
{
	public class Paddle : DrawableGameComponent
	{
		private readonly Ping _ping;

		private static Texture2D _texture;
		private static SpriteFont _monofur;
		
		private int _score;

		private Vector2 _size;
		private Vector2 _position;
		private Vector2 _velocity;

		private bool _movingUp;
		private bool _movingDown;

		public Paddle(Ping game, Vector2 position) : base(game)
		{
			_ping = game;

			_size = new Vector2(24f, 88f);
			_position = position;
			_velocity = new Vector2(0f);
		}

		protected override void LoadContent()
		{
			_texture = Game.Content.Load<Texture2D>("paddle");
			_monofur = Game.Content.Load<SpriteFont>("verdana");
		}

		public override void Draw(GameTime gameTime)
		{
			var scoreSize = _monofur.MeasureString(_score.ToString());
			var location = new Vector2(
				_position.X + + _size.X / 2.0f - scoreSize.X / 2.0f,
				_position.Y + _size.Y / 2.0f - scoreSize.Y / 2.0f);

			_ping.SpriteBatch.Begin();
			_ping.SpriteBatch.Draw(_texture, _position, Color.White);
			_ping.SpriteBatch.DrawString(_monofur, _score.ToString(), location, Color.White);
			_ping.SpriteBatch.End();
		}

		public override void Update(GameTime gameTime)
		{
			const float maxSpeed = 5f;

			if (!_ping.GameRunning) return;

			_velocity.Y = 0;

			if (_movingUp && _position.Y > 8)
			{
				_velocity.Y = _velocity.Y - maxSpeed;
			}

			if (_movingDown && _position.Y < _ping.ScreenHeight - _size.Y - 8)
			{
				_velocity.Y = _velocity.Y + maxSpeed;
			}

			_position = _position + _velocity;
		}

		public Rectangle GetBoundingBox()
		{
			return new Rectangle((int)_position.X, (int)_position.Y, (int)_size.X, (int)_size.Y);
		}

		public void MoveUp()
		{
			_movingUp = true;
		}

		public void StopMovingUp()
		{
			_movingUp = false;
		}

		public void MoveDown()
		{
			_movingDown = true;
		}

		public void StopMovingDown()
		{
			_movingDown = false;
		}

		public void Score()
		{
			_score += 1;
		}
	}
}